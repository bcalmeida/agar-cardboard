using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Startup : MonoBehaviour {

	void Start(){
		NetworkManager.singleton.networkAddress = "192.168.2.168";
		NetworkManager.singleton.StartClient();
	}
}
