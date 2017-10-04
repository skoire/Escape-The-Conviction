using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
	public AudioClip[] soundsArray;
	private AudioSource audioSource;
	private bool firstLoop = true;

	private void OnEnable () {
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnDisable () {
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	private void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	private void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
		AudioClip sceneMusic = soundsArray[scene.buildIndex];
		if (scene.buildIndex == 0) {
			if (firstLoop == true) { firstLoop = false;}
			else { Destroy(gameObject); }
		} if (sceneMusic) {
			audioSource.clip = sceneMusic;
			audioSource.Play();
		}
	}
}
