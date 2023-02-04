using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public PlayerTransformation.Transformations allowedType;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            bool allowed = player.GetComponent<PlayerTransformation>().currentTransformation == allowedType;
            if (!allowed)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
