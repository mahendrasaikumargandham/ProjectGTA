using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Player player;
    public Text moneyAmountText;

    private void Update() {
        moneyAmountText.text = "" + player.playerMoney;
    }
}
