using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour// script de cuadro de dialogos 
{

    [SerializeField] private GameObject dialoguePanel;// el panel
    [SerializeField] private TMP_Text dialogueText;//y el texto
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    [SerializeField] private float typingTime = 0.05f;
    private bool isPlayerInRange = false;
    private bool didDialogueStart;
    private int lineIndex;

    private void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Return)) && (isPlayerInRange))//cuando esta en el rango y se apreta Enter
        {
            if (!didDialogueStart)// se pregunta primero si no arranco ya el dialogo
            {
                StartDialogue();//entonces se muestar la primera linea
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine();//sino la proxima
            }
            else
            {
                StopAllCoroutines();//sino se detiene
                dialogueText.text = dialogueLines[lineIndex];
            }
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            dialoguePanel.SetActive(false);
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;
        foreach (char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialoguePanel.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;

        }
    }

}
