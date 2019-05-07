using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton :Enemy, IDamagable
{
	public int Health
	{
		get; set;
	}

	protected override void Init()
	{
		base.Init();
		Health = base.health;
	}

	public void Damage()
	{
		Debug.Log($"Damaged {this.name}");
		Health--;
		_anim.SetBool("InCombat", true);
		_anim.SetTrigger("Hit");
		isHit = true;

		if (Health <= 0)
		{
			EnemyDeath();
		}
	}
}
