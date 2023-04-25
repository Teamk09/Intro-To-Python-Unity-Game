using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

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
        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject playerPokemon = Instantiate(PlayerPrefab, PlayerBattleStation);
        playerUnit = playerPokemon.GetComponent<Unit>();

        GameObject enemyPokemon = Instantiate(EnemyPrefab, EnemyBattleStation);
        enemyUnit = enemyPokemon.GetComponent<Unit>();

        dialogueText.text = $"A CORRUPTED {enemyUnit.unitName} DOWNLOADS...".ToUpper();

        userHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
    }

}
