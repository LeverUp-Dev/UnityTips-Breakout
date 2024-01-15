using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    int lives = 3;
    int bricks = 20;
    float resetDelay = 2f;
    GameObject clonePaddle;

    public Text livesText;
    public GameObject gameOverText;
    public GameObject youWinText;
    public GameObject bricksPrefab;
    public GameObject paddleBall;
    public GameObject deathParticles;

    void Start()
    {
        clonePaddle = Instantiate(paddleBall, transform.position, transform.rotation) as GameObject;
        Instantiate(bricksPrefab, transform.position, transform.rotation);
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = "Lives : " + lives;
        Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Invoke("SetupPaddle", resetDelay);

        if(lives < 1)
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0.2f;
            Invoke("Reset", resetDelay);
        }
    }

    public void DestroyBricks()
    {
        bricks--;
        if(bricks < 1)
        {
            youWinText.SetActive(true);
            Time.timeScale = 0.2f;
            Invoke("Reset", resetDelay);
        }
    }

    void SetupPaddle()
    {
        clonePaddle = Instantiate(paddleBall, transform.position, Quaternion.identity) as GameObject;
    }

    void Reset()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
