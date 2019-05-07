using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	private Animator animator;
	public Animator sword_anim;

	void Start()
    {
		animator = GetComponentInChildren<Animator>();
		sword_anim = transform.GetChild(1).GetComponent<Animator>();
	}
	
    void Update()
    {
        
    }

	public void Run(float move) {
		animator.SetFloat("Move", Mathf.Abs(move));
	}

	public void animateJump(bool value) {
		//Debug.Log($"Jump = {value}");
		animator.SetBool("Jump", value);
	}

	public void Attack(bool attack) {
		if (attack)
		{
			animator.SetTrigger("Attack trigger");
			sword_anim.SetTrigger("SwordAnimation");
		}
		else
		{
			//Debug.Log("Stop trigger");
			//animator.ResetTrigger("Attack trigger");
		}
		
	}
}
