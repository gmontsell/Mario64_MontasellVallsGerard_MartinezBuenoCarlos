using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemData itemData;

    public void consume (GameObject consumer)
    {
        HealthSystem hs = consumer.GetComponent<HealthSystem>();
        Coin coin = consumer.GetComponent<Coin>();

        //if (hs != null)
        //{
        //   hs.lifeIncrease(itemData.health);
        //}

        if(coin != null)
        {
            coin.coinIncrease(itemData.coins);
        }
       
        Destroy(gameObject);
    }
    
}
