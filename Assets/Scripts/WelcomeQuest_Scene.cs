using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeQuest_Scene : MonoBehaviour {

    // Transforms manage moving the player to the starting position
    public Transform startingPos;
    private Transform currentPos;

    private SFXManager sfxManager;
    private MusicManager musicManager;
    private DialogueManager dialogueController;
    private CameraController cameraController;

    // Destroy this game object once the scene has been played
    private static bool sceneHasPlayed = false;

    // Use this for initialization
    void Start () {
        if (sceneHasPlayed)
        {
            Destroy(gameObject);
            return;
        }

        sceneHasPlayed = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
