using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    int score;
    public Text scoretext;
    // Start is called before the first frame update
    void Start()
    {
    }
     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "coin")
        {
            score++;
            Destroy(col.gameObject);
            scoretext.text = score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    
    { 
        if (score > PlayerPrefs.GetInt("Highscore"))
        {
            PlayerPrefs.SetInt("Highscore", score);

        }
        PlayerPrefs.SetInt("savedscore", score);
        
    }
   

}
