using UnityEngine;

public class BasicRigidBodyPush : MonoBehaviour
{
	public LayerMask pushLayers;
	public bool canPush;
	[Range(0.5f, 5f)] public float strength = 1.1f;

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		if (canPush) PushRigidBodies(hit);
	}

	private void PushRigidBodies(ControllerColliderHit hit)
	{

		// Passar upp á það að gameobjectið er ekki kinematic
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic) return;

		// Passar upp á að gameobjectið sem er með ákveðið layer
		var bodyLayerMask = 1 << body.gameObject.layer;
		if ((bodyLayerMask & pushLayers.value) == 0) return;

		// Ýtir ekki það sem er fyrir neðan
		if (hit.moveDirection.y < -0.3f) return;

		// Reiknar áttina sem verður ýtt í
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0.0f, hit.moveDirection.z);

		// beitir aflinu
		body.AddForce(pushDir * strength, ForceMode.Impulse);
	}
}