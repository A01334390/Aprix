using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Player freeze.
/// It's an utility class.
/// Known Bugs: none
/// Possible improvements: it mainly handles audio, could be refactored.
/// </summary>
public class PlayerFreeze : MonoBehaviour {

	public AudioClip sound;
	public GameObject player;
	AudioSource audio;

	void Start(){
		audio= GetComponent<AudioSource> ();
		player.GetComponent<HealthController> ().enabled = false;
		audio.clip = sound;
		audio.Play ();
	}

	void Update(){
		if(audio.isPlaying){
			player.GetComponent<HealthController> ().enabled = true;
			player.GetComponent<TimerLevel> ().begin = true;
		}
	}

	public IEnumerator Spawn(){
		player.GetComponent<HealthController> ().enabled = false;
		yield return new WaitForSeconds (1);
		player.GetComponent<HealthController> ().enabled = true;
	}
}
