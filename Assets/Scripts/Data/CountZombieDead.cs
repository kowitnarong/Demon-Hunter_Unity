using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountZombieDead : MonoBehaviour
{
    static public int Count = 0;
    private string textZombie;
    public Text textElementZombie;

    // Update is called once per frame
    void Update()
    {
        SetZombieCount();
    }
    void SetZombieCount()
    {
        textZombie = ": " + CountZombieDead.Count.ToString();
        textElementZombie.text = textZombie;
    }
}
