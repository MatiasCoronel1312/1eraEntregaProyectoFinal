using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LastMision : MonoBehaviour
{
    [SerializeField] private GameObject DetonatorActivate;
    [SerializeField] private GameObject DetonaterOneMinute;
    [SerializeField] private GameObject DetonatorDesactivate;
    [SerializeField] private GameObject keyCard;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject ActivateMusica;
    [SerializeField] private GameObject ActivateTimer;
    [SerializeField] private GameObject Final;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;
    [SerializeField] private float typingTime = 0.05f;
    [SerializeField] private float activateTime = 1f;
    private SoundManagerPlayer soundManager;
    private bool isPlayerInRange=false;
    private bool isPlayerToActivate=false;
    private bool DeciditionActivate=false;
    
    private bool didDialogueStart;
    private int lineIndex;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManagerPlayer>();
    }

    private void Update() {

        if ((Input.GetKeyDown(KeyCode.Return)) && (isPlayerInRange))
        {
            if(!DeciditionActivate)
            {
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
            }else{
                StartCoroutine(ActivateBomb());
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
        }
        else
        {
            didDialogueStart=false;
            dialoguePanel.SetActive(false);
        }
        if(dialogueLines[lineIndex]== dialogueLines[8])
        {
            StartCoroutine(ShowActive());
        }else if(dialogueLines[lineIndex]== dialogueLines[9])
        {
            StartCoroutine(ShowDesactive());
        }else if(dialogueLines[lineIndex]== dialogueLines[10])
        {
            StartCoroutine(ShowDesactive());
        }else if(dialogueLines[lineIndex]== dialogueLines[13])
        {
            DeciditionActivate=true;
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
    private IEnumerator ShowActive()
    {
        isPlayerInRange=false;
        keyCard.SetActive(false);
        yield return new WaitForSeconds(activateTime);
        button1.SetActive(true);
        soundManager.SeleccionAudio(7, 0.2f);
        yield return new WaitForSeconds(activateTime);
        button2.SetActive(true);
        soundManager.SeleccionAudio(7, 0.2f);
        yield return new WaitForSeconds(activateTime);
        button3.SetActive(true);
        soundManager.SeleccionAudio(7, 0.2f);
        isPlayerInRange=true;
        
    }
        private IEnumerator ShowDesactive()
    {
        isPlayerInRange=false;
        yield return new WaitForSeconds(activateTime);
        DetonatorDesactivate.SetActive(false);
        button3.SetActive(true);
        DetonaterOneMinute.SetActive(true);
        yield return new WaitForSeconds(activateTime);
        DetonatorDesactivate.SetActive(true);
        button3.SetActive(false);
        DetonaterOneMinute.SetActive(false);
        yield return new WaitForSeconds(activateTime);
        DetonatorDesactivate.SetActive(false);
        button3.SetActive(true);
        DetonaterOneMinute.SetActive(true);
        yield return new WaitForSeconds(activateTime);
        DetonatorDesactivate.SetActive(true);
        button3.SetActive(false);
        DetonaterOneMinute.SetActive(false);
        yield return new WaitForSeconds(activateTime);
        DetonatorDesactivate.SetActive(false);
        button3.SetActive(true);
        DetonaterOneMinute.SetActive(true);
        isPlayerInRange=true;
        
    }

    private IEnumerator ActivateBomb()
    {
        isPlayerInRange=false;
        dialoguePanel.SetActive(false);
        DetonaterOneMinute.SetActive(false);
        DetonatorActivate.SetActive(true);
        soundManager.SeleccionAudio(7, 0.2f);
        yield return new WaitForSeconds(activateTime);
        ActivateMusica.SetActive(true);
        ActivateTimer.SetActive(true);        
        yield return new WaitForSeconds(60f);
        ActivateMusica.SetActive(false);
        ActivateTimer.SetActive(false);
        yield return new WaitForSeconds(2f);
        Final.SetActive(true);        
        
        
    }


    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")){
            isPlayerInRange=true;
            dialoguePanel.SetActive(true);
        }
    
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")){
            isPlayerInRange=false;

        }
    }
}
