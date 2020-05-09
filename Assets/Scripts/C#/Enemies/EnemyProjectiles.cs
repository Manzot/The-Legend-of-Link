using UnityEngine;
using System.Collections;

public class EnemyProjectiles : MonoBehaviour {

	public float speed;
	Vector2 pDirection;
	public bool readyToFire;
	Vector2 position;
	public float fireCounter;
	public float fireTime;
	public int Damage;

	void Awake()
	{
		readyToFire = false;
	}
	// Use this for initialization
	void Start () {
		fireCounter = fireTime;
	}
	// Update is called once per frame
	void Update () 
	{
		if(readyToFire)
		{
			fireCounter -= Time.deltaTime;
			position = transform.position;
			position += pDirection * speed * Time.deltaTime;
			transform.position = position;
			if(fireCounter <= 0)
			{
				Destroy(gameObject);
			}
		}
	}

	public void SetDirection(Vector2 direction)
	{
		pDirection = direction.normalized;
		readyToFire = true;
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<PlayerHealthManager>().EnemyDamage(Damage);
			Destroy(gameObject);
		}
	}
}
