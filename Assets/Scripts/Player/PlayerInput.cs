using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;

	PlayerTransformation playerTransformation;

	public KeyCode transformButton;

    List<Vector2> playerInputs;

	void Start () {
        playerInputs = new List<Vector2>();
		player = GetComponent<Player> ();
		playerTransformation = GetComponent<PlayerTransformation>();
	}

	void Update () {
		Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
        playerInputs.Add(directionalInput);

		player.SetDirectionalInput(playerInputs);

		if (Input.GetKeyDown (KeyCode.Space)) {
			player.OnJumpInputDown ();
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			player.OnJumpInputUp ();
		}
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            player.OnDashInput();
        }
		if (Input.GetKeyDown(KeyCode.Z))
        {
			playerTransformation.TransformCharacter(PlayerTransformation.Transformations.Carrot);
        }
		if (Input.GetKeyDown(KeyCode.X))
		{
			playerTransformation.TransformCharacter(PlayerTransformation.Transformations.Potato);
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
		}
	}
}
