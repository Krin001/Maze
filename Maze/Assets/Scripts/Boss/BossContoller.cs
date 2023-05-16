using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossContoller : MonoBehaviour
{
    public Transform target;

    

    void Start()
    {
        
    }


    void FixedUpdate()
    {
        
    
        if(target != null)
        {
            transform.LookAt(target);
        }

        

    }
    
}
