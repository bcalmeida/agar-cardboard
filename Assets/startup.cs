using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class startup : MonoBehaviour {

	void Start(){
		NetworkManager.singleton.networkAddress = "192.168.2.182";
		NetworkManager.singleton.StartClient();
	}
}
