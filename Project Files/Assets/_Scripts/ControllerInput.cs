using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerInput : MonoBehaviour {
	public Transform RTouch;
	public Image image;
	public Canvas canvas;

	public Sprite computer;
	public Sprite microscope;
	public Sprite textbook1;
	public Sprite textbook2;
	public Sprite beaker;
	public Sprite shoeprint;
	public Sprite door;

	private LineRenderer lr;
	private int TextbookCounter = 0;

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
		if (obj == "Computer") {
			UpdateImage(computer);
		} else if (obj == "Microscope") {
			UpdateImage(microscope);
		} else if (obj == "Textbook") {
			UpdateImage(textbook1);
			TextbookCounter = 1;
		} else if (obj == "Beaker") {
			UpdateImage(beaker);
		} else if (obj == "Shoeprint") {
			UpdateImage(shoeprint);
		} else if (obj == "Door") {
			UpdateImage(door);
			foreach(BoxCollider button in image.GetComponentsInChildren<BoxCollider>()) {
				button.enabled = true;
			}
		} else if (obj == "Culprit") {
			SceneManager.LoadScene("Detective.02");
		} else if (obj == "Others") {
			SceneManager.LoadScene("Detective.03");
		} else if (obj == "Canvas") {
			if (TextbookCounter == 1) {
				image.sprite = textbook2;
				TextbookCounter = 0;
			} else {
				canvas.enabled = false;
				canvas.GetComponent<BoxCollider>().enabled = false;
				foreach(BoxCollider button in image.GetComponentsInChildren<BoxCollider>()) {
					button.enabled = false;
				}
			}
		}
	}

	private void UpdateImage(Sprite sprite) {
		canvas.enabled = true;
		image.sprite = sprite;
		canvas.GetComponent<BoxCollider>().enabled = true;
	}
}

