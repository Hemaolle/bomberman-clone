using UnityEngine;
using System.Collections;

public class PlayerSpriteDirection : MonoBehaviour {
	public PlayerMovement playerMovement;

	public float downRotationAngle;
	public float upRotationAngle;
	public float leftRotationAngle;
	public float rightRotationAngle;

	private Quaternion downRotationQuaternion;
	private Quaternion upRotationQuaternion;
	private Quaternion leftRotationQuaternion;
	private Quaternion rightRotationQuaternion;

	void Start () {
		downRotationQuaternion = Quaternion.Euler(new Vector3(0,0,downRotationAngle));
		upRotationQuaternion = Quaternion.Euler(new Vector3(0,0,upRotationAngle));
		leftRotationQuaternion = Quaternion.Euler(new Vector3(0,0,leftRotationAngle));
		rightRotationQuaternion = Quaternion.Euler(new Vector3(0,0,rightRotationAngle));
	}

	// Update is called once per frame
	void Update () {
		switch (playerMovement.GetMovementDirection()) {
		case MovementDirections.Down:
			transform.rotation = downRotationQuaternion;
			break;
		case MovementDirections.Up:
			transform.rotation = upRotationQuaternion;
			break;
		case MovementDirections.Right:
			transform.rotation = rightRotationQuaternion;
			break;
		case MovementDirections.Left:
			transform.rotation = leftRotationQuaternion;
			break;
		default:
			break;
		}
	}
}
