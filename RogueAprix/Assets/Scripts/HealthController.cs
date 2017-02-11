using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*Health Controller class
 * Manages everything related to the lifes of the player, and displays the results.
 * Known bugs: When losing, in some cases, textures might get scrambled. Fixed partially.
 * Possible improvements: Hearts could be generated procedurally with the one heart texture, so that multiples lives could be implemented.
 * */

public class HealthController : MonoBehaviour {
	public Texture2D ElevatedOneHearts; //Textures for the hearts, they could be referenced directly.
	public Texture2D ElevatedTwoHearts;
	public Texture2D ElevatedTreeHearts;
	public int lifeCounter=3; //Default life counter as of now.
	public Transform destination; //Where to move the character when respawn() is called.
	public GameObject player; //Player to be called, could be referenced indirectly.
	public Image image; //GameOver image
	public AudioClip lose; //Sound for losing, not existant as of now. 

	void start(){
		image = GameObject.Find ("lose").GetComponent<Image>();
	}

	/*OnGUI class
 	* Draws textures for life and handles gameover
 	* Known bugs: When losing, in some cases, textures might get scrambled. Fixed partially.
 	* Possible improvements: Hearts could be generated procedurally with the one heart texture, so that multiples lives could be implemented.
 	* */

	void OnGUI(){
		if(lifeCounter>=3){
			GUI.DrawTexture (new Rect(10,10,150,100),ElevatedTreeHearts);
		}
		if(lifeCounter==2){
			GUI.DrawTexture (new Rect(10,10,150,100),ElevatedTwoHearts);
		}
		if(lifeCounter==1){
			GUI.DrawTexture (new Rect(10,10,150,100),ElevatedOneHearts);
		}
		if(lifeCounter<=0){
				image.enabled=true;
				GetComponent<AudioSource> ().PlayOneShot (lose); //its played just once.
				if(Input.GetKeyDown(KeyCode.Tab)){
					image.enabled=false;
					SceneManager.LoadScene (0);
				}
		}
	}

	/*Respawn() class
 	* params: none
 	* return: none
 	* Changes the position of the player to the origin
 	* */

	public void Respawn(){
		player.transform.position = destination.position;
		player.GetComponent<PlayerFreeze> ().Spawn ();
		player.GetComponent<TimerLevel> ().timer+=5;
	}


}
