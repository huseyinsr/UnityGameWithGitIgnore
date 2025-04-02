using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject prefab; // Sleep hier je bullet prefab in via de Unity Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) // Controleert of de linker Ctrl-toets wordt ingedrukt
        {
            GameObject ob = Instantiate(prefab); // Instantiate de kogel prefab
           
            ob.transform.rotation = transform.rotation; // Zet de rotatie gelijk aan de speler
            ob.transform.position = transform.position + transform.forward; // Zet de positie gelijk aan de speler

            Destroy(ob, 3f); // Verwijder de kogel na 3 seconden
        }
    }
}