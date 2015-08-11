using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	public GameObject playerHead;
	public PlayerController playerController;
	public PlayerEat playerEat;

	void Start () {
		if (isLocalPlayer) {
			GameObject.Find("CardboardMain").transform.parent = playerHead.transform;
			playerController.enabled = true;
			playerEat.enabled = true;
		}
	}

}
