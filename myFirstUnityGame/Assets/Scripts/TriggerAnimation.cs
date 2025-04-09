using UnityEngine;
using System.Collections;

public class TriggerAnimation : MonoBehaviour
{
    public string triggerName; 
    public float delay = 0f; 
    public float resetTime; 
    public KeyCode triggerKey = KeyCode.None; 
    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (animator == null)
        {
            Debug.LogWarning("Animator-component niet gevonden op " + gameObject.name);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(triggerKey))
        {
            CallTrigger();
        }
    }

    public void CallTrigger()
    {
        if (animator != null)
        {
            StartCoroutine(AwaitDelay(delay));
            StartCoroutine(AwaitReset(resetTime));
        }
        else
        {
            Debug.LogWarning("Geen Animator gevonden! Zorg dat er een Animator-component op dit object staat.");
        }
    }

    private IEnumerator AwaitDelay(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetTrigger(triggerName);
        if (audioSource != null) audioSource.Play();
    }

    private IEnumerator AwaitReset(float time)
    {
        yield return new WaitForSeconds(time);
        animator.ResetTrigger(triggerName);
    }
}
