using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthManager : MonoBehaviour
{
    // Start is called before the first frame update
    const float MAXHEALTH = 100f;
    float health;
    public Slider healthSlider;

    void Start()
    {
        health = MAXHEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            health = 0;
            Die();
        }
        healthSlider.value = health / MAXHEALTH;


            GetComponent<AudioSource>().Play();
        

    }
    public void healDamage(float amount)
    {
        if(health < 100)
        {
          health += amount;
        }
        healthSlider.value = health / MAXHEALTH;

        if (health < 100)
        {
            health = 30;
        }
        healthSlider.value = health / MAXHEALTH;
    }

    void Die()
    {
        GetComponent<CharacterController2D>().enabled = false;
        

        GetComponent<Animator>().SetBool("Dead", true);
        GetComponent<Animator>().SetBool("jumping", false);
        GetComponent<Animator>().SetBool("running", false);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
