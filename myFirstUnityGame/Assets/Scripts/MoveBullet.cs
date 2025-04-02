using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed = 500f; // Snelheid van de kogel
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Haal de Rigidbody op bij het starten
    }

    void FixedUpdate()
    {
        rb.linearVelocity = rb.transform.forward * speed * Time.fixedDeltaTime; // Beweeg de kogel vooruit
    }
}
