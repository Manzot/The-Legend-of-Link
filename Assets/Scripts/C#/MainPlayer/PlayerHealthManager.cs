using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;
	public bool isDead;
//	Rigidbody2D rbody;
	//Shaders
	public Material DefaultSprite;
	public Material ShaderSprite; 
	public float shaderTime;
	// Use this for initialization

	void Awake()
	{
		DontDestroyOnLoad(this);
	}

	void Start () 
	{
	//	rbody = GetComponent<Rigidbody2D>();
		playerMaxHealth = FindObjectOfType<PlayerStats>().MaxHP;
		playerCurrentHealth = playerMaxHealth;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerCurrentHealth <= 0) {
			gameObject.SetActive (false);
			isDead = true;
		} else
			isDead = false;
		shaderTime -= Time.deltaTime;
		if (shaderTime <= 0)
			GetComponent<SpriteRenderer>().material = DefaultSprite;
	}

	public void EnemyDamage(int damageToGiveByEnemy)
	{
		playerCurrentHealth -= damageToGiveByEnemy;
	}

	public void SetMaxHealth()
	{
		playerCurrentHealth = playerMaxHealth;
	}

	void OnCollisionEnter2D(Collision2D enemy)
	{
		if(enemy.gameObject.tag == "Enemy")
		{
			GetComponent<SpriteRenderer>().material = ShaderSprite;
			//hitTime = 1;
		}
	}
	void OnCollisionExit2D(Collision2D enemy)
	{
		shaderTime = 0.15f;
		if(enemy.gameObject.tag == "Enemy")
		{
			if(shaderTime > 0)
				GetComponent<SpriteRenderer>().material = ShaderSprite;
		}
	}
	void OnCollisionStay2D(Collision2D enemy)
	{
		if(enemy.gameObject.tag == "Enemy")
		{
			GetComponent<SpriteRenderer>().material = DefaultSprite;
		}
	}
}
