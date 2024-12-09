using UnityEngine;

public class Collector : MonoBehaviour
{
	public string Block;
	public GameObject Bridge;

	private void Start()
	{
		Bridge.SetActive(false);
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.name == Block)
		{
			Bridge.SetActive(true);
		}
	}
}
