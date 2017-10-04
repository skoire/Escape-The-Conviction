using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ClockController : MonoBehaviour {
	private Text text;
	private float timeLeft = 60f;

	void Start () {
		text = GetComponent<Text>();
	}

	void Update () {
		timeLeft -= Time.deltaTime;
		text.text = "00:"+ timeLeft.ToString("00");
		if (timeLeft <= 0) { SceneManager.LoadScene("Detective.03"); }
	}
}
