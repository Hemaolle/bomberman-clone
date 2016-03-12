using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed = 5;

	private Rigidbody2D myRigidbody2D;

	// Use this for initialization
	void Start () {
		myRigidbody2D = GetComponent<Rigidbody2D>();
	}

	enum MovementDirections {
		None, Up, Down, Left, Right
	};

	private MovementDirections latestButtonPressed = MovementDirections.None;

	// Update is called once per frame
	void Update () {
		MovementDirections buttonPressedInThisFrame = GetInputDirectionPressed();
		if (buttonPressedInThisFrame != MovementDirections.None) {
			latestButtonPressed = buttonPressedInThisFrame;
		}

		MovementDirections buttonReleasedInThisFrame = GetInputDirectionReleased();
		if (latestButtonPressed == buttonReleasedInThisFrame) {
			latestButtonPressed = GetInputDirectionHeld();
		}

		Move();
	}

	MovementDirections GetInputDirectionPressed() {
		if (Input.GetButtonDown("Left")) return MovementDirections.Left;
		if (Input.GetButtonDown("Right")) return MovementDirections.Right;
		if (Input.GetButtonDown("Up")) return MovementDirections.Up;
		if (Input.GetButtonDown("Down")) return MovementDirections.Down;
		return MovementDirections.None;
	}

	MovementDirections GetInputDirectionReleased() {
		if (Input.GetButtonUp("Left")) return MovementDirections.Left;
		if (Input.GetButtonUp("Right")) return MovementDirections.Right;
		if (Input.GetButtonUp("Up")) return MovementDirections.Up;
		if (Input.GetButtonUp("Down")) return MovementDirections.Down;
		return MovementDirections.None;
	}

	MovementDirections GetInputDirectionHeld() {
		if (Input.GetButton("Left")) return MovementDirections.Left;
		if (Input.GetButton("Right")) return MovementDirections.Right;
		if (Input.GetButton("Up")) return MovementDirections.Up;
		if (Input.GetButton("Down")) return MovementDirections.Down;
		return MovementDirections.None;
	}

	private void Move() {
		Vector2 movementDirection = new Vector2(0, 0);
		if (latestButtonPressed == MovementDirections.Left)  movementDirection = new Vector2(-1,  0);
		if (latestButtonPressed == MovementDirections.Right) movementDirection = new Vector2( 1,  0);
		if (latestButtonPressed == MovementDirections.Up)    movementDirection = new Vector2( 0,  1);
		if (latestButtonPressed == MovementDirections.Down)  movementDirection = new Vector2( 0, -1);
		myRigidbody2D.velocity = movementDirection * speed;
	}
}
