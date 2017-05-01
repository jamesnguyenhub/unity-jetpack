using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameObject targetObject;
	private float distanceToTarget;

	void Start() {
		distanceToTarget = transform.position.x - targetObject.transform.position.x;
	}

	void Update() {
		float targetObjectX = targetObject.transform.position.x;

		Vector3 newCameraPosition = transform.position;
		newCameraPosition.x = targetObjectX + distanceToTarget;
		transform.position = newCameraPosition;
	}
}
