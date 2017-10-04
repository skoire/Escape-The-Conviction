using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndManager : MonoBehaviour {
	public Transform RTouch;

	private LineRenderer lr;

	void Start() {
		lr = GetComponent<LineRenderer>();
	}

	void Update() {
		RaycastHit hit;

		if (Physics.Raycast(RTouch.position, RTouch.forward, out hit)) {								//if clickable, make laser pointer
			if (hit.collider.tag =="Clickable") {
				Vector3 end = RTouch.position + RTouch.forward*hit.distance;
				Vector3[] positions = new [] { RTouch.position, end};
				lr.SetPositions(positions);

				if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch)){  //if click, do appropriate action.
					if (hit.collider.name == "Play") { SceneManager.LoadScene("Detective.00"); }
					else if (hit.collider.name == "Exit") { Application.Quit(); }
				}
			} 
		} else {
			Vector3[] positions = new [] {RTouch.position, RTouch.position};
			lr.SetPositions(positions);
		}
	}
}
