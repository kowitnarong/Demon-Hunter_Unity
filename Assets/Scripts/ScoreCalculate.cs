using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculate : MonoBehaviour
{
    private string textCoin;
    public Text textElementCoin;
    private string textScore;
    public Text textElementScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetScore();
    }
    void SetScore()
    {
        textCoin = "TOTAL COIN : " + PlayerMovement.curCoin.ToString();
        textScore = "TOTAL SCORE : " + (PlayerMovement.curCoin * 100).ToString();
        textElementCoin.text = textCoin;
        textElementScore.text = textScore;
    }
}
