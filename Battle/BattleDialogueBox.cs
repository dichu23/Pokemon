using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogueBox : MonoBehaviour
{
    [SerializeField] Text dialogueText;

    [SerializeField] GameObject actionSelect;
    
    [SerializeField] GameObject movmentSelect;

    [SerializeField] GameObject movmentDesc;

    
    [SerializeField] private List<Text> actionTexts;
    [SerializeField] private List<Text> movementTexts;

    [SerializeField] private Text ppText;
    [SerializeField] private Text typeText;
    


    public float charactersPerSecond = 10.0f;
    
    [SerializeField] Color selectedColor = Color.blue;

    public IEnumerator SetDialogue(string message)
    {
        dialogueText.text = "";
        foreach (var character in message)
        {
            dialogueText.text += character;
            yield return new WaitForSeconds(1/charactersPerSecond);
        }
    }

    public void toggleDialogText(bool activated)
    {
        dialogueText.enabled = activated;
    }

    public void toggleActions(bool activated)
    {
        actionSelect.SetActive(activated);
    }

    public void toggleMovments(bool activated)
    {
        movmentSelect.SetActive(activated);
        movmentDesc.SetActive(activated);
    }

    public void SelectAction(int selectedAction)
    {
        for (int i = 0; i < actionTexts.Count; i++)
        {
            if (i == selectedAction)
            {
                actionTexts[i].color = selectedColor;
            }
            else
            {
                actionTexts[i].color = Color.black;
            }
        }
    }

    public void SetPokemonMovments(List<Move> moves)
    {
        for (int i = 0; i < movementTexts.Count; i++)
        {
            if (i < moves.Count)
            {
                movementTexts[i].text = moves[i].Base.Name;
            }
            else
            {
                movementTexts[i].text = "---";
            }
        }
    }
    
}
