using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
	public Transform RTouch;
	public Image image;

	public Sprite menu;
	public Sprite instructions;

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

				if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch)){  //if click, open the screen for that object
					OpenCanvas(hit.collider.name);
				}
			} 
		} else {
			Vector3[] positions = new [] {RTouch.position, RTouch.position};
			lr.SetPositions(positions);
		}
	}

	private void OpenCanvas(string obj) {
		if (obj == "Play") {
			SceneManager.LoadScene("Detective.01");
		} else if (obj == "Instructions") {
			image.sprite = instructions;
			image.GetComponent<BoxCollider>().enabled = true;
		} else if (obj == "Image") {
			image.sprite = menu;
			image.GetComponent<BoxCollider>().enabled = false;
		} else if (obj == "Exit") {
			Application.Quit();
		}
	}
}
