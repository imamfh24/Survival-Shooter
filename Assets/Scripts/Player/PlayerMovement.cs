using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    const string FLOOR = "Floor";

    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;

    private void Awake()
    {
        // Mendapatkan ilai mask dari layer yang bernama Floor
        floorMask = LayerMask.GetMask(FLOOR);

        // Mendapatkan komponen animator
        anim = GetComponent<Animator>();

        // Mendaptkan komponen Rigidbody
        playerRigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Mendapatkan nilai input horizontal (-1, 0, 1)
        float h = Input.GetAxisRaw("Horizontal");
        /*Debug.Log("h: " + h);*/
        //Mendapatkan nilai input vertical(-1, 0, 1)
        float v = Input.GetAxisRaw("Vertical");
        /*Debug.Log("v: " + h);*/
        Move(h, v);
        Turning();
        Animating(h, v);
    }

    private void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }

    private void Turning()
    {
        //Buat Ray dari posisi mouse di layar
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Buat raycast untuk floorHit;
        RaycastHit floorHit;

        //Lakukan raycast
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            //Mendapatkan vector dari posisi player dan posisi floorHit
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            //Mendapatkan look rotation baru ke hit position
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            //Rotasi player
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    private void Move(float h, float v)
    {
        //Set nilai x dan y
        movement.Set(h, 0f, v);

        //Menormalisasi nilai vector agar total panjang dari vector adalah 1
        movement = movement.normalized * speed * Time.deltaTime;

        /*Debug.Log(movement);*/

        //Move to position
        playerRigidbody.MovePosition(transform.position + movement);
    }
}
