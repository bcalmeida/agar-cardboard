using UnityEngine;
using System.Collections;

public class SetText : MonoBehaviour {


	// Update is called once per frame
	void Update () {
		Transform player = transform.parent.transform.parent.transform.parent.transform;
		if (player.parent != null) {
			player = player.parent.transform.parent.transform;
			float playerMass = player.GetComponent<PlayerEat>().mass;
			transform.GetComponent<TextMesh>().text = playerMass.ToString("0.0");
		}
	}
}
