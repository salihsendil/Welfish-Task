using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    int score = 0;

    public int Score { get => score; set => score = value; }

    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore(int addScore)
    {
        score += addScore;
    }
}
