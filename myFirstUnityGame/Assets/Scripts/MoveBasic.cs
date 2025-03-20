using UnityEngine;

public class MoveBasic : MonoBehaviour
{
    [SerializeField] private float speed = 50f;      // Beweeg snelheid
    [SerializeField] private float rotSpeed = 50f;   // Rotatie snelheid

    void Update()
    {
        // Bereken de nieuwe positie
        Vector3 positionUpdate = transform.position + Input.GetAxis("Vertical") * transform.forward * speed * Time.deltaTime;

        // Pas de nieuwe positie toe
        transform.position = positionUpdate;

        // Rotatie berekening en toepassing
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime, 0));
    }
}
