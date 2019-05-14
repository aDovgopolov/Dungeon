using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
	public int gems;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag.Equals("Player"))
		{
			Player player = collision.GetComponent<Player>();

			if(player != null)
			{
				//player.diamonds += gems;
				player.AddGems(gems);
				Destroy(this.gameObject);
			}
		}
	}
}
