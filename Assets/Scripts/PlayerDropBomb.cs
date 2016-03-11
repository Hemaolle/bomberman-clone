using UnityEngine;
using System.Collections;

public class PlayerDropBomb : MonoBehaviour {
	public GameObject bomb;
	public int maxLiveBombs = 1;

	private int numberOfBombs = 0;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1") && numberOfBombs < maxLiveBombs) {
			var newBomb = (GameObject)Instantiate(bomb, transform.position, Quaternion.identity);
			newBomb.GetComponent<Bomb>().bombExplode += OnBombExplode;
			numberOfBombs++;
		}
	}

	public void OnBombExplode() {
		numberOfBombs--;
	}
}
