using UnityEngine;

public class UltimateScript : MonoBehaviour
{
    public GameObject target, carhorn, healing;
    public float timer = 0;
    private int help = 0;
    private GameObject score;
    private ScoreText scoreText;
    void Start()
    {
        Destroy(gameObject, 10);
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
        if(help < 1)
        {
            Instantiate(carhorn);
            Instantiate(healing, transform.position, Quaternion.identity);
            help++;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Animal")
        {
            Destroy(other.gameObject);
        }
        scoreText.Score(1);
    }
}
