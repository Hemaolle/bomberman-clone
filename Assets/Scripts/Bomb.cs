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

	private bool hasExploded = false;

	void Start() {
		Invoke("Explode", fuseTime);
	}

	void Explode() {
		if (!hasExploded) {
			hasExploded = true;
			bombExplode();
			Instantiate(explosion, transform.position, Quaternion.identity);
			InstantiateExplosionsUntilAWallIsHit(Vector2.up);
			InstantiateExplosionsUntilAWallIsHit(Vector2.down);
			InstantiateExplosionsUntilAWallIsHit(Vector2.left);
			InstantiateExplosionsUntilAWallIsHit(Vector2.right);
			Destroy(gameObject);
		}
	}

	void InstantiateExplosionsUntilAWallIsHit(Vector2 direction) {
		for (int i = 1; i <= distance; i++) {
			Vector2 explosionPosition = direction * i * distanceUnit + new Vector2(transform.position.x, 
				transform.position.y);
			Vector3 explosionPosition3D = new Vector3(explosionPosition.x, explosionPosition.y, 0);
			Collider2D objectThatExplosionCollidesWith = Physics2D.OverlapPoint(explosionPosition);
			Instantiate(explosion, explosionPosition, Quaternion.identity);
			if (objectThatExplosionCollidesWith == null)
				continue;
			if (objectThatExplosionCollidesWith.tag == "Ground" || 
				objectThatExplosionCollidesWith.tag == "IndestructibleGround") 
				return;
			if (objectThatExplosionCollidesWith.tag == "Bomb") 
				objectThatExplosionCollidesWith.gameObject.GetComponent<Bomb>().Explode();
		}
	}
}

