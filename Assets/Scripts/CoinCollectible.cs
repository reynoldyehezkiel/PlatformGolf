using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        GolfController controller = other.GetComponent<GolfController>();

        if (controller != null)
        {
            controller.ChangeChanceToHit(1);
            Destroy(gameObject);
        }
    }
}
