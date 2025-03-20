using UnityEngine;

public class Animate : MonoBehaviour
{
    private Animator animator;
    private bool toggle = false; 

    void Start()
    {

        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (In
        {
          
            if (toggle)
            {
                animator.SetTrigger("Angry");
            }
            else
            {
                animator.SetTrigger("Catwalk Walk Forward HighKnees");
            }

            toggle = !toggle; 
        }
    }
}

