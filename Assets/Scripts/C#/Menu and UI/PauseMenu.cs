using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public string mainMenu;
	public string levelSelect;

	public bool isPaused;
	public GameObject pauseCanvas;
	
	// Update is called once per frame
	void Update ()
	{
	if (isPaused)
		{
			pauseCanvas.SetActive (true);
			Time.timeScale = 0f;
		} 
		else 
		{
			pauseCanvas.SetActive (false);
			Time.timeScale = 1f;
		}
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			isPaused = !isPaused;
		}
	}
	public void Pause()
	{
		isPaused = true;
	}

	public void Resume()
	{
		isPaused = false;
	}

	public void Bag()
	{	
		Debug.Log("Bag Opened");
	}

	public void SaveGame()
	{
		Debug.Log("Game Saved");
	}

	public void LoadGame()
	{
		Debug.Log ("Game Loaded");
	}

	public void RestartLevel(int LevelID)
	{
		SceneManager.LoadScene (LevelID);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
