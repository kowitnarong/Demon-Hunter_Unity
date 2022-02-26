using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    private string textHp;
    public Text textElementHp;
    private string textCoin;
    public Text textElementCoin;

    public bool showHp = false;
    public bool showCoin = false;

    // Update is called once per frame
    void Update()
    {
        SetHpCoin();
    }
    void SetHpCoin()
    {
        textHp = "X " + PlayerMovement.hpPlayer.ToString();
        textCoin = "X " + PlayerMovement.curCoin.ToString();
        if (showHp)
        {
            textElementHp.text = textHp;
        }
        if (showCoin)
        {
            textElementCoin.text = textCoin;
        }
    }
}
