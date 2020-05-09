using UnityEngine;
using System.Collections;

public class EnemyFiringProjectiles : MonoBehaviour {
	public GameObject projectileSprite;
	private float distance;
	Vector3 playerPos;
	public float fireCounter;
	public float fireTime;
	// Use this for initialization
	void Start () {
		//Invoke("EnemyFireProjectiles", 1f);
		fireCounter = fireTime;
	}
	
	// Update is called once per frame
	void Update () 
	{
		fireCounter -= Time.deltaTime;
		Invoke("EnemyFireProjectiles", 1f);
	}
	void EnemyFireProjectiles()
	{
		fireCounter -= Time.deltaTime;
		playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
		distance = Vector3.Distance(playerPos, transform.position);
		GameObject player = GameObject.FindGameObjectWithTag("Player");

		if(player != null && distance > 0.8f && distance < 1.3f && fireCounter < 0)
		{
			fireCounter = fireTime;

			GameObject projectile = (GameObject)Instantiate(projectileSprite);
			projectile.transform.position = transform.position;
			Vector2 direction = player.transform.position - projectile.transform.position;
			projectile.GetComponent<EnemyProjectiles>().SetDirection(direction);
		}

	}
}
