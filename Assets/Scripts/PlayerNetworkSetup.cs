using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	public GameObject playerHead;
	public PlayerController playerController;
	public PlayerEat playerEat;

	void Start () {
		if (isLocalPlayer) {
			GameObject.Find("CustomCardboardMain").transform.parent = playerHead.transform;
			playerController.enabled = true;
			playerEat.enabled = true;
			Vector3 randPos = new Vector3(Random.Range(-199.0f,199.0f), 0.5f, Random.Range(-199.0f,199.0f));
			transform.position = randPos;
		}
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

}
