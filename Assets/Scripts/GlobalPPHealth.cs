using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class GlobalPPHealth : MonoBehaviour
{
    private PostProcessVolume globalVolume;
    private ColorGrading colorEffect;
    public float timeEffect = 0.5f;
    private bool isRunDamage = false;




    private void Awake()
    {
        FindObjectOfType<PlayerCollision>().OnDamage += OnDamageEvent;
        globalVolume = GetComponent<PostProcessVolume>();
        globalVolume.profile.TryGetSettings(out colorEffect);


    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Damage()
    {
        isRunDamage = true;
        colorEffect.active = true;
        yield return new WaitForSeconds(timeEffect);

        colorEffect.active = false;
        isRunDamage = false;
    }

    public void OnDamageEvent()
    {
        if (!isRunDamage)
        {
            StartCoroutine(Damage());
        }
    }
}
