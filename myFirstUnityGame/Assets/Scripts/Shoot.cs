using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public KeyCode shootKey = KeyCode.LeftControl; 
    public GameObject prefab; 
    public float delay = 0.5f; 

    void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            CallShot();
        }
    }

    public void CallShot()
    {
        StartCoroutine(AwaitDelay(delay));
    }

    private IEnumerator AwaitDelay(float time)
    {
        yield return new WaitForSeconds(time);
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        if (prefab != null)
        {
            GameObject projectile = Instantiate(prefab, transform.position , transform.rotation);


            Destroy(projectile, 3f);
        }
        else
        {
            Debug.LogWarning("Prefab niet ingesteld in de inspector!");
        }
    }
}
