using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMovementSpeed : MonoBehaviour
{
    [SerializeField] float addMovementSpeed = 5f;
    [SerializeField] float timeMovement = 5f;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            PlayerMovement playerMovement = collider.gameObject.GetComponent<PlayerMovement>();
            gameManager.PlayerPowerMovementSpeed(playerMovement, addMovementSpeed, timeMovement);
            Destroy(transform.parent.gameObject);
        }
    }
}
