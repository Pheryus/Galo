using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public float threshold = 15;
    public UnityEvent OnClick;   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            bool isPotato = player.GetComponent<PlayerTransformation>().currentTransformation
                == PlayerTransformation.Transformations.Potato;
            if (isPotato)
            {
                if (threshold < player.GetVelocity().magnitude)
                {
                    Activate();
                }
            }
        }
    }

    private void Activate()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.white * 0.5f;
        OnClick?.Invoke();
        Debug.Log("Activate");
    }
}
