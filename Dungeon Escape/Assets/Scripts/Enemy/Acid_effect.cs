using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid_effect : MonoBehaviour
{
	private void Start()
	{
		Destroy(this.gameObject, 5.0f);
	}

	private void Update()
	{
		transform.Translate(Vector3.right * 3 * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag.Equals("Player"))
		{
			IDamagable hit = collision.GetComponent<IDamagable>();
			Debug.Log($"Enter :{collision.name}");
			Debug.Log($"hit = {hit}");
			if (hit != null)
			{
				hit.Damage();
				Destroy(this.gameObject);
			}
		}
	}
}
