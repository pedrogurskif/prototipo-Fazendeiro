using UnityEngine;

public class CookieScript : MonoBehaviour
{
    private GameObject player;
    private PlayerController2 playerCode;

    void Start()
    {
        player = GameObject.Find("Player");
        playerCode = player.GetComponent<PlayerController2>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 15*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerCode.Heal();
            Destroy(gameObject);
        }
    }
}
