using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healingScript : MonoBehaviour
{
    public float heal = 30;
    
    // Start is called before the first frame update
    void Start()
    {


    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HealthManager>().healDamage(heal);
            transform.position = new Vector2(-4.31f, 1.96f);
            transform.localScale = new Vector2(0.0010f, 0.0010f);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
