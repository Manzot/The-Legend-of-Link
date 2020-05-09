using UnityEngine;
using System.Collections;

public class NpcManager : MonoBehaviour {

	public float speed;
	
	private Rigidbody2D rbody;
	
	public bool ismoving;
	
	private float walkCounter;
	public float walkTime;
	
	private float waitCounter;
	public float waitTime;

	private int movedirection;
	Vector2 vector;
	Animator anim;

	public Collider2D walkArea;
	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;
	private bool hasWalkArea;
	
	
	public bool canMove;

	private DialogueManager DM;
	
	void Start () 
	{
		anim = GetComponent<Animator> ();
		rbody = GetComponent<Rigidbody2D> ();
		DM = FindObjectOfType<DialogueManager> ();

		waitCounter = waitTime;
		walkCounter = walkTime;
		chooseDirection ();
		canMove = true;

		if (walkArea != null) 
		{
			minWalkPoint = walkArea.bounds.min;
			maxWalkPoint = walkArea.bounds.max;
			hasWalkArea = true;
		}
	}
	// Update is called once per frame
	void Update ()
	{
		// Dialog Managing
		if (!DM.dialogActive) 
		{
			canMove = true;
		}
		// Cant Move
		if (!canMove) 
		{
			anim.SetBool("walk_up", false);
			anim.SetBool("walk_down", false);
			anim.SetBool("walk_left", false);
			anim.SetBool("walk_right", false);
			rbody.velocity = Vector2.zero;
			return;
		}
		//Movements
		if (ismoving) {

			walkCounter -= Time.deltaTime;



			switch (movedirection) {
			case 0:
				rbody.velocity = new Vector2 (0, speed);
				if(hasWalkArea && transform.position.y > maxWalkPoint.y)
				{
					ismoving = false;
					waitCounter = waitTime;
				}
				anim.SetBool("up", true);
				anim.SetBool("left", false);
				anim.SetBool("down", false);
				anim.SetBool("right", false);
				anim.SetBool("walk_up", true);
				anim.SetBool("walk_down", false);
				anim.SetBool("walk_left", false);
				anim.SetBool("walk_right", false);
				break;

			case 1:
				rbody.velocity = new Vector2 (speed, 0);
				if(hasWalkArea && transform.position.x > maxWalkPoint.x)
				{
					ismoving = false;
					waitCounter = waitTime;
				}
				anim.SetBool("right", true);
				anim.SetBool("left", false);
				anim.SetBool("up", false);
				anim.SetBool("down", false);
				anim.SetBool("walk_right", true);
				anim.SetBool("walk_down", false);
				anim.SetBool("walk_up", false);
				anim.SetBool("walk_left", false);
				break;

			case 2:
				rbody.velocity = new Vector2 (0, -speed);
				if(hasWalkArea && transform.position.y < minWalkPoint.y)
				{
					ismoving = false;
					waitCounter = waitTime;
				}
				anim.SetBool("down", true);
				anim.SetBool("left", false);
				anim.SetBool("right", false);
				anim.SetBool("up", false);
				anim.SetBool("walk_down", true);
				anim.SetBool("walk_up", false);
				anim.SetBool("walk_left", false);
				anim.SetBool("walk_right", false);
				break;

			case 3:
				rbody.velocity = new Vector2 (-speed, 0);
				if(hasWalkArea && transform.position.x < minWalkPoint.x)
				{
					ismoving = false;
					waitCounter = waitTime;
				}
				anim.SetBool("left", true);
				anim.SetBool("right", false);
				anim.SetBool("up", false);
				anim.SetBool("down", false);
				anim.SetBool("walk_left", true);
				anim.SetBool("walk_down", false);
				anim.SetBool("walk_up", false);
				anim.SetBool("walk_right", false);
				break;
			}

			if (walkCounter < 0) { 
				ismoving = false;
				waitCounter = waitTime;
			}
		

		}
		else 
		{
			waitCounter -= Time.deltaTime;
			rbody.velocity = Vector2.zero;
			anim.SetBool("walk_up", false);
			anim.SetBool("walk_down", false);
			anim.SetBool("walk_right", false);
			anim.SetBool("walk_left", false);

			if(waitCounter < 0)
			{
				chooseDirection();
			}
		}
		
	}

	// Moving Directions
	public void chooseDirection()
	{
		movedirection = Random.Range (0, 4);
		ismoving = true;           
		walkCounter = walkTime;
	}
}
