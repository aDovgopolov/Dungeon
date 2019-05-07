using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_event : MonoBehaviour
{
	Spider spider;

	public void Start()
	{
		//spider = GameObject.FindGameObjectWithTag("Spider").GetComponent<Spider>();
		spider = transform.parent.GetComponent<Spider>();
	}

	public void Fire()
	{
		Debug.Log("Spider fire Event");
		spider.Attack();
	}   
}
