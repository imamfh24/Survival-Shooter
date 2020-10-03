using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void PlayerPowerMovementSpeed(PlayerMovement playerMovement, float addMovementSpeed, float timeMovement)
    {
        StartCoroutine(playerMovement.AddMovementSpeed(addMovementSpeed, timeMovement));
    }
}
