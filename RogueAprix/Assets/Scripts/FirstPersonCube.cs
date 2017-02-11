using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*First Person Cube
 * This class controls and dictates the behavior of the movement of the character
 * As of now, a character can move and rotate
 * Known Bugs: Whenever the player collides, if it does it fast enough, he may go flying.
 * */

public class FirstPersonCube : MonoBehaviour {
	public float motionspeed=400f; //Motion Speed: Speed of the character, can be modified on runtime
	public float rotationspeed=40f;//Rotation Speed: Speed of the character rotation, can be modified on runtime
	private float jumpForce=8f;//Jump Force: Used for the translation of the character, it isn't working atm.
	public GameObject player; //The player to be applied these actions, can be deleted and replaced with indirect components.
	public bool isGrounded; // For the Jump function, which doesn't work.

	void Update () { //It moves, it turns, it jumps!
		Move ();
		Turn ();
        Jump();

	}

	/*onCollissionStay() Method
	 * args: none
	 * return: none
	 * Checks if the character is on the ground or not. Doesn't work
	 */

	void onCollisionStay(){
		isGrounded = true;
	}
	/*Move() Method
	 * args: none
	 * return: none
	 * Controls the player's ability to move.
	 */
	void Move(){
		float deltatime = Time.deltaTime * motionspeed;
		if(Input.GetKey(KeyCode.DownArrow)){
			transform.Translate (Vector3.forward*deltatime);
		}
		if(Input.GetKey(KeyCode.UpArrow)){
			transform.Translate (Vector3.forward*(-deltatime));
		}
	}

	/*Turn() Method
	 * args: none
	 * return: none
	 * Controls the player's ability to rotate.
	 */
	void Turn(){
		float deltarotation = Time.deltaTime * rotationspeed;
		if(Input.GetKey(KeyCode.RightArrow)){
			transform.Rotate(Vector3.up *deltarotation);
		}
			if(Input.GetKey(KeyCode.LeftArrow)){
			transform.Rotate(Vector3.up * (-deltarotation));
		}
	}
	/*Jump() Method
	 * args: none
	 * return: none
	 * Controls the player's ability to jump.
	 */

	void Jump(){
		if (Input.GetKeyDown(KeyCode.Space)&&isGrounded){
			GameObject.Find ("default").GetComponent<Rigidbody>().AddForce (jumpForce * new Vector3(0,2,0),ForceMode.Impulse);
			isGrounded = false;
		}
	}
}
