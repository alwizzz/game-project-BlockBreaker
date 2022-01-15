using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameStatus : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 10f)] private float gameSpeed = 1f;
    [SerializeField] private int pointsPerBlock = 100;
    [SerializeField] private int currentScore = 0;
    public bool autoPilot;

    // cached ref
    private Canvas gameCanvas;
    private Text scoreText;

    void Awake()
    {
        int thisScriptCount = FindObjectsOfType<GameStatus>().Length;

        if (thisScriptCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        gameCanvas = FindObjectOfType<Canvas>();
        scoreText = gameCanvas.transform.Find("ScoreText").GetComponent<Text>();
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    public void AddPointToScore()
    {
        currentScore += pointsPerBlock;
        scoreText.text = currentScore.ToString();
    }  

    public void ResetGame()
    {
        Destroy(gameObject);
    }
    
}
