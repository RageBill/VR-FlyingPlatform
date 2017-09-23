using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RageBillVR
{
	public class DragCamera : MonoBehaviour {
		#if UNITY_EDITOR
		bool isDragging = false;

		float startMouseX;
		float startMouseY;

		Camera cam;


		// Use this for initialization
		void Start () {
			cam = GetComponent<Camera> ();
		}
		
		// Update is called once per frame
		void Update () {
			if (Input.GetMouseButtonDown (1) && !isDragging) {
				isDragging = true;
				startMouseX = Input.mousePosition.x;
				startMouseY = Input.mousePosition.y;
			} else if(Input.GetMouseButtonUp (1) && isDragging){
				isDragging = false;
			}
		}

		void LateUpdate(){
			if (isDragging) {
				float endMouseX = Input.mousePosition.x;
				float endMouseY = Input.mousePosition.y;

				float diffX = endMouseX - startMouseX;
				float diffY = endMouseY - startMouseY;

				float newCenterX = Screen.width / 2 + diffX;
				float newCenterY = Screen.height / 2 + diffY;

				Vector3 LookHere = cam.ScreenToWorldPoint (new Vector3 (newCenterX, newCenterY, cam.nearClipPlane));

				transform.LookAt (LookHere);

				startMouseX = endMouseX;
				startMouseY = endMouseY;
			}
		}
		#endif
	}
}
