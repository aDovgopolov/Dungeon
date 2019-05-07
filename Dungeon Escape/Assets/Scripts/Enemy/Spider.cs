using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider :Enemy, IDamagable
{
	public GameObject AcidEffectPrefab;
	public int Health
	{
		get; set;
	}

	protected override void Init()
	{
		base.Init();
		Health = base.health;
	}
	public override void Movement()
	{
		//stay
	}

	public void Damage()
	{
		Debug.Log($"Damaged {this.name}");
		Health--;
		//_anim.SetBool("InCombat", true);
		//_anim.SetTrigger("Hit");
		//isHit = true;

		if (Health <= 0)
		{
			EnemyDeath();
		}
	}

	public override void Attack()
	{
		Instantiate(AcidEffectPrefab, transform.localPosition, Quaternion.identity);
	}
}
