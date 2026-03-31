using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public GameObject farmer;
    private PlayerController2 player;
    private GameObject score;
    private ScoreText scoreText;
    void Start()
    {
        player = farmer.GetComponent<PlayerController2>();
        score = GameObject.Find("ScoreText");
        scoreText = score.GetComponent<ScoreText>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Animal")
        {
            if(gameObject.name.Contains("Pizza"))
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
                scoreText.Score(1);
            }
            if(gameObject.tag == "Player")
            {
                player.Health(-1);
                scoreText.Score(1);
                Destroy(other.gameObject);
            }
        }
        
    }
}
