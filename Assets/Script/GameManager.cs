using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Player player;
    private Invaders invaders;
    private RandomInvader randomInvader;
    private Base[] bases;

    [Header("UI Settings")]
    [SerializeField] private TMP_Text _livesText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private GameObject _gameOverUI;

    private int score;
    private int lives;


    private void Awake()
    {
        player = FindObjectOfType<Player>();
        invaders = FindObjectOfType<Invaders>();
        randomInvader = FindObjectOfType<RandomInvader>();
        bases = FindObjectsOfType<Base>();
    }

    private void Start()
    {
        player.damaged += OnPlayerKilled;
        invaders.killed += OnInvaderKilled;
        randomInvader.killed += OnRandomInvaderKilled;

        NewGame();
    }

    private void Update()
    {
        if (lives > 0 && invaders.InvadersCheck() == true && randomInvader.GetKilled() == true) NewRound();
    }

    private void NewRound()
    {
        invaders.ResetInvaders();
        randomInvader.ResetSpawn();
    }

    public void NewGame()
    {
        lives = player.lives;
        score = 0;
        SetLivesText();
        SetScore();
        _gameOverUI.SetActive(false);
        Time.timeScale = 1;

        NewRound();
    }

    private void SetScore()
    {
        _scoreText.text = score.ToString();
    }
    private void SetLivesText()
    {
        _livesText.text = "x " + lives.ToString();
    }

    private void OnInvaderKilled(Invader invader)
    {
        score += invader.GetPoints();
        SetScore();
    }

    private void OnRandomInvaderKilled()
    {
        score += randomInvader.GetPoint();
        SetScore();
    }

    private void OnPlayerKilled()
    {
        lives--;
        SetLivesText();

        if(lives <= 0)
        {
            Time.timeScale = 0;
            _gameOverUI.SetActive(true);
        }
    }
}
