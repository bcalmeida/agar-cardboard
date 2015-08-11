using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject body;
	public int speed;

	void Update () {
		Vector3 diff = Camera.main.transform.forward;
		diff.y = 0;
		transform.position += diff.normalized * speed * Time.deltaTime;
		body.transform.rotation = Camera.main.transform.rotation;
	}
}
