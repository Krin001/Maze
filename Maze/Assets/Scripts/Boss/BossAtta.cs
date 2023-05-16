using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BossAtta : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    public Health ph;

    public Vector3 pla;

    public float speed = 40f;

    private CharacterController CharCon;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        CharCon = GetComponent<CharacterController>();
        ph = player.GetComponent<Health>();
        target = player.GetComponent<Transform>();
        pla = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        if(target != null)
        {
            transform.LookAt(target);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = transform.forward * 1;

        CharCon.Move(movement * speed * Time.smoothDeltaTime);

        if(target != null)
        {
            transform.LookAt(target);
        }
    
    }

    void OnTriggerEnter(Collider hit)
    {
        if(hit.tag == "Player")
        {
            ph.damage();
            Destroy(gameObject);
        }

        if(hit.tag == "Wall" || hit.tag == "PlaySnow")
        {
            Destroy(gameObject);
        }
    }

    
}
