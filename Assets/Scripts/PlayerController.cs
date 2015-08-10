using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject body;

	void Update () {
		Vector3 diff = Camera.main.transform.forward;
		diff.y = 0;
		transform.position += diff.normalized * 1 * Time.deltaTime;
		body.transform.rotation = Camera.main.transform.rotation;
	}
}
