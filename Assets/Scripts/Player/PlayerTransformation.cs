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
        player.maxJumpHeight = 1.8f;
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
        playerAnimation.spriteRenderer.color = new Color(1f, 0.33f, 0f);
        player.learnDash = false;
        player.learnDoubleJump = true;
        player.learnWallJump = false;
        player.maxJumpHeight = 1.8f;
        player.timeToJumpApex = .34f;
        player.maxFallVelocity = 20f;
        player.UpdatePhysics();
        currentTransformation = Transformations.Carrot;
    }
    private void TransformToPotato()
    {
        if (currentTransformation == Transformations.Potato) return;
        playerAnimation.spriteRenderer.color = Color.yellow;
        player.learnDash = false;
        player.learnDoubleJump = false;
        player.learnWallJump = false;
        player.maxJumpHeight = 1f;
        player.timeToJumpApex = .2f;
        player.maxFallVelocity = 100f;
        player.UpdatePhysics();
        currentTransformation = Transformations.Potato;
    }

    public void OnGrounded(Vector3 velocity)
    {
        if (velocity.y < -5.0f)
        {
            TransformToStandard();
        }
    }
}
