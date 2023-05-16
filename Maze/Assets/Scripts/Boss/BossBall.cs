using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBall : MonoBehaviour
{
    public GameObject snBall,throw1,throw2;

    public int rand;

    public Vector3[] ball;

    public GameObject Right1, Right2, Left1, Left2;

    // Start is called before the first frame update
    void Start()
    {
        ball[0]= throw1.transform.position;
        ball[1] = throw2.transform.position;

        StartCoroutine(attack());
    }

    // Update is called once per frame
    void Update()
    {
        ball[0]= throw1.transform.position;
        ball[1] = throw2.transform.position;
        rand = Random.Range(0,2);
        
    
        
    }

    public IEnumerator attack()
    {
        int throwSide = rand;

        if(rand == 0)
        {
            Right1.GetComponent<Animator>().SetBool("throw", true);
            Right2.GetComponent<Animator>().SetBool("throw", true);
        }
        else
        {
            Left1.GetComponent<Animator>().SetBool("throw", true);
            Left2.GetComponent<Animator>().SetBool("throw", true);
        }
        yield return new WaitForSeconds(1f);
        Instantiate(snBall, ball[throwSide], Quaternion.identity);
        Right1.GetComponent<Animator>().SetBool("throw", false);
        Right2.GetComponent<Animator>().SetBool("throw", false);
        Left1.GetComponent<Animator>().SetBool("throw", false);
        Left2.GetComponent<Animator>().SetBool("throw", false);
        
        yield return new WaitForSeconds(1f);

        
    }

    public void strike()
    {
        rand = Random.Range(0,2);
        Instantiate(snBall, ball[rand], Quaternion.identity);
        StartCoroutine(attack());
    }


}
