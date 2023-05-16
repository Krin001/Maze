using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textControler : MonoBehaviour
{
    public TMP_Text fairy;
    public GameObject textButton,Fairy1, Fairy2, Queen, QueenTarget,fountain;
    public int textNum;

    public bool spaceText;

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
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Fairy1.SetActive(true);
            Fairy2.SetActive(true);
            if(textNum < 26)
            {
                transform.LookAt(Fairy1.transform);
            }
            else if(textNum >= 26 || textNum < 39)
            {
                transform.LookAt(Fairy2.transform);
            }
            else
            {
                GetComponent<PlayerBall>().canShoot = false;
                Queen.SetActive(true);
                fountain.SetActive(true);
                transform.LookAt(QueenTarget.transform);
            }
            
            if(textNum < 39)
            {
                fairy.enabled = true;
                textButton.SetActive(true);
            }

            
            
            GetComponent<playerActions>().canMove = false;
            GetComponent<playerActions>().camMove = false;
        }
        fairy.text = fairytext[textNum];

        if(spaceText)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                nextText();
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
        fairy.enabled = true;
        spaceText = true;

        StopCoroutine(ending());
    }
}
