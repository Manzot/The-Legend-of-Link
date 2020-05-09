using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int enemyMaxHealth;
	public int enemyCurrentHealth;

	private PlayerStats thePlayerStats;
	//private EnemyAI enemyAI;
	public int expToGive;
	private float DeadTime = 0.02f;
	public bool dead;
	//private Animator anim;
	//public float respawnTimer;

	public GameObject bloodEffect;

	public Vector2 posAfDead;
	// Use this for initialization
	void Start () 
	{
	//	anim = GetComponent<Animator>();
		enemyCurrentHealth = enemyMaxHealth;
		thePlayerStats = FindObjectOfType<PlayerStats> ();
		//enemyAI = FindObjectOfType <EnemyAI>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		isDead();
	//	Respawn ();
		//Respawned ();
	}
	
	public void EnemyDamage (int damageToGive)
	{
		enemyCurrentHealth -= damageToGive;
	}
	
	public void SetMaxHealth()
	{
		enemyCurrentHealth = enemyMaxHealth;
	}
	public void isDead()
	{
		if (enemyCurrentHealth < 0) 
		{
			//gameObject.SetActive(false);
			//enemyAI.rbody.velocity = new Vector2 (0, 0);


			//enemyAI.chooseDirection();
			dead = true;
			DeadTime -= Time.deltaTime;
			//respawnTimer -= Time.deltaTime;
			//gameObject.SetActive(false);
			//gameObject.GetComponent<SpriteRenderer>().enabled = false;
			//anim.SetBool("dead", true);
			//thePlayerStats.AddExperience(expToGive);
		}
		if(enemyCurrentHealth > 0)
		{
			dead = false;
		}
		if(!dead)
		{
			DeadTime = 0.03f;
		}
		if(dead && DeadTime > 0 && DeadTime < 0.03)
		{
			Instantiate(bloodEffect, this.transform.position, this.transform.rotation);
			thePlayerStats.AddExperience(expToGive);
			Destroy (gameObject);
		}
		/*if (dead && respawnTimer < 0 && respawnTimer > -1)
		{
			anim.SetBool("dead", false);
			anim.SetBool ("alive", true);
			enemyCurrentHealth = enemyMaxHealth;
			transform.position = posAfDead;
			respawnTimer = 10f;
		}*/

	}
		
}
