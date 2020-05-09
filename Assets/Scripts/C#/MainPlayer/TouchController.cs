using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	private PlayerControls thePlayer;
//	private DialogHolder dialogues;

	// Use this for initialization
	void Start ()
	{
		thePlayer = FindObjectOfType<PlayerControls> ();
	//	dialogues = FindObjectOfType<DialogHolder> ();
		//thePlayer.PlayerAttacking(0);
		//thePlayer.moveIt (1, 0);
	}

	void Update()
	{

	}
	
	public void leftarrow()
	{
		thePlayer.PlayerWalkLeft (1);
		//Debug.Log("Touched Left");
	}
	public void rightarrow()
	{
		thePlayer.PlayerWalkRight(1);
	}
	public void uparrow()
	{
		thePlayer.PlayerWalkUp (1);
	}
	public void downarrow()
	{
		thePlayer.PlayerWalkDown (1);
	}
	public void uprightarrow()
	{
		thePlayer.PlayerWalkUpRight (1);
	}
	public void downrightarrow()
	{
		thePlayer.PlayerWalkDownRight (1);
	}
	public void downleftarrow()
	{
		thePlayer.PlayerWalkDownLeft (1);
	}
	public void upleftarroww()
	{
		thePlayer.PlayerWalkUpLeft (1);
	}
	public void PlayerAttacking()
	{
		thePlayer.PlayerAttacking (1);
	}
	public void Interact()
	{
		//thePlayer.Interacting (1);
	}

	public void noarrow()
	{

		thePlayer.PlayerWalkLeft (0);
		thePlayer.PlayerWalkRight (0);
		thePlayer.PlayerWalkUp (0);
		thePlayer.PlayerWalkDown (0);
		thePlayer.PlayerAttacking (0);
		thePlayer.PlayerWalkDownLeft (0);
		thePlayer.PlayerWalkDownRight (0);
		thePlayer.PlayerWalkUpRight (0);
		thePlayer.PlayerWalkUpLeft (0);
		//thePlayer.Interacting (0);
		//Debug.Log ("Touch ended ");
	}
}