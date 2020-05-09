using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	public float timeD;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeD -= Time.deltaTime;
		if (timeD <= 0) 
		{
			Destroy (gameObject);
		}
	}
}
