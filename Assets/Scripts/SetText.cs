using UnityEngine;
using System.Collections;

public class SetText : MonoBehaviour {
	
	
	// Update is called once per frame
	void Update () {
		Transform cardboard = getCardboardMain();
		if (cardboard.parent != null) {
			Transform player = cardboard.parent.transform.parent.transform;
			float playerMass = player.GetComponent<PlayerEat>().mass;
			transform.GetComponent<TextMesh>().text = playerMass.ToString("0.0");
		}
	}
	
	Transform getCardboardMain(){
		return transform.parent.transform.parent.transform.parent.transform;
	}
}