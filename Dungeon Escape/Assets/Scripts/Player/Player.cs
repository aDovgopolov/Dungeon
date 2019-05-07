using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
	private Rigidbody2D rgb2d;
	private PlayerAnimation _anim;
	private SpriteRenderer _sprite;
	private SpriteRenderer _sword_arc;
	private Transform hit_box;
	public int diamonds = 0;

	private bool resetJumpNeeded = true;
	[SerializeField]
	private float jumpForce = 5.0f;
	[SerializeField]
	private bool _grounded = false;
	[SerializeField]
	private LayerMask _groundMast;
	[SerializeField]
	private float _speed = 5.0f;
	private bool isDead = false;

	public int Health
	{
		get; set;
	}

	void Start()
    {
		rgb2d = GetComponent<Rigidbody2D>();
		_anim = GetComponent<PlayerAnimation>();
		_sprite = GetComponentInChildren<SpriteRenderer>();
		_sword_arc = transform.GetChild(1).GetComponent<SpriteRenderer>();
		hit_box = _sprite.GetComponentInChildren<Transform>();
	}
	 
    void Update()
    {	
		if(!isDead)
			Move();

		if (Input.GetKeyDown(KeyCode.Mouse0) && IsGrounded())
		{
			_anim.Attack(true);
			StartCoroutine(ResetAttackTrigger());
		}
	}

	public void Move() {
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		_grounded = IsGrounded();
		
		if (horizontalInput > 0)
		{
			Flip(true);
			FlipHitBox(true);
		}
		else if (horizontalInput < 0)
		{
			Flip(false);
			FlipHitBox(false);
		}

		if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
		{
			rgb2d.velocity = new Vector2(rgb2d.velocity.x, jumpForce);
			StartCoroutine(ResetJumpNeededRoutine());
			_anim.animateJump(true);
		}

		rgb2d.velocity = new Vector2(horizontalInput * _speed, rgb2d.velocity.y);
		_anim.Run(horizontalInput);
	}

	private void FlipHitBox(bool facaRight)
	{
		Debug.Log(facaRight);
		if (facaRight)
		{
			Vector2 newPos = hit_box.transform.localPosition;
			newPos.x = hit_box.transform.localPosition.x;
			hit_box.transform.localPosition = newPos;
		}
		else if (!facaRight)
		{
			Vector2 newPos = hit_box.transform.localPosition;
			newPos.x = -hit_box.transform.localPosition.x;
			hit_box.transform.localPosition = newPos;
		}
	}

	private void Flip(bool faceRight) {

		if (faceRight)
		{
			_sprite.flipX = false;
			_sword_arc.flipY = false;

			Vector2 newPos = _sword_arc.transform.localPosition;
			newPos.x = 1.01f;
			_sword_arc.transform.localPosition = newPos;
		}
		else if (!faceRight)
		{
			_sprite.flipX = true;
			_sword_arc.flipY = true;

			Vector2 newPos = _sword_arc.transform.localPosition;
			newPos.x = -1.01f;
			_sword_arc.transform.localPosition = newPos;
		}
	}

	private bool IsGrounded() {
		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundMast);

		if (hitInfo.collider != null)
		{
			if (resetJumpNeeded)
			{
				_anim.animateJump(false);
				return true;
			}
		}

		return false;
	}

	public void Grounded() {
		RaycastHit2D ground = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundMast);
		Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green);

		if (ground.collider != null)
		{
			Debug.Log("Hit" + ground.collider.name);
			if (resetJumpNeeded == false)
				_grounded = true;
		}
	}

	IEnumerator ResetJumpNeededRoutine(){
		resetJumpNeeded = false;
		yield return new WaitForSeconds(0.1f);
		resetJumpNeeded = true;
	}

	IEnumerator ResetAttackTrigger() {
		//Debug.Log("ResetAttackTrigger");
		yield return new WaitForSeconds(1f);
		_anim.Attack(false);
	}

	public void Damage()
	{
		Debug.Log("Player::Damage");
		//isDead = true;
		_anim.animateDeath();
	}
}
