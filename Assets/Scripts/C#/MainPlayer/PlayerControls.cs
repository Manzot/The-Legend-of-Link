using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

	public Rigidbody2D rbody;
	Animator anim;
	public float speed;
	private bool walkLeft;
	private bool walkRight;
	private bool walkUp;
	private bool walkDown;
	private bool walkUpLeft;
	private bool walkUpRight;
	private bool walkDownLeft;
	private bool walkDownRight;
	public bool SwordAttacks;
	public bool attacking;
	public bool interact;

	public float attackTime;
	public float attackTimeCounter;

	public VirtualJoystick vJoy;
	public bool canMove;
//	private NpcManager npc;
//	private DialogHolder dh;

	public bool knockToLeft;
	public bool knockToRight;
	public bool knockToUp;
	public bool knockToDown;
	public bool knockToUpLeft;
	public bool knockToDownLeft;
	public bool knockToUpRight;
	public bool knockToDownRight;
	public float knockbackLength;
	public float knockBackCounter;
	public float knockSpeed;

	void Start () 
	{
		//npc = FindObjectOfType<NpcManager> ();
		//dh = FindObjectOfType<DialogHolder> ();
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		attackTimeCounter = attackTime;
		canMove = true;
	}

	// Update is called once per frame
	void Update ()
	{

		if (!canMove) 
		{
			anim.SetBool ("Idle", true);
			anim.SetBool("walking", false);
			anim.SetBool("Attacking", false);
			rbody.velocity = Vector2.zero;
			return;
		}

		SwordAttacks = true;

		if (!attacking && knockBackCounter <= 0) 
		{
			//Movement with Keyboard For Virtual Joystick
			var movewithkeys = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
			rbody.MovePosition(transform.position + movewithkeys * speed * Time.deltaTime);

			if(vJoy.InputDirection != Vector2.zero)
			{
				movewithkeys = new Vector3 (vJoy.InputDirection.x, vJoy.InputDirection.y, 0);
				rbody.MovePosition (transform.position + movewithkeys * speed * Time.deltaTime);
			}
			if (movewithkeys != Vector3.zero) {
				anim.SetBool ("Idle", false);
				//anim.SetBool("walking", true);
				anim.SetFloat ("input_x", movewithkeys.x);
				anim.SetFloat ("input_y", movewithkeys.y);
				//	Debug.Log("ANIME");
			}
			else
			{
				anim.SetBool ("Idle", true);
				//anim.SetBool("walking", false);
			}


			// moveleft
			if (walkLeft) {	

				var move = Vector3.left;
				rbody.MovePosition (transform.position + move * speed * Time.deltaTime);

				if (move != Vector3.zero) {
					anim.SetBool ("walking", true);
					anim.SetFloat ("input_x", move.x);
					anim.SetFloat ("input_y", move.y);
				}
				//Debug.Log ("running left...");
			}
		// moveright
		else if (walkRight) {	
			
				var move = Vector3.right;
				rbody.MovePosition (transform.position + move * speed * Time.deltaTime);
			
				if (move != Vector3.zero) {
					anim.SetBool ("walking", true);
					anim.SetFloat ("input_x", move.x);
					anim.SetFloat ("input_y", move.y);
				}			
				//Debug.Log ("running right...");
			}
		//move up
		else if (walkUp) {	
			
				var move = Vector3.up;
				rbody.MovePosition (transform.position + move * speed * Time.deltaTime);
			
				if (move != Vector3.zero) {
					anim.SetBool ("walking", true);
					anim.SetFloat ("input_x", move.x);
					anim.SetFloat ("input_y", move.y);
				} 
				//Debug.Log ("running up...");
			}
		// move down
		else if (walkDown) {	
			
				var move = Vector3.down;
				rbody.MovePosition (transform.position + move * speed * Time.deltaTime);
			
				if (move != Vector3.zero) {
					anim.SetBool ("walking", true);
					anim.SetFloat ("input_x", move.x);
					anim.SetFloat ("input_y", move.y);
				}
				//Debug.Log ("running down...");
			}
			// move up left
			else if (walkUpLeft) {	

				var move = Vector3.up + Vector3.left;
				rbody.MovePosition (transform.position + move * speed * Time.deltaTime);

				if (move != Vector3.zero) {
					anim.SetBool ("walking", true);
					anim.SetFloat ("input_x", move.x);
					anim.SetFloat ("input_y", move.y);
				}
				//Debug.Log ("running down...");
			}
			// move up right
			else if (walkUpRight) {	

				var move = Vector3.right + Vector3.up;
				rbody.MovePosition (transform.position + move * speed * Time.deltaTime);

				if (move != Vector3.zero) {
					anim.SetBool ("walking", true);
					anim.SetFloat ("input_x", move.x);
					anim.SetFloat ("input_y", move.y);
				}
				//Debug.Log ("running down...");
			}
			// move down left
			else if (walkDownLeft) {	

				var move = Vector3.down + Vector3.left;
				rbody.MovePosition (transform.position + move * speed * Time.deltaTime);

				if (move != Vector3.zero) {
					anim.SetBool ("walking", true);
					anim.SetFloat ("input_x", move.x);
					anim.SetFloat ("input_y", move.y);
				}
				//Debug.Log ("running down...");
			}
			// move down right
			else if (walkDownRight) {	

				var move = Vector3.down + Vector3.right;
				rbody.MovePosition (transform.position + move * speed * Time.deltaTime);

				if (move != Vector3.zero) {
					anim.SetBool ("walking", true);
					anim.SetFloat ("input_x", move.x);
					anim.SetFloat ("input_y", move.y);
				}
				//Debug.Log ("running down...");
			}
		//otherwise stop animation
		else {
				anim.SetBool ("walking", false);
			}
		}
		else
		{
			if(knockToLeft)
				rbody.velocity = new Vector2(-1.3f, 0) * knockSpeed;
			if(knockToUpLeft)
				rbody.velocity = new Vector2(-1f, 1.3f) * knockSpeed;
			if(knockToDownLeft)
				rbody.velocity = new Vector2(-1f, -1.3f) * knockSpeed;
			if(knockToRight)
				rbody.velocity = new Vector2(1.3f, 0) * knockSpeed;
			if(knockToUpRight)
				rbody.velocity = new Vector2(1.3f, 1f) * knockSpeed;
			if(knockToDownRight)
				rbody.velocity = new Vector2(1f, -1.3f) * knockSpeed;
			if(knockToUp)
				rbody.velocity = new Vector2(0, 1f) * knockSpeed;
			if(knockToDown)
				rbody.velocity = new Vector2(0, -1f) * knockSpeed;
			
			knockBackCounter -= Time.deltaTime;
		}

		if (attackTimeCounter > 0) 
		{
			attackTimeCounter -= Time.deltaTime;
		}
		if (attackTimeCounter <= 0) 
		{
			attacking = false;
			anim.SetBool("Attacking", false);
		}
	}

		


	//functions for movement

	public void PlayerWalkLeft(int value){
		if (value == 1)
		{
			walkLeft = true;
			SwordAttacks = false;
		}
		else
		{
			walkLeft = false;
			SwordAttacks = true;
		}
		
	}
		
	public void PlayerWalkRight(int value){
		if (value == 1)
		{
			walkRight = true;
		}
		else
		{
			walkRight = false;
		}
		
	}
	public void PlayerWalkUp(int value){
		if (value == 1)
		{
			walkUp = true;
		}
		else
		{
			walkUp = false;
		}
		
	}
	public void PlayerWalkDown(int value){
		if (value == 1)
		{
			walkDown = true;
		}
		else
		{
			walkDown = false;
		}
		
	}
	public void PlayerWalkUpLeft(int value){
		if (value == 1)
		{
			walkUpLeft = true;
		}
		else
		{
			walkUpLeft = false;
		}

	}
	public void PlayerWalkUpRight(int value){
		if (value == 1)
		{
			walkUpRight = true;
		}
		else
		{
			walkUpRight = false;
		}

	}
	public void PlayerWalkDownLeft(int value){
		if (value == 1)
		{
			walkDownLeft = true;
		}
		else
		{
			walkDownLeft = false;
		}

	}
	public void PlayerWalkDownRight(int value){
		if (value == 1)
		{
			walkDownRight = true;
		}
		else
		{
			walkDownRight = false;
		}

	}
	public void PlayerAttacking(int value)
	{
		//ATTACKING
		if (SwordAttacks) 
		{
			attackTimeCounter = attackTime;
			//rbody.velocity = Vector3.zero;
			anim.SetBool ("Attacking", true);
		}
		else
		{
			attacking = false;
			anim.SetBool ("Attacking", false);
		}
		if (value == 1) 
		{
			SwordAttacks = true;
			attacking = true;
		}
		else 
		{
			SwordAttacks = false;
			anim.SetBool("Attacking", false);
		}


	}

}
