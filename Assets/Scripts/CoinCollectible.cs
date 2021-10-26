using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.tag == "Player")
        {
            // GolfController.ChangeChanceToHit(1);

            if (gameObject.name == "Gold Coin")
            {
                GolfController.amountOfGoldCoin++;
            }
            else if(gameObject.name == "Blue Coin")
            {
                GolfController.amountOfBlueCoin+=5;
            }
            Destroy(gameObject);
        }
    }
}
