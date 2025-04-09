using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // De speler die gevolgd moet worden
    public Vector3 offset = new Vector3(0, 5, -10); // Afstand tussen camera en speler
    public float smoothSpeed = 5f; // Hoe vloeiend de camera beweegt

    void LateUpdate()
    {
        if (target == null) return;

        // Bereken de gewenste positie van de camera
        Vector3 desiredPosition = target.position + offset;

        // Vloeiende beweging naar de gewenste positie
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Optioneel: Camera altijd naar de speler laten kijken
        transform.LookAt(target);
    }
}
