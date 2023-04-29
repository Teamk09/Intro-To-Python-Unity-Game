using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}

public class BattleSystem : MonoBehaviour
{

    public GameObject Java;
    public GameObject Python;
    public GameObject Swift;

    public GameObject EnemyJava;

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
        if (PlayerPrefs.GetInt("Choice") == 1)
        {
            GameObject python = Instantiate(Python, PlayerBattleStation);
            playerUnit = python.GetComponent<Unit>();
        }
        else if (PlayerPrefs.GetInt("Choice") == 2)
        {
            GameObject java = Instantiate(Java, PlayerBattleStation);
            playerUnit = java.GetComponent<Unit>();
        }
        else
        {
            
            GameObject swift = Instantiate(Swift, PlayerBattleStation);
            playerUnit = swift.GetComponent<Unit>();
            
        }



        GameObject enemyJava = Instantiate(EnemyJava, EnemyBattleStation);
        enemyUnit = enemyJava.GetComponent<Unit>();

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
        {
            dialogueText.text = $"THE {enemyUnit.unitName} UNINSTALLS...".ToUpper();
            StartCoroutine(BeatRosen());
        } 
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "YOU'VE BEEN INFECTED...";
        }
        else
        {
            dialogueText.text = "SUCCESS!";
        }

        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    IEnumerator BeatRosen()
    {  
        dialogueText.text = "WOW CAMERON YOU'RE SO GOOD AT PROGRAMMING AND PUT SO MUCH EFFORT INTO THIS PROJECT. HERE'S A \"SKIP THE FINAL\" PASS FOR BEATING ME...";
        yield return new WaitForSeconds(20f);
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
