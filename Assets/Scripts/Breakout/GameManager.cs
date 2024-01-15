using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get { return instance; }
    }

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

        DontDestroyOnLoad(gameObject);
    }

    int lives = 3;
    int bricks = 20;
    float resetDelay = 2f;
    GameObject clonePaddle;

    public Text livesText;
    public Text gameOverText;
    public Text youWinText;
    public GameObject bricksPrefab;
    public GameObject paddleBall;
    public GameObject deathParticles;

    void Start()
    {
        clonePaddle = Instantiate(paddleBall, transform.position, transform.rotation) as GameObject;
        Instantiate(bricksPrefab, transform.position, transform.rotation);
    }

    void Update()
    {
        
    }
}
