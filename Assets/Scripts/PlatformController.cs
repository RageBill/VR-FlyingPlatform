using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

	int nextIndex;

	public Transform[] targets;

	public float speed = 1;

	bool isMoving = false;

	// Use this for initialization
	void Start () {
		transform.position = targets[0].position;

		nextIndex = 1;
	}
	
	// Update is called once per frame
	void Update () {
		HandleInput ();

		HandleMovement ();
	}

	void HandleMovement(){

		if (!isMoving)
			return;

		float distance = Vector3.Distance (transform.position, targets[nextIndex].position);

		if (distance > 0) {
			float movement = speed * Time.deltaTime;

			transform.position = Vector3.MoveTowards (transform.position, targets [nextIndex].position, movement);
		} else {

			nextIndex++;

			isMoving = false;

			if (nextIndex >= targets.Length) {
				nextIndex = 0;
			}

		}
	}

	void HandleInput(){
		if (Input.GetButtonDown ("Fire1")) {
			isMoving = !isMoving;
		}
	}
}
