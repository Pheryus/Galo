using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    bool flipped;
    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            Activate();
        }
    }

    private void Activate()
    {
        flipped = !flipped;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        if (flipped)
            OnActivate?.Invoke();
        else
            OnDeactivate?.Invoke();

    }
}
