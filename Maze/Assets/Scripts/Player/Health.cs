using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    

    public  int health = 20;

    public TMP_Text healthText;

    void Start()
    {
        healthText.text = "Health: " + health;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnCollisionEnter(Collision enemy)
    {
        if(enemy.gameObject.name == "Baddie")
        {
            damage();
        }
    }

    public void damage()
    {
        health--;
        healthText.text = "Health: " + health;
    }
}
