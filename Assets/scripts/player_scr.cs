using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class player_scr : NetworkBehaviour {

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float RotateSpeed = 30f;
    public float bullet_speed = 5.0f;


    private Vector3 moveDirection = Vector3.back;
    //CharacterController controller;
    //Rigidbody rb;
    public GameObject bullet_obj;
    public Transform bullet_spawn;


    private void Start()
    {
        //controller = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        float x = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            //if (controller.isGrounded)
                //controller.Move(Vector3.back * Time.deltaTime);
                /*moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical")); //Input.GetAxis("Horizontal")
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;*/


                //transform.Rotate(0,1,0);
                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;

            


        

        if (Input.GetKeyDown(KeyCode.F))
        {
            CmdFire();
        }
        /*moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);*/

        transform.Rotate(0, Input.GetAxis("Horizontal") * RotateSpeed, 0);
        transform.Translate(0, 0, x);
        
           
        
        
    }

    [Command]
    void CmdFire()
    {
        //create bullet
        GameObject bullet = (GameObject)Instantiate(bullet_obj, bullet_spawn.position, bullet_spawn.rotation);

        //configure the bullet velocity
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6.0f * bullet_speed;

        //network spawn
        NetworkServer.Spawn(bullet);

        //destroy bullet after 2 second
        Destroy(bullet, 2);

    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
