using UnityEngine;

public class UltimateScript : MonoBehaviour
{
    public GameObject target, carhorn, healing;
    public float timer = 0;
    public float despawnTime = 10;
    private bool helped = false;
    private GameObject score;
    private ScoreText scoreText;
    void Start()
    {
        Destroy(gameObject, despawnTime);
        transform.LookAt(target.transform.position);
        score = GameObject.Find("ScoreText");
        scoreText = score.GetComponent<ScoreText>();
    }

    void Update()
    {
        Move();
    }

    void FixedUpdate()
    {
        if(gameObject.name.Contains("Food"))
        {
            timer += Time.deltaTime;
            if(timer > 5)
            {
                Hello();
            }
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 9*Time.deltaTime);
    }

    private void Hello()
    {
        if(helped == false)
        {
            Instantiate(carhorn);
            Instantiate(healing, transform.position, Quaternion.identity);
            helped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Animal"))
        {
            Destroy(other.gameObject);
        }
        scoreText.Score(1);
    }
}
