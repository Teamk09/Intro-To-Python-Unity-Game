using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{

    public GameObject PlayerPrefab;
    public GameObject EnemyPrefab;

    public Transform PlayerBattleStation;
    public Transform EnemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public TMP_Text dialogueText;

    public HUD userHUD;
    public HUD enemyHUD;

    public BattleState state;


    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerPokemon = Instantiate(PlayerPrefab, PlayerBattleStation);
        playerUnit = playerPokemon.GetComponent<Unit>();

        GameObject enemyPokemon = Instantiate(EnemyPrefab, EnemyBattleStation);
        enemyUnit = enemyPokemon.GetComponent<Unit>();

        dialogueText.text = $"A CORRUPTED {enemyUnit.unitName} DOWNLOADS...".ToUpper();

        userHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(3f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
            dialogueText.text = $"THE {enemyUnit.unitName} UNINSTALLS...".ToUpper();
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "YOU'VE BEEN INFECTED...";
        }
        else
        {
            dialogueText.text = "SUCCESS!";
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    IEnumerator EnemyTurn()
    {
        dialogueText.text = $"{enemyUnit.unitName} ATTACKS!".ToUpper();

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

        userHUD.HP(playerUnit.currentHP);

        dialogueText.text = $"YOU TOOK {enemyUnit.damage} DAMAGE!";

        yield return new WaitForSeconds(1f);

        if(playerUnit.currentHP <=0)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }


    void PlayerTurn()
    {
        dialogueText.text = "CHOOSE AN ACTION.";
    }

    public void AttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());

    }
    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.HP(enemyUnit.currentHP);
        dialogueText.text = $"YOU DID {playerUnit.damage} DAMAGE";

        state = BattleState.ENEMYTURN;

        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            //End Battle
            state = BattleState.WON;
            EndBattle();
        }

        else
        {
            StartCoroutine(EnemyTurn());
        }
    }





    public void HealButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());

    }

    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);

        userHUD.HP(playerUnit.currentHP);
        dialogueText.text = "YOU DRINK A COFFEE AND FEEL NEW AGAIN...";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }





    public void BagButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        //StartCoroutine(PlayerBag());

    }






    public void FleeButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerFlee());

    }


    IEnumerator PlayerFlee()
    {
        dialogueText.text = "YOU ATTEMPT TO FLEE";

        yield return new WaitForSeconds(2f);

        EndBattle();
    }

}
