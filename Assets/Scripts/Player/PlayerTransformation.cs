using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformation : MonoBehaviour
{
    public enum Transformations { Standard, Carrot, Potato, beet };

    public Transformations currentTransformation;

    Player player;
    PlayerAnimation playerAnimation;

    public int carrots;
    public int potatoes;

    void Start()
    {
        player = GetComponent<Player>();
        playerAnimation = GetComponent<PlayerAnimation>();
        TransformToStandard();
    }



    public void TransformCharacter(Transformations transformation)
    {
        switch (transformation)
        {
            case Transformations.Carrot:
                TransformToCarrot();
                break;
            case Transformations.Standard:
                TransformToStandard();
                break;
            case Transformations.Potato:
                TransformToPotato();
                break;
        }
        playerAnimation.ChangeAnimatorController(transformation);
        SlowDown();
    }


    private void SlowDown()
    {
        StopCoroutine("FreezeTimeCoroutine");
        StartCoroutine(FreezeTimeCoroutine());
    }

    private IEnumerator FreezeTimeCoroutine()
    {
        Time.timeScale = 0.05f;
        yield return new WaitForSeconds(0.3f * Time.timeScale);
        Time.timeScale = 1f;
    }

    public void TransformToStandard()
    {
        if (currentTransformation == Transformations.Standard) return;
        playerAnimation.spriteRenderer.color = Color.white;
        player.maxJumpHeight = 3f;
        player.UpdatePhysics();
        player.learnDash = false;
        player.learnDoubleJump = false;
        player.learnWallJump = false;
        player.timeToJumpApex = .34f;
        player.maxFallVelocity = 20f;
        currentTransformation = Transformations.Standard;
    }

    public void TransformToCarrot()
    {
        if (currentTransformation == Transformations.Carrot) return;
        if (carrots <= 0) return;
        carrots--;
        playerAnimation.spriteRenderer.color = new Color(1f, 0.33f, 0f);
        player.learnDash = false;
        player.learnDoubleJump = true;
        player.learnWallJump = false;
        player.maxJumpHeight = 3f;
        player.timeToJumpApex = .34f;
        player.maxFallVelocity = 20f;
        player.UpdatePhysics();
        currentTransformation = Transformations.Carrot;
        SlowDown();
    }

    private void TransformToPotato()
    {
        if (currentTransformation == Transformations.Potato) return;
        if (potatoes <= 0) return;
        potatoes--;
        playerAnimation.spriteRenderer.color = Color.yellow;
        player.learnDash = false;
        player.learnDoubleJump = false;
        player.learnWallJump = false;
        player.maxJumpHeight = 2f;
        player.timeToJumpApex = .2f;
        player.maxFallVelocity = 100f;
        player.UpdatePhysics();
        currentTransformation = Transformations.Potato;
        SlowDown();
    }

    public void OnGrounded(Vector3 velocity)
    {
        if (currentTransformation == Transformations.Potato && velocity.y < -5.0f)
        {
            TransformToStandard();
        }
    }

    public void OnDoubleJump()
    {
        if (currentTransformation == Transformations.Carrot)
        {
            TransformToStandard();
        }
    }
}
