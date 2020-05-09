using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScreenFunctions : MonoBehaviour {

	private PlayerHealthManager PHM;
	private SaveLoadManager SLM;
	public GameObject RetryCanvas;
	public bool playerDead;
	// Use this for initialization
	void Start () 
	{
		SLM = FindObjectOfType<SaveLoadManager> ();
		PHM = FindObjectOfType<PlayerHealthManager> ();
	}

	void Update()
	{
		if (PHM.playerCurrentHealth <= 0) {
			playerDead = true;
		} else
			playerDead = false;

		if (playerDead) {
			StartCoroutine (RetryScreen ());
		} else
			StartCoroutine (RetryScreenDisable ());
	}
	// Update is called once per frame
	private IEnumerator RetryScreen () 
	{
		yield return new WaitForSeconds (1);
		RetryCanvas.SetActive (true);
	}
	private IEnumerator RetryScreenDisable()
	{
		yield return new WaitForSeconds (0.6f);
		RetryCanvas.SetActive (false);
	}

	public void RestartLevel(int LevelID)
	{
		SceneManager.LoadScene (LevelID);
	}

	public void LoadLastSave()
	{
		SLM.LoadState ();
	}
	public void Quit()
	{
		SceneManager.LoadScene(1);
	}
}
