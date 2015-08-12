﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour {

	public GameObject playerHead;
	public PlayerController playerController;
	public PlayerEat playerEat;
	public PlayerColor playerColor;

	void Start () {

		if (isLocalPlayer) {
			GameObject.Find("CustomCardboardMain").transform.parent = playerHead.transform;
			playerController.enabled = true;
			playerEat.enabled = true;
			playerColor.enabled = true;
			Vector3 randomPos = new Vector3(Random.Range(-199.0f,199.0f), 0, Random.Range(-199.0f,199.0f));
			transform.position = randomPos;
		}
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

}
