using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	public GameObject shopPanel;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag.Equals("Player"))
		{
			Player player = collision.GetComponent<Player>();
			if(player != null)
			{
				UIManager.Instance.OpenShop(player.diamonds);
			}
			shopPanel.SetActive(true);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag.Equals("Player"))
		{
			shopPanel.SetActive(false);
		}
	}

	public void SelectItem(int item)
	{
		if (item == 0)
		{
			Debug.Log("Flame Sword");
			UIManager.Instance.UpdateShopSelection(164);
		}

		if (item == 1)
		{
			Debug.Log("Boots of light");
			UIManager.Instance.UpdateShopSelection(34);
		}

		if(item == 2)
		{
			Debug.Log("Key Castle");
			UIManager.Instance.UpdateShopSelection(113);
		}
		
	}
}
