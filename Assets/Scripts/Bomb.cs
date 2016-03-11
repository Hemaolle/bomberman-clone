using UnityEngine;
using System.Collections;
using System;

public class Bomb : MonoBehaviour
{
	public float fuseTime;
	public int distance = 3;
	public float distanceUnit = 1;
	public GameObject explosion;

	public event Action bombExplode;

	void Start() {
		Invoke("Explode", fuseTime);
	}

	void Explode() {		
		bombExplode();
		for (int i = -distance; i <= distance; i++) {
			Instantiate(explosion, transform.position + new Vector3(i * distanceUnit, 0, 0), Quaternion.identity);
		}
		for (int i = -distance; i <= distance; i++) {
			Instantiate(explosion, transform.position + new Vector3(0, i * distanceUnit, 0), Quaternion.identity);
		}
		Destroy(gameObject);
	}
}

