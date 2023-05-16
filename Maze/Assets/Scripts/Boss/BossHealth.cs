using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int health = 20;

    public GameObject bottom, middle, head, triforce;
    
    public MeshRenderer bo, mi, he;
    // Start is called before the first frame update
    void Start()
    {
        bo = bottom.GetComponent<MeshRenderer>();
        mi = middle.GetComponent<MeshRenderer>();
        he = head.GetComponent<MeshRenderer>();

        bo.enabled = false;
        mi.enabled = false;
        he.enabled = false;

        triforce.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            triforce.SetActive(true);
            Destroy(gameObject);

        }
        
    }

    public IEnumerator flash()
    {
        bo.enabled = false;
        mi.enabled = false;
        he.enabled = false;

        yield return new WaitForSeconds(.3f);

        bo.enabled = true;
        mi.enabled = true;
        he.enabled = true;

        yield return new WaitForSeconds(.3f);

        bo.enabled = false;
        mi.enabled = false;
        he.enabled = false;

        yield return new WaitForSeconds(.3f);

        bo.enabled = true;
        mi.enabled = true;
        he.enabled = true;

        yield return new WaitForSeconds(.3f);

        bo.enabled = false;
        mi.enabled = false;
        he.enabled = false;

        StopCoroutine(flash());
    }

    public void flashing()
    {
        StartCoroutine(flash());
    }

    

}

