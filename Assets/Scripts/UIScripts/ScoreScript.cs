using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public GameObject generator;
    public GameObject player;
    private int _score = 0, _updatedScore = 0;
    private Text _thisText;
    public int scoreValue = 1, deltaScore;

    public GameObject settingChanger;
    public int changeCounter = 0;
    public int counterToChange = 5000;
    public int deltaTransition = 500;

    private bool _transition = true;

    private int _maxScore = 0;

    private void Awake()
    {
        _thisText = GetComponent<Text>();
        _thisText.text = "Score: " + _score;
        _score = generator.GetComponent<LevelGeneratorScript>().platCounterGenerator;
    }

    void LateUpdate()
    {
        scoreValue = (int) player.GetComponent<CharacterNewScript>().speed;
        int counter = generator.GetComponent<LevelGeneratorScript>().platCounterGenerator;
        deltaScore = counter - _score;
        _score = counter;
        _updatedScore += deltaScore * scoreValue;
        _thisText.text = "Score: " + _updatedScore + "\nSpeed: " + scoreValue;
        // if (_updatedScore > _maxScore) _maxScore = _updatedScore;
    }

    private void Update()
    {
        if (_updatedScore / counterToChange > changeCounter)
        {
            changeCounter = _updatedScore / counterToChange;
            settingChanger.GetComponent<ChangeTerrain>().SetToChange();
            _transition = true;
        }

        if ((_updatedScore + deltaTransition) / counterToChange > changeCounter && _transition)
        {
            settingChanger.GetComponent<ChangeTerrain>().SetToTransitionColor();
            _transition = false;
        }
    }
    public int GetMaxScore()
    {
        return _maxScore;
    }

    public void SetMaxScore(int score)
    {
        if (_maxScore < score) _maxScore = score;
    }
}
