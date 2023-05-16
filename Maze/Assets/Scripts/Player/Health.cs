using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
       if(health <= 0)
       {
            SceneManager.LoadScene("Maze");
       }
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
