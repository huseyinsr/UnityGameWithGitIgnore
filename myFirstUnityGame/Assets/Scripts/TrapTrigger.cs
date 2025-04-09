using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public GameObject ps;          // Particle System prefab
    public float force = 200f;     // Explosiekracht

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
  
            Rigidbody rb = other.GetComponent<Rigidbody>();
            Transform t = other.transform;


            rb.constraints = RigidbodyConstraints.None;

         
            rb.AddExplosionForce(force, new Vector3(t.position.x, t.position.y + 1f, t.position.z - 1f), 0f);

          
            MoveBasic mbScript = other.GetComponentInChildren<MoveBasic>();
            if (mbScript != null)
            {
                mbScript.enabled = false;
            }

          
            GameObject p = Instantiate(ps, transform);
            p.transform.position = t.position;

           
            Destroy(p, 1f);
        }
    }
}
