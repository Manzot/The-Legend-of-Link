using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScenes : MonoBehaviour {

	private Animator anim;
	public bool CanDoIntro, CanDoText, NextSceneLoad;
	public GameObject Pokeball;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
		CanDoIntro = true;
		NextSceneLoad = false;
		CanDoText = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (CanDoIntro) 
		{
			anim.SetBool ("IntroScene", true);	
			anim.SetBool ("SavingInfo", false);	
		}
		if (CanDoText) 
		{
			Pokeball.SetActive (true);
			anim.SetBool ("SavingInfo", true);	
			anim.SetBool ("IntroScene", false);	
		}
		else
			Pokeball.SetActive (false);
		
		if (NextSceneLoad) 
		{
			SceneManager.LoadScene (1);
		}
	}
	public void IntroDone()
	{
		CanDoText = true;
		CanDoIntro = false;
	}
	public void LoadNextScene()
	{
		NextSceneLoad = true;
	}
}
