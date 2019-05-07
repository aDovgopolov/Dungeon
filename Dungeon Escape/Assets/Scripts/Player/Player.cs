using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
	private Rigidbody2D rgb2d;
	private PlayerAnimation _anim;
	private SpriteRenderer _sprite;
	private SpriteRenderer _sword_arc;

	private bool resetJumpNeeded = true;
	[SerializeField]
	private float jumpForce = 5.0f;
	[SerializeField]
	private bool _grounded = false;
	[SerializeField]
	private LayerMask _groundMast;
	[SerializeField]
	private float _speed = 5.0f;

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
	}
	 
    void Update()
    {
		Move();
		//Debug.Log($"Input.GetKeyDown(KeyCode.Mouse0) + {isGrounded()}");
		if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded())
		{
			_anim.Attack(true);
			StartCoroutine(ResetAttackTrigger());
		}
	}

	public void Move() {
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		_grounded = isGrounded();

		//Filp(horizontalInput);
		if (horizontalInput > 0)
		{
			Flip(true);
		}
		else if (horizontalInput < 0)
		{
			Flip(false);
		}

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
		{
			rgb2d.velocity = new Vector2(rgb2d.velocity.x, jumpForce);
			StartCoroutine(ResetJumpNeededRoutine());
			_anim.animateJump(true);
		}

		rgb2d.velocity = new Vector2(horizontalInput * _speed, rgb2d.velocity.y);
		_anim.Run(horizontalInput);
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


	private bool isGrounded() {
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
		//throw new System.NotImplementedException();
		Debug.Log("Player::Damage");
	}
}
