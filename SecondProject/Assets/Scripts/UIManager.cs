using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text _text;

    // updateCoinDisplay(int coin)
    public void UpdateCoins (int coin)
    {
        _text.text = "Coins: " + coin;
    }
}
