using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
	private bool switch_attack = true;
	private void OnTriggerEnter2D(Collider2D collision) {
		
		IDamagable hit = collision.GetComponent<IDamagable>();
		//Debug.Log($"Enter :{collision.name}");
		//Debug.Log($"hit = {hit}");
		if (hit != null)
		{
			if (switch_attack)
			{
				hit.Damage();
				switch_attack = false;
				StartCoroutine(ResetAttackAbility());
			}
		}
	}

	IEnumerator ResetAttackAbility()
	{
		yield return new WaitForSeconds(0.5f);
		switch_attack = true;
	}
}
