using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

	public int newGameLevel;
	public int loadGame;
	public bool LevelSelect;
	private SmoothCamera Cam;

//	private SaveLoadManager saveloadGame;
	// Use this for initialization
	void Start()
	{
		LevelSelect = false;
		Cam = FindObjectOfType<SmoothCamera> ();
	}
	public void NewGame()
	{
		//Application.LoadLevel (newGameLevel);
		SceneManager.LoadScene (2);
	}

	public void LoadGame(int Touched)
	{
		//SceneManager.LoadScene (loadGame);
		//saveloadGame.LoadState ();
		if(Touched == 1)
		LevelSelect = true;
		Cam.anim.enabled = true;
	}

	public void BackToMenu()
	{
		LevelSelect = false;
		Cam.anim.enabled = true;
	}

	public void Exit()
	{
		Application.Quit();
	}


}
