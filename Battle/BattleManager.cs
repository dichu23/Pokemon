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
        
        battleDialogueBox.SetPokemonMovments(playerUnit.Pokemon.Moves);
        
        enemyUnit.setupPokemon();
        enemyHud.SetPokemonData(enemyUnit.Pokemon);
        
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
        battleDialogueBox.toggleDialogText(true);
        battleDialogueBox.toggleActions(true);
        battleDialogueBox.toggleMovments(false);
        currentSelectedAction = 0;
        battleDialogueBox.SelectAction(currentSelectedAction);
        
    }

    void PlayerMovment()
    {
        state = BattleState.PlayerMove;
        battleDialogueBox.toggleDialogText(false);
        battleDialogueBox.toggleActions(false);
        battleDialogueBox.toggleMovments(true);
    }

    void EnemyAction()
    {
        
    }

    private void Update()
    {
        timeSinceLastClick += Time.deltaTime;
        
        if (state == BattleState.PlayerSelecAction)
        {
            HandlePlayerActionSelection();
        }
    }

    private int currentSelectedAction;
    
    private float timeSinceLastClick;
    public float timeBetweenClick = 1.0f;
    void HandlePlayerActionSelection()
    {
        if (timeSinceLastClick < timeBetweenClick)
        {
            return;
        }
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            timeSinceLastClick = 0;

            currentSelectedAction = (currentSelectedAction+1) % 2;
            
            battleDialogueBox.SelectAction(currentSelectedAction);
        }

        if (Input.GetAxisRaw("Submit") != 0)
        {
            timeSinceLastClick = 0;
            if (currentSelectedAction == 0)
            {
               PlayerMovment();
            }else if(currentSelectedAction == 1)
            {
              //TODO:implemenar huida  
            }
            
        }
        

        
    }
}
