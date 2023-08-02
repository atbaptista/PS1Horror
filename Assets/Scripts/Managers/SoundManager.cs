using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	
	public float masterVolume = 1;

	// Singleton instance.
	public static SoundManager Instance = null;
	
	// Initialize the singleton instance.
	private void Awake()
	{
		// If there is not already an instance of SoundManager, set it to this.
		if (Instance == null)
		{
			Instance = this;
		}
		//If an instance already exists, destroy whatever this object is to enforce the singleton.
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		//Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading scene.
		DontDestroyOnLoad (gameObject);
	}

	public void SetMasterVolume(float newVolume){
		masterVolume = newVolume;
	}
}