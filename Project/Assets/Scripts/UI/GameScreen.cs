using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;

    public static GameScreen Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
        scoreText.text = "Score: " + score;
    }

    private float time;
    private float score;

    private void Update()
    {
        time += Time.deltaTime;
        int iTIme = (int)time;
        timeText.text = "Time: " + iTIme;
    }

    public void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score; 
    }
}
