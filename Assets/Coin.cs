using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private int coins = 0;

    internal void coinIncrease(int coin)
    {
        coins += coin;
       
    }

    private void Update()
    {
        Debug.Log(coins);
    }
}
