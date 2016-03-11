using UnityEngine;
using System.Collections;
using System;

public class Bomb : MonoBehaviour
{
	public float fuseTime;

	public event Action BombExplode;

	void Start() {
		Invoke("Explode", fuseTime);
	}

	void Explode() {		
		BombExplode();
		Destroy(gameObject);
	}
}

