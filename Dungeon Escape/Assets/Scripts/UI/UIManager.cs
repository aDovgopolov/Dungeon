using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	private static UIManager _instance;

	public Text playerGemCount;
	public Image selectionImage;

	public static UIManager Instance
	{
		get
		{
			if(_instance == null)
			{
				Debug.LogError("Error");
			}
			return _instance;
		}
	}

	public void UpdateShopSelection(int yPos)
	{
		selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);

	}

	public void OpenShop(int getmCount)
	{
		playerGemCount.text = $"{getmCount}G";
	}

	private void Awake()
	{
		_instance = this;
	}
}
