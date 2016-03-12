using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D collider) {		
		if (collider.gameObject.tag == "Ground")
			Destroy(collider.gameObject);
	}
}
