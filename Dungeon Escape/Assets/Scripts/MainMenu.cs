using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	void Awake()
	{
		Screen.orientation = ScreenOrientation.Landscape;
	}


	public void StartGame()
	{
		SceneManager.LoadScene("Game");
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
