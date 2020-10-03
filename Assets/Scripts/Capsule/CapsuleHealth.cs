using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleHealth : MonoBehaviour
{
    [SerializeField] int addHealth = 100;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
            playerHealth.AddHealth(addHealth);
            Destroy(transform.parent.gameObject);
        }
    }
}
