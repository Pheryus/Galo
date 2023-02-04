using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public PlayerTransformation.Transformations transformationBonus;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerTransformation>(out PlayerTransformation player))
        {
            if (transformationBonus == PlayerTransformation.Transformations.Carrot)
            {
                player.carrots++;
            }
            else if (transformationBonus == PlayerTransformation.Transformations.Potato)
            {
                player.potatoes++;
            }
            else if (transformationBonus == PlayerTransformation.Transformations.beet)
            {
                player.beets++;
            }
            Destroy(gameObject);
        }
    }
}
