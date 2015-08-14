using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	public GameObject playerHead;
	public PlayerController playerController;
	public PlayerSpeed playerSpeed;

	void Start () {

		if (isLocalPlayer) {
			GameObject.Find("CustomCardboardMain").transform.parent = playerHead.transform;
			playerController.enabled = true;
			playerSpeed.enabled = true;
			Vector3 randomPos = new Vector3(Random.Range(-149.0f,149.0f), 0, Random.Range(-149.0f,149.0f));
			transform.position = randomPos;
		}
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

}
