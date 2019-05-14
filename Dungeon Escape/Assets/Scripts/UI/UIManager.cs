using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	private static UIManager _instance;

	public Text playerGemCount;
	public Text GemCount;
	public Image selectionImage;
	public Image[] lifeBars;
	//public Image life1;
	//public Image life2;
	//public Image life3;
	//public Image life4;

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

	private void Awake()
	{
		_instance = this;
	}

	public void UpdateShopSelection(int yPos)
	{
		selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
	}

	public void OpenShop(int getmCount)
	{
		playerGemCount.text = $"{getmCount}G";
	}

	public void UpdateGemCount(int count)
	{
		GemCount.text = "" + count;
	}

	public void UpdateLifePanel(int lifeRemains)
	{
		for (int i = 0; i <= lifeRemains; i++)
		{
			if(i == lifeRemains)
			{
				lifeBars[i].enabled = false;
			}
		}
		//switch (lifeRemains)
		//{
		//	case 3: life4.enabled = false; break;
		//	case 2: life3.enabled = false; break;
		//	case 1: life2.enabled = false; break;
		//	case 0: life1.enabled = false; break;
		//	default: ; break;
		//}
	}
}
