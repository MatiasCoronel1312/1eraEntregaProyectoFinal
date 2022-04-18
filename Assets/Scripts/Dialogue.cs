using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    //[SerializeField] private GameObject icon;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;
    [SerializeField] private float typingTime = 0.05f;
    private bool isPlayerInRange=false;
    private bool didDialogueStart;
    private int lineIndex;

    private void Update() {
        if(isPlayerInRange && (Input.GetKeyDown(KeyCode.Return)) ){
            if(!didDialogueStart)
            {
                StartDialogue();
            }
            else if(dialogueText.text == dialogueLines[lineIndex]) {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    private void StartDialogue(){
        didDialogueStart=true;
        dialoguePanel.SetActive(true);
        lineIndex=0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if(lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }else
        {
            didDialogueStart=false;
            dialoguePanel.SetActive(false);
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }

private void OnTriggerEnter(Collider other) {
    if (other.gameObject.CompareTag("Player")){
        isPlayerInRange=true;

    }
    
}

private void OnTriggerExit(Collider other) {
    if (other.gameObject.CompareTag("Player")){
        isPlayerInRange=false;

    }
}

}
