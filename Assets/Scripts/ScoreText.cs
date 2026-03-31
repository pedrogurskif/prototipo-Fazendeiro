using UnityEngine;
using TMPro;
public class ScoreText : MonoBehaviour
{
    private int points;
    [SerializeField] private TextMeshProUGUI scoreText;
    void Awake()
    {
        
    }

    public void Score(int score)
    {
        points += score;
        scoreText.text = "Pontos: " + points.ToString();
    }
}
