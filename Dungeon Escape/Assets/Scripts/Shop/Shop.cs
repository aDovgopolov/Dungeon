using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
	public GameObject shopPanel;
	public int currentSelectedItem;
	public int currentItemCosts;

	private Player player;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag.Equals("Player"))
		{
			player = collision.GetComponent<Player>();
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
			currentSelectedItem = 0;
			currentItemCosts = 200;
		}

		if (item == 1)
		{
			Debug.Log("Key Castle");
			UIManager.Instance.UpdateShopSelection(113);
			currentSelectedItem = 1;
			currentItemCosts = 400;
		}

		if (item == 2)
		{
			Debug.Log("Boots of light");
			UIManager.Instance.UpdateShopSelection(34);
			currentSelectedItem = 2;
			currentItemCosts = 100;
		}
	}

	public void BuyItem()
	{
		if(player.diamonds >= currentItemCosts)
		{	
			if(currentSelectedItem == 1)
			{
				GameManager.Instance.HasKey = true;
			}
			
			player.diamonds -= currentItemCosts;
			//on open frame bug with buy - currentItemCosts == 0
			Debug.Log($"Buy : {currentSelectedItem}");
		}
		else
		{
			Debug.Log("not enough money");
			shopPanel.SetActive(false);
		}
	}
}
