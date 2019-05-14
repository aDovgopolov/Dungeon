using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager :MonoBehaviour
{
	private static GameManager _instance;
	private GameManager(){}

	public bool HasKey{	get; set; }
	public Player Player
	{
		get; private set;
	}

	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
			{
				Debug.LogError("Error");
				//_instance = new GameManager();
			}
			return _instance;
		}
	}

	private void Awake()
	{
		_instance = this;
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

	}
}
