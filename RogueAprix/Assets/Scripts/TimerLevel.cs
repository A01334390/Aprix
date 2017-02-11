using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Timer Level class
 * This class controls the timer during gameplay, it may be assigned other values for more difficult levels.
 * Known bugs: None
 * */

public class TimerLevel : MonoBehaviour {
	public float timer=30f; //Default time frame
	public GameObject player; //Player to be applied these functions, can be changed for indirect reference.
	public GUIStyle style; //Manages the style of the GUI Box, these changes can be applied through the inspector.
	public bool begin=false; //Manages when the timer starts and when it ends.

	void start(){
		style = new GUIStyle (); //Creates the style
	}

	void Update(){
		if(begin==true){ //If it begins, it starts to take time away.
			timer -= Time.deltaTime;
		}
		if(timer<=0){ //If timer is smaller than zero, then the player goes back to spawn with increased speed and one life less.
			player.GetComponent<HealthController> ().lifeCounter--;
			timer = 30f;
			player.GetComponent<HealthController> ().Respawn();
			player.GetComponentInParent<FirstPersonCube> ().motionspeed += 100;
		}
	}

	void OnGUI(){ //A GUI Box is drawn to show the time left.
		GUI.Box (new Rect (20, 90, 300, 40), "Time left: " + timer.ToString ("0"),style);
	}
}
