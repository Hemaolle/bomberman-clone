using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed = 5;

	private Rigidbody2D myRigidbody2D;

	// Use this for initialization
	void Start () {
		myRigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 newVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		myRigidbody2D.velocity = newVelocity * speed;
	}
}
