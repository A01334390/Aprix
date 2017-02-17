using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*WinLose Mechanic
 * Handles the player crossing the spawn point, meaning the player completed one lap.
 * Known Bugs: When the player passes through the collider, one or more laps are lost.
 * Known Bugs: The sound might keep playing even after restarting.
 * Possible improvements: as seen at the known bugs section.
 * */

public class WinLoseMech : MonoBehaviour {
	public GameObject player; //The player gameobject, may be referenced indirectly.
	private int laps=4; //Default number of laps, cant be modified.
	public GUIStyle style; //Style for the textbox, can be changed on the inspector
	public Image image; //Image for victory.
	public AudioClip victory; //Music Track when winning.
	private bool isColliding=true;

	void start(){
		style = new GUIStyle (); //Creates a new instance of style
		image = GameObject.Find ("win").GetComponent<Image>(); //retrieves the image
	}
	/// <summary>
	/// No known bugs, but once the "Several lap" bug is fixed, must be updated.
	/// </summary>
	void Update(){
		if(laps<=0){ //if number of laps is smaller than zero, then he wins. 
			image.enabled=true;
			GetComponent<AudioSource> ().PlayOneShot (victory); //its played just once.
			if(Input.GetKeyDown(KeyCode.Tab)){
				image.enabled=false;
				SceneManager.LoadScene (0);
			}
		}
	}
	/// <summary>
	/// Once it collides, this launches a subroutine that starts the process later.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnTriggerEnter(Collider col){
		if(isColliding){
			isColliding = false;
			if(col.tag=="Player"){
					StartCoroutine (WeGotIt ());
			}
			StartCoroutine (isAbleAgain());
		}
	}
	/// <summary>
	/// Raises the GU event.
	/// </summary>
	void OnGUI(){
		GUI.Box (new Rect (20, 130, 300, 40), "Laps Left: " + laps.ToString(),style);
	}
	/// <summary>
	/// It just slows down the process of the player retrieving many laps in one go, original bug.
	/// </summary>
	/// <returns>The got it.</returns>
	IEnumerator WeGotIt(){
		yield return new WaitForSeconds(0.2f);
		player.GetComponent<TimerLevel> ().timer += 5;
		laps--;

	}

	IEnumerator isAbleAgain(){
		yield return new WaitForSeconds(5);
		isColliding = true;

	}
}
