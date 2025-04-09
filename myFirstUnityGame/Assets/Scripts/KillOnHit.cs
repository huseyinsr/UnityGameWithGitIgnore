using UnityEngine;

public class KillOnHit : MonoBehaviour
{
    public string targetTag; // Tag van het object dat vernietigd kan worden
    public GameObject effect; // Explosie effect prefab
    private AudioSource audioSource;
    private Hearts heartsScript; // Referentie naar het Hearts-script

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision coll)
    {
        HandleHit(coll.gameObject);
    }

    private void OnTriggerEnter(Collider coll)
    {
        HandleHit(coll.gameObject);
    }

    private void HandleHit(GameObject other)
    {
        if (other.CompareTag(targetTag))
        {
            // Explosie effect instantiëren
            if (effect != null)
            {
                GameObject expl = Instantiate(effect, other.transform.position, Quaternion.identity);
                Destroy(expl, 2f);
            }

            // Controle of het doelwit de speler is
            if (targetTag == "Player")
            {
                if (heartsScript == null)
                {
                    heartsScript = FindObjectOfType<Hearts>();
                }

                if (heartsScript != null)
                {
                    heartsScript.Lives--; // Leven verwijderen

                    // Controleer of de speler geen levens meer heeft
                    if (heartsScript.Lives <= 0)
                    {
                        Destroy(other, 0.1f);
                    }
                }
                else
                {
                    Debug.LogWarning("Hearts script niet gevonden! Zorg dat het in de scene aanwezig is.");
                }
            }
            else
            {
                Destroy(other, 0.1f);
            }

            // Speel geluid af indien aanwezig
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
