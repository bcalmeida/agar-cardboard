using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class FoodID : NetworkBehaviour {

	[SyncVar] string foodID;

	public void SetFoodID(int count) {
		foodID = "Food " + count;
	}

	void Update () {
		if (transform.name == "" || transform.name == "Food(Clone)") {
			transform.name = foodID;
		}
	}
}
