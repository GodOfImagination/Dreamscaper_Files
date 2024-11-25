using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRigidBodyPush : MonoBehaviour
{
	public LayerMask PushLayers;
	public bool CanPush;
	[Range(0.5f, 5f)] public float PushStrength = 1.1f;

	private void OnControllerColliderHit(ControllerColliderHit Hit)
	{
		if (CanPush) PushRigidBodies(Hit);
	}

	private void PushRigidBodies(ControllerColliderHit Hit)
	{
		// Make sure we hit a non kinematic rigidbody.
		Rigidbody Rigidbody = Hit.collider.attachedRigidbody;
		if (Rigidbody == null || Rigidbody.isKinematic) return;

		// Make sure we only push desired layer(s).
		var RigidbodyLayer = 1 << Rigidbody.gameObject.layer;
		if ((RigidbodyLayer & PushLayers.value) == 0) return;

		// We dont want to push objects below us.
		if (Hit.moveDirection.y < -0.3f) return;

		// Calculate push direction from move direction, horizontal motion only.
		Vector3 PushDirection = new Vector3(Hit.moveDirection.x, 0.0f, Hit.moveDirection.z);

		// Apply the push and take strength into account.
		Rigidbody.AddForce(PushDirection * PushStrength, ForceMode.Impulse);
	}
}
