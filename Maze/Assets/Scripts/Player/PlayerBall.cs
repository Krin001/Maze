using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public GameObject snBall;

    public Vector3 ball;

    public bool coolDn, canShoot;

    // Start is called before the first frame update
    void Start()
    {
        ball = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(canShoot)
        {
            if(coolDn == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ball = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
                    Instantiate(snBall, ball, Quaternion.identity);
                    StartCoroutine(coolDown());
                }
            }
        }
        
        
        
    }

    public IEnumerator coolDown()
    {
        coolDn = true;

        yield return new WaitForSeconds(.5f);

        coolDn = false;

        StopCoroutine(coolDown());
    }


}
