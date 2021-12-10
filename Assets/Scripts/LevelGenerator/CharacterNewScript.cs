using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class CharacterNewScript : MonoBehaviour
{
    private string _directionCharacter = "forward";

    private bool _game = true;
    private bool _gameStarted = false;
    public int counter = 0;

    private Vector3 _lastDirection = Vector3.left;
    private string _lastDirectionString = "forward";
    private Rigidbody _rigidbody;
    public float speed = 1.5f;
    public int platCounter = 20;
    public float deltaSpeed;
    public float maxSpeed = 6;

    public GameObject scoreGameObject;
    public GameObject coinGameObject;

    public GameObject saveLoadData;

    private Vector3 GetDirection()
    {
        if (_lastDirectionString == "forward") _lastDirection = Vector3.left;
        else if (_lastDirectionString == "left") _lastDirection = Vector3.back;
        else if (_lastDirectionString == "right") _lastDirection = Vector3.forward;
        return _lastDirection;
    }

    private void ChangeDirection()
    {
        if (_lastDirectionString != _directionCharacter)
        {
            _lastDirectionString = _directionCharacter;
        }
        else
        {
            if (_lastDirectionString == "right" || _lastDirectionString == "left") _lastDirectionString = "forward";
            else
            {
                float x = Random.Range(1, 3);
                if (x < 2)
                {
                    _lastDirectionString = "left";
                }
                else if (x < 3)
                {
                    _lastDirectionString = "right";
                }
            }
        }
    }

    private void Awake()
    {
        _game = true;
        _rigidbody = GetComponent<Rigidbody>();
        
        // Not working
        // ====
        // Debug.Log("Start to loading data");
        // saveLoadData.GetComponent<SaveScript>().LoadData();
        // int score = saveLoadData.GetComponent<SaveScript>().dt.GetComponent<SavingHighscore>().highScore;
        // scoreGameObject.GetComponent<ScoreScript>().SetMaxScore(score);
        // coinGameObject.GetComponent<CoinUIScript>().SetMaxCoins(saveLoadData.GetComponent<SaveScript>().dt.GetComponent<SavingHighscore>().coinCollectedInOneRun);
        // Debug.Log("Data is loaded");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Started: " + _gameStarted);
            if (_gameStarted)
            {
                ChangeDirection();
                _lastDirection = GetDirection();
            }
            else
            {
                _gameStarted = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_gameStarted)
        {
            Vector3 velocity = Vector3.zero;
            if (_game)
            {
                velocity = _lastDirection * speed * Time.deltaTime;
                speedChangeFunction();
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    // Not working
                    // ========
                    // int coins = coinGameObject.GetComponent<CoinUIScript>().GetMaxCoins();
                    // int score = scoreGameObject.GetComponent<ScoreScript>().GetMaxScore();
                    //
                    // saveLoadData.GetComponent<SaveScript>().SaveData(score, coins);

                    _game = true;
                    SceneManager.LoadScene("Scenes/SampleScene", LoadSceneMode.Single);
                }
            }

            velocity.y = _rigidbody.velocity.y;

            _rigidbody.transform.position = transform.position + velocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plat"))
        {
            _directionCharacter = other.GetComponent<PlatformScript>().GetDirection();
            platCounter += 1;
        } // Generates new plat

        if (other.CompareTag("Ground")) // game over condition
        {
            _game = false;
        }

        if (other.CompareTag("Coin")) // moneyszzzz! If player take coin, then counter +1
        {
            counter += 1;
            Destroy(other.transform.parent.gameObject);
        }
    }


    public String GetLastDirectionString()
    {
        return _lastDirectionString;
    }

    public bool GetGameRunning()
    {
        return _game;
    }

    private void speedChangeFunction()
    {
        if (speed < 11)
        {
            speed += deltaSpeed * 10 * Time.deltaTime;
        }
        else if (speed < 15)
        {
            speed += deltaSpeed * Time.deltaTime;
        }
        else if (speed >= 20)
        {
            speed += deltaSpeed / 10 * Time.deltaTime;
        }
    }
}