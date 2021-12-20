using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState
{
    StartBattle,
    PlayerSelecAction,
    PlayerMove,
    EnemyMove,
    Busy,
    
}

public class BattleManager : MonoBehaviour
{
    [SerializeField]public BattleUnit playerUnit;
    [SerializeField]public BattleHud playerHud;
    
    [SerializeField]public BattleUnit enemyUnit;
    [SerializeField]public BattleHud enemyHud;

    [SerializeField] private BattleDialogueBox battleDialogueBox;

    public BattleState state;
    
    private void Start()
    {
        StartCoroutine(SetUpBattle());
    }

    public IEnumerator SetUpBattle()
    {
        state = BattleState.StartBattle;
        
        
        playerUnit.setupPokemon();
        playerHud.SetPokemonData(playerUnit.Pokemon);
        
        enemyUnit.setupPokemon();
        enemyHud.SetPokemonData(playerUnit.Pokemon);
        
        yield return battleDialogueBox.SetDialogue($"An {enemyUnit.Pokemon.Base.Name} has appeared");
        yield return new WaitForSeconds(1.0f);

        if (enemyUnit.Pokemon.Velocity > playerUnit.Pokemon.Velocity)
        {
            StartCoroutine(battleDialogueBox.SetDialogue("The Enemy Attacks first")); 
            EnemyAction();
        }
        else
        {
           PlayerAction();  
        }
       
    }

    void PlayerAction()
    {
        state = BattleState.PlayerSelecAction;
        StartCoroutine(battleDialogueBox.SetDialogue("Select an action"));
        battleDialogueBox.toggleActions(true);
    }

    void EnemyAction()
    {
        
    }
    
}
