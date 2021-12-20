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
    
}
