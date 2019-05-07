﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
	[SerializeField]
	protected int health;
	[SerializeField]
	protected int gems;
	[SerializeField]
	protected int speed;
	[SerializeField]
	protected Transform pointA;
	[SerializeField]
	protected Transform pointB;

	protected SpriteRenderer _sprite;
	protected Vector3 currentTarget;
	protected Animator _anim;
	protected Player player;
	protected bool isHit = false;

	public virtual void Attack() {
		Debug.Log("Parent method");
	}

	public void Start() {
		Init();
	}

	public virtual void Update() {
		if (this._anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && _anim.GetBool("InCombat") == false)
		{
			return;
		}

		Movement();
	}

	protected virtual void Init() {
		_sprite = GetComponentInChildren<SpriteRenderer>();
		_anim = GetComponentInChildren<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	public virtual void Movement() {
		if (currentTarget == pointA.position)
		{
			_sprite.flipX = true;
		}
		else
		{
			_sprite.flipX = false;
		}

		if (transform.position == pointA.position)
		{
			currentTarget = pointB.position;
			MakeAnimation();
		}
		else if (transform.position == pointB.position)
		{
			currentTarget = pointA.position;
			MakeAnimation();
		}

		if (!isHit)
		{
			transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
		}

		float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
		//Debug.Log(_anim.GetBool("InCombat"));
		if (distance > 2 && _anim.GetBool("InCombat"))
		{
			isHit = false;
			_anim.SetBool("InCombat", false);
		}

		Vector3 direction = player.transform.position - transform.position;
		if (_anim.GetBool("InCombat") && direction.x < 0)
		{
			//Debug.Log("_sprite.flipX = true");
			_sprite.flipX = true;
		}
		else if (_anim.GetBool("InCombat") && direction.x > 0)
		{
			//Debug.Log("_sprite.flipX = false");
			_sprite.flipX = false;
		}
	}

	public void MakeAnimation() {
		//Debug.Log("MakeAnimation");
		_anim.Play("Idle");
	}

	protected void EnemyDeath()
	{
		Destroy(this.gameObject);
	}
}