using UnityEngine;
using UnityEditor;
using System.Collections;

public class SnapObjects {

	[MenuItem("Oskari/Snap objects' x and y coordinates to 0.5")]
	private static void Snap() {
		GameObject[] selectedObjects = Selection.gameObjects;
		foreach (GameObject selectedObject in selectedObjects) {
			Vector3 localPosition = selectedObject.transform.localPosition;
			localPosition.x = Mathf.Floor(localPosition.x) + 0.5f;
			localPosition.y = Mathf.Floor(localPosition.y) + 0.5f;
			selectedObject.transform.localPosition = localPosition;
		}
	}
}
