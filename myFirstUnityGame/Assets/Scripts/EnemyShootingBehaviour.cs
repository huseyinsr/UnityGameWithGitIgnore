using UnityEngine;
using System.Collections;

public class EnemyShootingBehaviour : MonoBehaviour
{
    public Transform target; // Doelwit (bijvoorbeeld de speler)
    public float shotRange = 10f; // Afstand waarop de vijand kan schieten
    public float coolDownTime = 2f; // Tijd tussen schoten
    private bool inCooldown = false; // Houdt bij of de vijand in cooldown is

    private Shoot shootScript;
    private TriggerAnimation triggerAnimationScript;

    void Start()
    {
        shootScript = GetComponentInChildren<Shoot>();
        Debug.Log("shootscript" + shootScript);

        triggerAnimationScript = GetComponentInChildren<TriggerAnimation>();

        if (target == null)
        {
            Debug.LogError("Target niet ingesteld voor " + gameObject.name);
        }
    }

    void Update()
    {
        if (target == null) return;

        // Vijand richt op de speler, maar blijft horizontaal
        Vector3 targetPos = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(targetPos);

        // Bereken afstand tot target
        Vector3 delta = transform.position - target.position;

        if (delta.magnitude < shotRange && !inCooldown)
        {
            shootScript.CallShot();
            triggerAnimationScript.CallTrigger();
            inCooldown = true;
            StartCoroutine(Cooldown(coolDownTime));
        }
    }

    private IEnumerator Cooldown(float time)
    {
        yield return new WaitForSeconds(time);
        inCooldown = false;
    }
}
