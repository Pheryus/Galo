using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarrotDigSpot : MonoBehaviour
{
    public PlayerTransformation.Transformations type = PlayerTransformation.Transformations.Carrot;
    public float downAmount = 1f;
    public SpriteRenderer sprite;
    Coroutine coroutine;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (directionalInput.y < 0)
            {
                if (coroutine != null) return;
                coroutine = StartCoroutine(DigCoroutine(player));
            }
        }
    }

    IEnumerator DigCoroutine(Player player)
    {
        player.GetComponent<PlayerInput>().enabled = false;
        player.GetComponent<Collider>().enabled = false;
        player.ResetVelocity();
        Vector3 startPos = player.transform.position;
        const float duration = 1f;
        for (float time = 0f; time < duration; time += Time.deltaTime)
        {
            float t = time / duration;
            player.transform.position = startPos - Vector3.up * downAmount * t;
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1 -    t);
            yield return null;
        }
        player.GetComponent<PlayerInput>().enabled = true;
        player.GetComponent<Collider>().enabled = true;
        Destroy(gameObject);
    }
}
