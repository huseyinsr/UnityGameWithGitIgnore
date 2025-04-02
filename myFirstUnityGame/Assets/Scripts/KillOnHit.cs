using UnityEngine;

public class KillOnHit : MonoBehaviour
{
    public string targetTag; // Tag van het object dat moet exploderen
    public GameObject effect; // Explosie effect prefab
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Controleer of de opgegeven tag bestaat
        bool tagFound = false;
        foreach (string tag in UnityEditorInternal.InternalEditorUtility.tags)
        {
            if (targetTag == tag)
            {
                tagFound = true;
                break;
            }
        }
        if (!tagFound)
        {
            Debug.LogError("TargetTag: " + targetTag + " for `KillOnHit` @ " + gameObject.name + " not found!");
        }
    }

    private void OnCollisionEnter(Collision coll)
    {       
        HandleCollision(coll.gameObject);
    }



    private void HandleCollision(GameObject other)
    {      
        if (other.tag == targetTag)
        {        
            GameObject expl = Instantiate(effect, transform.position, transform.rotation); // Instantieer explosie
            Destroy(expl, 2f); // Verwijder explosie na 2 seconden
            Destroy(other, 0.1f); // Verwijder geraakt object
            audioSource.Play(); // Speel explosie geluid af
        }
    }
}