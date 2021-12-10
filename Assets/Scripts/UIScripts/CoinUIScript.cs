using UnityEngine;
using UnityEngine.UI;

public class CoinUIScript : MonoBehaviour
{
    public GameObject player;
    private Text _thisText;
    private int _coinScore = 0;

    private int _maxCoins = 0;
    
    private void Awake()
    {
        _thisText = GetComponent<Text>();
        _thisText.text = "x" + _coinScore;
        _coinScore = player.GetComponent<CharacterNewScript>().counter;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        _coinScore = player.GetComponent<CharacterNewScript>().counter;
        // if (_maxCoins < _coinScore) _maxCoins = _coinScore;
        _thisText.text = "x" + _coinScore;
    }

    public int GetMaxCoins()
    {
        return _maxCoins;
    }
    public void SetMaxCoins(int coins)
    {
        if (_maxCoins < coins) _maxCoins = coins;
    }
}
