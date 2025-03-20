using UnityEngine;

public class Animate : MonoBehaviour
{
    private Animator ani;
    private float lastInput = 0f; // Houdt de vorige invoer bij om onnodige updates te vermijden

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        // Controleer of de invoer is veranderd om onnodige SetTrigger-aanroepen te voorkomen
        if (!Mathf.Approximately(verticalInput, lastInput))
        {
            if (verticalInput > 0)
            {
                ani.SetTrigger("Walk");
                ani.ResetTrigger("Idle");
                ani.ResetTrigger("WalkR");
            }
            else if (verticalInput < 0)
            {
                ani.SetTrigger("WalkR");
                ani.ResetTrigger("Idle");
                ani.ResetTrigger("Walk");
            }
            else
            {
                ani.SetTrigger("Idle");
                ani.ResetTrigger("Walk");
                ani.ResetTrigger("WalkR");
            }

            lastInput = verticalInput; // Sla de laatste invoer op
        }
    }
}
