using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	public GameObject playerHead;
	public PlayerController playerController;

	void Start () {
		if (isLocalPlayer) {
			GameObject.Find("CardboardMain").transform.parent = playerHead.transform;
			playerController.enabled = true;
		}
	}

}
