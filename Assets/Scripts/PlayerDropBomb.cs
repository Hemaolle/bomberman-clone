using UnityEngine;
using System.Collections;

public class PlayerDropBomb : MonoBehaviour {
	public GameObject bomb;
	public int maxLiveBombs = 1;

	private int numberOfBombs = 0;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") && numberOfBombs < maxLiveBombs) {
			var newBomb = (GameObject)Instantiate(bomb, GetClosestTileCenter(transform.position), Quaternion.identity);
			newBomb.GetComponent<Bomb>().bombExplode += OnBombExplode;
			numberOfBombs++;
		}
	}

	public void OnBombExplode() {
		numberOfBombs--;
	}

	private Vector3 GetClosestTileCenter(Vector3 position) {
		Vector3 result = new Vector3();
		result.x = Mathf.Round(position.x);
		result.y = Mathf.Round(position.y);
		return result;
	}
}
