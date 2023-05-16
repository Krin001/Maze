using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerActions : MonoBehaviour
{
    public Rigidbody rb;
    public float runSpeed;
    public float mouseSensitivity;
    
    public Camera cam;

    private Vector3 eulers;

    private CharacterController CharCon;


    /*public bool canJump;
    public bool jumping = false;
    public float jumpHeight = 20f;

    public float x,y,z;*/



    //SnowBalls

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CharCon = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //canJump = true;

        

        
    }

    // Update is called once per frame
    void Update()
    {
        /* x = transform.position.x;
         y = transform.position.y;
         z = transform.position.z;*/


        Keyboard keyboard = Keyboard.current;
        Mouse mouse = Mouse.current;

        float forwardA = 0;
        if(keyboard.wKey.isPressed)
        {
            forwardA = 1;
        }

        if(keyboard.sKey.isPressed)
        {
            forwardA = -1;
        }

        float rightA = 0;

        if(keyboard.dKey.isPressed)
        {
            rightA = 1;
        }

        if(keyboard.aKey.isPressed)
        {
            rightA = -1;
        }

        /*float upA = 0;

        if(transform.position.y > 5)
        {
            canJump = false;
            y = 5;
            transform.position = new Vector3(x,y,z);
            
        }

        if (transform.position.y < 1.08)
        {
            y = 1.08f;
            transform.position = new Vector3(x,y,z);
            //canJump = true;
        }
        
        

        if(Input.GetKey(KeyCode.Space))
        {
            jumping = true;
        }
         
        
        if(Input.GetKeyUp(KeyCode.Space))
        {
            
            canJump = false;
            jumping = false;
        }  

        
        
        
        if(jumping)
        {
            if(canJump)
            {
                upA = 1;
            }
            else
            {
                upA = -1;
            }
        }
        else
        {
            upA = -1;
        }
            
        
        if(!canJump)
        {
            upA = -1; 
        }*/
        
        

        

        
        

        

        Vector3 movement = transform.forward * forwardA + transform.right * rightA /*+ transform.up * upA*/;

        CharCon.Move(movement * runSpeed * Time.smoothDeltaTime);
        
        Vector2 dpos = mouse.delta.ReadValue();

        float dx = dpos.x;
        float dy = dpos.y;

        eulers[0] = Mathf.Clamp(eulers[0] - dy, -89, 89);
        eulers[1] = (eulers[1] + dx) % 360;
        
        cam.transform.localRotation = Quaternion.Euler(eulers[0], 0, 0);
        transform.rotation = Quaternion.Euler(0,eulers[1], 0);
    }

    

    

    

}
