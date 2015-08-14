using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSyncPosition : NetworkBehaviour {

	public Transform myTransform;
	public float lerpRate;

	[SyncVar]
	private Vector3 syncPos;

	// FixedUpdate just to reduce the number of requests
	[ClientCallback]
	void FixedUpdate () {
		if (isLocalPlayer) {
			CmdProvidePositionToServer(myTransform.position);
		} else {
			// Neat interpoliation: smooth
			myTransform.position = Vector3.Lerp(myTransform.position, syncPos, Time.deltaTime * lerpRate);
		}
	}

	[Command]
	public void CmdProvidePositionToServer(Vector3 pos) {
		syncPos = pos;
	}
}
