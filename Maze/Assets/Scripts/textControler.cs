using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textControler : MonoBehaviour
{
    public TMP_Text fairy;
    public GameObject textButton,Fairy1, Fairy2, Queen, QueenTarget,fountain, endposition;
    public int textNum;

    public bool spaceText;

    public string[] fairytext;

    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(textNum == 15 || textNum == 25 || textNum == 38 )
        {
            Fairy1.SetActive(false);
            Fairy2.SetActive(false);
            
            fairy.enabled = false;
            textButton.SetActive(false);
            GetComponent<playerActions>().canMove = true;
            GetComponent<playerActions>().camMove = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if(textNum == 38)
            {
                GetComponent<PlayerBall>().canShoot = true;
            }
            
            
        }
        else
        {
            fairy.enabled = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            
            if(textNum < 39)
            {
                Fairy1.SetActive(true);
                Fairy2.SetActive(true);
                textButton.SetActive(true);

                if(textNum < 26)
                {
                    transform.LookAt(Fairy1.transform);
                }
                else if(textNum >= 26 || textNum < 39)
                {
                    transform.LookAt(Fairy2.transform);
                }
            }

            else if(textNum >= 39)
            {
                transform.position = endposition.transform.position;
                Fairy1.SetActive(false);
                Fairy2.SetActive(false);
                GetComponent<PlayerBall>().canShoot = false;
                Queen.SetActive(true);
                fountain.SetActive(true);
                transform.LookAt(QueenTarget.transform);
                fairy.enabled = true;
                spaceText = true;
                
                
            }
            
            GetComponent<playerActions>().canMove = false;
            GetComponent<playerActions>().camMove = false;
        }
        fairy.text = fairytext[textNum];

        if(spaceText)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                if(textNum < 42)
                {
                    nextText();
                }
            }
        }
    }

    public void nextText()
    {
        textNum++;
    }

    public IEnumerator ending()
    {
        yield return new WaitForSeconds(2f);
        

        StopCoroutine(ending());
    }
}
