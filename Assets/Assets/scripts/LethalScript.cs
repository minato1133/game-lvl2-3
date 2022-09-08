using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LethalScript : MonoBehaviour
{
    // Start is called before the first frame update
    
        public bool push;
        public float force = 300f;
        public float damage = 10f;
       
    
    void Start()
    {
        
    }
 private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
                if (push)
                {
                    Vector2 pushDirection = collision.transform.position - transform.position;
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(pushDirection.normalized * force);
                }
            }
        }
    // Update is called once per frame
    void Update()
    {
        
    }
}
