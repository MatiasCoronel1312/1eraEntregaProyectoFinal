using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mision1 : MonoBehaviour
{
    [SerializeField] GameObject walkieTalkie;
    [SerializeField] GameObject walkieTalkie_UI;
    [SerializeField] GameObject enterPanel;
    private bool isPlayerInRange=false;
    private bool haveHandy=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return))&&(isPlayerInRange))
        {
            walkieTalkie.SetActive(false);
            walkieTalkie_UI.SetActive(true);
            enterPanel.SetActive(false);
            haveHandy=true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")){
            if(!haveHandy)
            {
                isPlayerInRange=true;
            }
            enterPanel.SetActive(true);

        }
    
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")){
            isPlayerInRange=false;
            enterPanel.SetActive(false);

        }
    }
}
