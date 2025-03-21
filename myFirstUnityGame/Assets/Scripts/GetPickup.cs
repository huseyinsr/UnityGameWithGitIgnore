using UnityEngine;

public class GetPickup : MonoBehaviour
{
    private Renderer r;
    private AudioSource source;
    private ParticleSystem ps;
    private KeepScore scoreScript;  

    void Start()
    {
        r = GetComponent<Renderer>();
        source = GetComponent<AudioSource>();
        ps = GetComponent<ParticleSystem>();
        ps.Stop();

        scoreScript = FindAnyObjectByType<KeepScore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            r.enabled = false;
            source.Play();
            ps.Play();


            if (scoreScript != null)
            {
                scoreScript.AddScore(5);
            }


            Destroy(gameObject, 0.5f);
        }
    }
}
