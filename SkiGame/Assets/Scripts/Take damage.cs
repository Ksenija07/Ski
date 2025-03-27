using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takedamage : MonoBehaviour
{
    [SerializeField] private float stunTime = 1;
    [SerializeField] private float knockbackForce;
    [SerializeField] private float upwardsForce;

    private Rigidbody rb;
    public bool isHurt = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        PlayerEvents.onHit += TakingDamage;
    }

    private void OnDisable()
    {
        PlayerEvents.onHit -= TakingDamage;
    }

    private void TakingDamage()
    {
        if (rb != null)
        {
            rb.AddForce(knockbackForce * transform.forward);
            rb.AddForce(upwardsForce * transform.up);

        }
        isHurt = true;
        StartCoroutine(Recover());
        Debug.Log("Player taking damage!");
    }

    private IEnumerator Recover()
    {
        yield return new WaitForSeconds(stunTime);
        isHurt = false;
    }
}
