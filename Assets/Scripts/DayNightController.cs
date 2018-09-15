using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayNightController : MonoBehaviour {

	private enum States {dawn, day, dusk, night};

	private States _state;
	private int LIGHT_DURATION; 
	// The timer object that is going to be used to switch between states 
	private Timer _timer;

    public Material mat;
    public Color lerpedColor;

    private Color dayColor = Color.white;
    private Color sunsetColor = new Vector4(0.957f, 0.643f, 0.376f, 1);
    private Color nightColor = new Vector4(0.275f, 0.510f, 0.706f, 1);

    // Current day cycle is four minutes long
    private float secondsInFullDay = 240f;
    private float timeMultiplier = 1f;
    private float currentTimeOfDay;

    // The "timeIn" variables control the span of the lerp, telling it how long to gradually change between the colors
    private float timeInSunset = 0;
    private float timeInDusk = 0;
    private float timeInDawn = 0;

	// Change
	public void dayTimeChanged() {
		switch (_state) {
		case States.dawn:
			Debug.Log ("Setting game day night state to dawn");
			_state = States.day;
			LIGHT_DURATION = 2000;
			break;
		case States.day:
			Debug.Log ("Setting game day night state to day");
			_state = States.dusk;
			LIGHT_DURATION = 5000;
			break;
		case States.dusk:
			Debug.Log ("Setting game day night state to dusk");
			_state = States.night;
			LIGHT_DURATION = 2000;
			break;
		case States.night:
			Debug.Log("Setting game day night state to night");
			_state = States.dawn;
			LIGHT_DURATION = 5000;
			break;

		}

		// Reset the timer
		_timer.Change(LIGHT_DURATION,Timeout.Infinite);
	}

	// Use this for initialization
	void Start () {
		_state = States.day;
		LIGHT_DURATION = 5000;
		Debug.Log("Setting game day night state to day");

		// Set up timer for first state
		_timer = new Timer( _ => dayTimeChanged(), null, LIGHT_DURATION, Timeout.Infinite);
	}

//    void OnRenderImage(RenderTexture src, RenderTexture dest)
//    {
//
//
//
//		// Default color to white when not outdoors
//        Scene scene = SceneManager.GetActiveScene();
//        if (scene.name == "One Perfect Village House")
//        {
//            lerpedColor = Color.white;
//        }
//
//		
//
//        mat.SetColor("_Color", lerpedColor);
//        Graphics.Blit(src, dest, mat);
//    }
}
