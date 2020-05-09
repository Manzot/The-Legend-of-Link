using UnityEngine;
using System.Collections;

public class BasicMovement : MonoBehaviour {

	public float speed = 1.0f;
	public Rigidbody2D rbody;
	Animator anim;
	private bool Attacking;
	public float attackTime;
	public float attackTimeCounter;

	public bool canMove;
	public VirtualJoystick vJoy;

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
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		canMove = true;
		vJoy = GetComponent<VirtualJoystick>();
	}
	
	void Update ()
	{

		//Moving Disabled
		if (!canMove) 
		{
			anim.SetBool("walking", false);
			rbody.velocity = Vector2.zero;
			return;
		}
		//Cutscene

		// Movement When not Attacking
		if(!Attacking && knockBackCounter <= 0){

		var move = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
			rbody.MovePosition(transform.position + move * speed * Time.deltaTime);
		//Debug.Log ("move "+move);
		//Debug.Log ("x is "+move.x);
		//Debug.Log ("y is "+move.y);
			/*if(vJoy.InputDirection != Vector3.zero)
			{
				move = new Vector3 (vJoy.InputDirection.x, vJoy.InputDirection.y, 0);
				rbody.MovePosition (transform.position + move * Time.deltaTime);
			}*/
		if (move != Vector3.zero)
		{
			anim.SetBool("walking", true);
			anim.SetFloat("input_x", move.x);
			anim.SetFloat("input_y", move.y);
		//	Debug.Log("ANIME");
		}
		else
		{
			anim.SetBool ("walking", false);
		}
		
		// Attacking
		if (Input.GetKeyDown (KeyCode.K)) 
		{
			attackTimeCounter = attackTime;
			Attacking = true;
			rbody.velocity = Vector3.zero;
			anim.SetBool("Attacking", true);
		}
			if (move != Vector3.zero && Input.GetKeyDown (KeyCode.LeftShift)) {
				speed = 2;
			} else if (move != Vector3.zero && Input.GetKeyUp (KeyCode.LeftShift)) 
			{
				speed = 1;
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
			Attacking = false;
			anim.SetBool("Attacking", false);
		}

  }
}