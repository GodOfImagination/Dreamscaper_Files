using UnityEngine;

public class Ramp : MonoBehaviour
{
	private Rigidbody Rigidbody;
	private bool Debounce;

	private void Start()
    {
		Rigidbody = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag("Player") && !Debounce)
		{
			Debounce = true;
			Vector3 Direction = transform.position - other.gameObject.transform.position;
			Rigidbody.AddForce(Direction * 300);
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.CompareTag("Player") && Debounce)
		{
			Debounce = false;
		}
	}
}
