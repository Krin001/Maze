using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayAtta : MonoBehaviour
{
    public GameObject Boss,targ;

    public float speed = 25f;

    public BossHealth bh;

    private CharacterController CharCon;

    




    // Start is called before the first frame update
    void Start()
    {
        Boss = GameObject.FindWithTag("Baddie");
        targ = GameObject.Find("Target");
        
        CharCon = GetComponent<CharacterController>();
        
        bh = Boss.GetComponent<BossHealth>();
        
        if(targ != null)
        {
            transform.LookAt(targ.transform);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = transform.forward * 1;

        CharCon.Move(movement * speed * Time.smoothDeltaTime);

        
        
        
    }


    void OnTriggerEnter(Collider hit)
    {
        if(hit.tag == "Baddie")
        {
            bh.health--;
            bh.flashing();
            Destroy(gameObject);
            
        }

        if(hit.tag == "Wall" || hit.tag == "Ground")
        {
            Destroy(gameObject);

        }
    }

    
}