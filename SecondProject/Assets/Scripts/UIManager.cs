using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _text, _livesText;

    // updateCoinDisplay(int coin)
    public void UpdateCoins (int coin)
    {
        _text.text = "Coins: " + coin.ToString();
    }

    public void UpdateLivesDisplay(int lives)
    {
        _livesText.text = "Lives: " + lives.ToString();
    }
}
