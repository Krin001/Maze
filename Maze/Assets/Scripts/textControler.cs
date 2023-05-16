using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textControler : MonoBehaviour
{
    public TMP_Text fairy;
    public GameObject textButton,Fairy;
    public int textNum;

    public string[] fairytext;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(textNum == 15 || textNum == 25 || textNum == 38 )
        {
            
            fairy.enabled = false;
            textButton.SetActive(false);
            GetComponent<playerActions>().canMove = true;
            GetComponent<playerActions>().camMove = true;
        }
        else
        {
            transform.LookAt(Fairy.transform);
            fairy.enabled = true;
            textButton.SetActive(true);
            GetComponent<playerActions>().canMove = false;
            GetComponent<playerActions>().camMove = false;
        }
        fairy.text = fairytext[textNum];
    }

    public void nextText()
    {
        textNum++;
    }
}
