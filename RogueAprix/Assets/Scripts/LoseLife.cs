using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*Lose Life class
 * Handles losing lives, really simple
 * Known bugs: none
 * Possible improvements: could be refactored into another class, as this behaviour doesn't extend further than the player.
 * */
public class LoseLife : MonoBehaviour {
	public GameObject player;

	void OnTriggerEnter(Collider col){
		if(col.tag=="Player"){
			player.GetComponent<HealthController> ().lifeCounter--;
			player.GetComponent<HealthController> ().Respawn ();
		}
	}
}
