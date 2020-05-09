using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	// Movements
	public Rigidbody2D rbody;
	public bool ismoving;
	private float walkCounter;
	public float walkTime;
	private float waitCounter;
	public float waitTime;
	private int movedirection;
	Vector3 vector;
	Animator anim;
	// Follow AI
	private Vector3 player;
	private Vector3 playerDirection;
	private float xDiff;
	private float yDiff;
	public float speed;
	private int WorldObjects;
	private float distance;
	public float followSpeed;
	//Stop on collision
	public bool stun;
	private float stunTime;
	//Damage by Enemy To Player
	public int damageToGiveByEnemy;
	private int currentEnemyDamage;
	// Stats of Player
	private PlayerStats playerStats;
	private BasicMovement playermove;
	private PlayerControls playermove1;
	//Shaders
	public Material DefaultSprite;
	public Material ShaderSprite; 
	public float shaderTime;
	public Vector3 positionAfterDead;


	void Start () {

		playermove = FindObjectOfType<BasicMovement>();
		playermove1 = FindObjectOfType<PlayerControls>();
		playerStats = FindObjectOfType<PlayerStats> ();
		anim = GetComponent<Animator> ();
		rbody = GetComponent<Rigidbody2D> ();
		waitCounter = waitTime;
		walkCounter = walkTime;
		chooseDirection ();
		WorldObjects = 1 << 10;
		stun = false;
		stunTime = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{

		// Enemy Following AI
		distance = Vector3.Distance(player, transform.position);
		player = GameObject.FindGameObjectWithTag("Player").transform.position;
		
		if(stunTime > 0)
		{
			stunTime -= Time.deltaTime;
		}
		else
		{
			stun = false;
		}
		
		if(distance < 1.3f && !stun){

			if(rbody.velocity.x > 0.45f)
			{
				anim.SetBool("right", true);
				anim.SetBool("walk_right", true);
				anim.SetBool("up", false);
				anim.SetBool("walk_up", false);
				anim.SetBool("down", false);
				anim.SetBool("walk_down", false);
				anim.SetBool("left", false);
				anim.SetBool("walk_left", false);
			}
			if(rbody.velocity.x < -0.45f)
			{
				anim.SetBool("left", true);
				anim.SetBool("walk_left", true);
				anim.SetBool("up", false);
				anim.SetBool("walk_up", false);
				anim.SetBool("down", false);
				anim.SetBool("walk_down", false);
				anim.SetBool("right", false);
				anim.SetBool("walk_right", false);
			}
			if(rbody.velocity.x > -0.45f && rbody.velocity.x < 0.45f)
			{
				anim.SetBool("right", false);
				anim.SetBool("walk_right", false);
				anim.SetBool("left", false);
				anim.SetBool("walk_left", false);
			}
			if(rbody.velocity.y < -0.45f)
			{
				anim.SetBool("down", true);
				anim.SetBool("walk_down", true);
				anim.SetBool("right", false);
				anim.SetBool("walk_right", false);
				anim.SetBool("left", false);
				anim.SetBool("walk_left", false);
				anim.SetBool("up", false);
				anim.SetBool("walk_up", false);
			}
			if(rbody.velocity.y > 0.45f)
			{
				anim.SetBool("up", true);
				anim.SetBool("walk_up", true);
				anim.SetBool("right", false);
				anim.SetBool("walk_right", false);
				anim.SetBool("left", false);
				anim.SetBool("walk_left", false);
				anim.SetBool("down", false);
				anim.SetBool("walk_down", false);
			}
			if(rbody.velocity.y > -0.45f && rbody.velocity.y < 0.45f)
			{
				anim.SetBool("up", false);
				anim.SetBool("walk_up", false);
				anim.SetBool("walk_down", false);
				anim.SetBool("down", false);
			}
			
			ismoving = false;
			
			xDiff = player.x - transform.position.x;
			yDiff = player.y - transform.position.y;
			playerDirection = new Vector2(xDiff, yDiff);
			
			
			if(!Physics2D.Raycast(transform.position, playerDirection, 4, WorldObjects))
			{
				GetComponent<Rigidbody2D>().AddForce(playerDirection.normalized * followSpeed * Time.deltaTime);
			}
			
		}
		//Enemy Moving AI
		else if(distance > 1.6f && distance < 4f)
		{
			if (ismoving) {
				
				walkCounter -= Time.deltaTime;
				
				
				switch (movedirection) {
				case 0:
					rbody.velocity = new Vector2 (0, speed);
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
					anim.SetBool("walk_up", false);
					anim.SetBool("walk_down", false);
					anim.SetBool("walk_right", false);
					anim.SetBool("walk_left", false);
				}
			
			}
			else 
			{
				waitCounter -= Time.deltaTime;
				rbody.velocity = Vector3.zero;
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
		else if(distance > 5.1f)
		{
			transform.position = positionAfterDead;
		//	chooseDirection();
		}

		//KnockBack Counters
		if(playermove.knockBackCounter <= 0)
		{
			playermove.knockToRight = false;
			playermove.knockToLeft = false;
			playermove.knockToUp = false;
			playermove.knockToDown = false;
			playermove.knockToUpLeft = false;
			playermove.knockToDownLeft = false;
			playermove.knockToUpRight = false;
			playermove.knockToDownRight = false;
		}
		if(playermove1.knockBackCounter <= 0)
		{
			playermove1.knockToRight = false;
			playermove1.knockToLeft = false;
			playermove1.knockToUp = false;
			playermove1.knockToDown = false;
			playermove1.knockToUpLeft = false;
			playermove1.knockToDownLeft = false;
			playermove1.knockToUpRight = false;
			playermove1.knockToDownRight = false;
		}
		//Shaders
			

		shaderTime -= Time.deltaTime;

		if (shaderTime <= 0)
			GetComponent<SpriteRenderer>().material = DefaultSprite;
		

	}
	
	public void chooseDirection()
	{
		movedirection = Random.Range (0, 4);
		ismoving = true;           
		walkCounter = walkTime;
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			stun = true;
			stunTime = 0.8f;
			// Enemy Damage
			currentEnemyDamage = damageToGiveByEnemy - playerStats.currentDefence;
			if(currentEnemyDamage <= 0)
			{
				currentEnemyDamage = 1;
			}
			other.gameObject.GetComponent<PlayerHealthManager>().EnemyDamage(currentEnemyDamage);

			// KnockBack Using Keyboard
			playermove.knockBackCounter = playermove.knockbackLength;

			if(other.transform.position.x > transform.position.x && other.transform.position.y > transform.position.y )
			{
				playermove.knockToRight = true;
				playermove.knockToUpRight = true;
			}		
			else if(other.transform.position.x < transform.position.x && other.transform.position.y < transform.position.y )
			{
				playermove.knockToLeft = true;
				playermove.knockToDownLeft = true;
			}
			else if(other.transform.position.x < transform.position.x && other.transform.position.y > transform.position.y )
			{
				playermove.knockToUpLeft = true;
			}
			else if(other.transform.position.x > transform.position.x && other.transform.position.y < transform.position.y )
			{
				playermove.knockToDownRight = true;
			}

			//KnockBack Using Touch Controls
			playermove1.knockBackCounter = playermove1.knockbackLength;
			
			if(other.transform.position.x > transform.position.x && other.transform.position.y > transform.position.y )
			{
				playermove1.knockToRight = true;
				playermove1.knockToUpRight = true;
			}		
			else if(other.transform.position.x < transform.position.x && other.transform.position.y < transform.position.y )
			{
				playermove1.knockToLeft = true;
				playermove1.knockToDownLeft = true;
			}
			else if(other.transform.position.x < transform.position.x && other.transform.position.y > transform.position.y )
			{
				playermove1.knockToUpLeft = true;
			}
			else if(other.transform.position.x > transform.position.x && other.transform.position.y < transform.position.y )
			{
				playermove1.knockToDownRight = true;
			}
	
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Weapon")
		{
			//shaderTime = 0.2f;
			float horizontalPush = (other.gameObject.transform.position.x - transform.position.x);
			float vertticalPush = (other.gameObject.transform.position.y - transform.position.y);
			
			rbody.velocity =new Vector2(-horizontalPush, -vertticalPush) * 160f;
			stun = true;
			stunTime = 0.3f;
		
				GetComponent<SpriteRenderer>().material = ShaderSprite;
		}
	}
	
	void OnTriggerExit2D(Collider2D enemy)
	{
		shaderTime = 0.2f;
		if(enemy.gameObject.tag == "Weapon")
		{
			if(shaderTime > 0)
				GetComponent<SpriteRenderer>().material = ShaderSprite;
		}
	}
	void OnTriggerStay2D(Collider2D enemy)
	{
		if(enemy.gameObject.tag == "Weapon")
		{
			GetComponent<SpriteRenderer>().material = DefaultSprite;
		}
	}
}

