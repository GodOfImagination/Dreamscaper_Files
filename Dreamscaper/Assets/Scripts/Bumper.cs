using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
	private Rigidbody Rigidbody;
	private bool Debounce;

	private void Start()
    {
		Rigidbody = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player" && !Debounce)
		{
			Debounce = true;
			Vector3 Direction = transform.position - other.gameObject.transform.position;
			Rigidbody.AddForce(Direction * 300);
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Player" && Debounce)
		{
			Debounce = false;
		}
	}
}
