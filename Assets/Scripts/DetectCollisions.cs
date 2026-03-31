using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public GameObject farmer;
    private PlayerController2 player;
    void Start()
    {
        player = farmer.GetComponent<PlayerController2>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Animal")
        {
            if(gameObject.name.Contains("Pizza"))
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
            if(gameObject.tag == "Player")
            {
                player.Health(-1);
            }
        }
        
    }
}
