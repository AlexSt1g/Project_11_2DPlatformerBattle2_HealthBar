using TMPro;
using UnityEngine;

public class PlayerCoinCountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Player _player;
    
    private void Start()
    {
        DisplayCount(_player.ÑoinCount);
    }

    private void OnEnable()
    {
        _player.CoinCountChanged += DisplayCount;
    }

    private void OnDisable()
    {
        _player.CoinCountChanged -= DisplayCount;
    }

    private void DisplayCount(int value)
    {
        _text.text = $"Coins: {value}";
    }
}
