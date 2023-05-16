using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float time;
    public float change;
    public float xS, zS;
    public float speed = 0.1f;

    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        xS = Random.Range(-speed,speed);
        zS = Random.Range(-speed,speed);
    }


    void Update()
    {
       
        time++;
        if(time % 60 == 0)
        {
            change = Random.Range(0,1000);
        }

        if(time % change == 0)
        {
            xS = Random.Range(-speed,speed);
            zS = Random.Range(-speed,speed);
        }
        transform.position = new Vector3 (transform.position.x+xS, transform.position.y, transform.position.z+zS);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        

    }
}
