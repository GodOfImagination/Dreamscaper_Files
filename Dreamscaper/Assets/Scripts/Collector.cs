using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
	public GameObject Bridge;

	private void Start()
	{
		Bridge.SetActive(false);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == "Block")
		{
			Bridge.SetActive(true);
		}
	}
}
