using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LastMision : MonoBehaviour//ultima mision
{
    [SerializeField] private GameObject DetonatorActivate;//game object que se activan y se desactivan
    [SerializeField] private GameObject DetonaterOneMinute;//detonadores, luces, tarjetas
    [SerializeField] private GameObject DetonatorDesactivate;
    [SerializeField] private GameObject keyCard;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject Obituary;// musica anterior para que no se pise con la nueva
    [SerializeField] private GameObject ActivateMusica;// musica del final
    [SerializeField] private GameObject ActivateTimer;// el timer del final
    [SerializeField] private GameObject Final;// y el video final
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;//array de string para el cuadro de dialogo
    [SerializeField] private float typingTime = 0.05f;//tiempo de tipeo para que coincida con la secuencia
    [SerializeField] private float activateTime = 1f;//tiempo de secuencia de tiempo de activacion 
    public PlayerCollision lifePlayer;
    private SoundManagerPlayer soundManager;
    private bool isPlayerInRange = false;
    private bool DeciditionActivate = false;//caundo llego al ultimo dailogo se desactiva y solo queda el final

    private bool didDialogueStart;
    private int lineIndex;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManagerPlayer>();
    }

    private void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Return)) && (isPlayerInRange))
        {

            if (!DeciditionActivate)
            {
                if (!didDialogueStart)
                {
                    StartDialogue();
                }
                else if (dialogueText.text == dialogueLines[lineIndex])
                {
                    NextDialogueLine();
                }
                else
                {
                    StopAllCoroutines();
                    dialogueText.text = dialogueLines[lineIndex];
                }
            }
            else
            {
                StartCoroutine(ActivateBomb());
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
        if (dialogueLines[lineIndex] == dialogueLines[8])
        {
            StartCoroutine(ShowActive());//segun la linea del dialogo se activa la secuencia de activavion
        }
        else if (dialogueLines[lineIndex] == dialogueLines[9])
        {
            StartCoroutine(ShowDesactive());
        }
        else if (dialogueLines[lineIndex] == dialogueLines[10])
        {
            StartCoroutine(ShowDesactive());
        }
        else if (dialogueLines[lineIndex] == dialogueLines[13])
        {
            DeciditionActivate = true;
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
    private IEnumerator ShowActive()
    {
        isPlayerInRange = false;
        keyCard.SetActive(false);
        yield return new WaitForSeconds(activateTime);
        button1.SetActive(true);
        soundManager.SeleccionAudio(7, 0.4f);
        yield return new WaitForSeconds(activateTime);
        button2.SetActive(true);
        soundManager.SeleccionAudio(7, 0.4f);
        yield return new WaitForSeconds(activateTime);
        button3.SetActive(true);
        soundManager.SeleccionAudio(7, 0.4f);
        isPlayerInRange = true;

    }
    private IEnumerator ShowDesactive()
    {
        isPlayerInRange = false;
        yield return new WaitForSeconds(activateTime);
        DetonatorDesactivate.SetActive(false);
        button3.SetActive(true);
        DetonaterOneMinute.SetActive(true);
        yield return new WaitForSeconds(activateTime);
        soundManager.SeleccionAudio(8, 0.2f);
        DetonatorDesactivate.SetActive(true);
        button3.SetActive(false);
        DetonaterOneMinute.SetActive(false);
        yield return new WaitForSeconds(activateTime);
        DetonatorDesactivate.SetActive(false);
        button3.SetActive(true);
        DetonaterOneMinute.SetActive(true);
        yield return new WaitForSeconds(activateTime);
        soundManager.SeleccionAudio(8, 0.2f);
        DetonatorDesactivate.SetActive(true);
        button3.SetActive(false);
        DetonaterOneMinute.SetActive(false);
        yield return new WaitForSeconds(activateTime);
        DetonatorDesactivate.SetActive(false);
        button3.SetActive(true);
        DetonaterOneMinute.SetActive(true);
        isPlayerInRange = true;

    }

    private IEnumerator ActivateBomb()//corrutina final
    {
        lifePlayer.lifeDamage = false;//el player deja de perder vida
        isPlayerInRange = false;//se desactiva el dialogo
        dialoguePanel.SetActive(false);//el panel
        DetonaterOneMinute.SetActive(false);
        DetonatorActivate.SetActive(true);//sonido y "detonador activado"
        soundManager.SeleccionAudio(7, 0.5f);        
        yield return new WaitForSeconds(activateTime);
        ActivateMusica.SetActive(true);
        ActivateTimer.SetActive(true);//se inicia la musica y el timer fianl
        yield return new WaitForSeconds(60f);
        ActivateMusica.SetActive(false);
        ActivateTimer.SetActive(false);//60 segundos despues se desactiva todo
        yield return new WaitForSeconds(2f);//y se inicia el video final
        Final.SetActive(true);
        yield return new WaitForSeconds(51f);
        //Application.Quit();
        SceneManager.LoadScene("Main");
        Debug.Log("Salir");


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialoguePanel.SetActive(true);
            Obituary.SetActive(false);
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
