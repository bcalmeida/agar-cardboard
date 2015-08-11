using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject body;
	public int speed;

	void Update () {
		Vector3 diff = Camera.main.transform.forward;
		diff.y = 0;
		Vector3 distance = diff.normalized * speed * Time.deltaTime;
		Vector3 nextpos = transform.position + distance;
		Vector3 size = body.transform.localScale;
		if (nextpos.x > 200.0f - size.x) {
			nextpos.x = 200.0f - size.x;
		}
		if (nextpos.x < -200.0f + size.x) {
			nextpos.x = -200.0f + size.x;
		}
		if (nextpos.z > 200.0f - size.z) {
			nextpos.z = 200.0f - size.z;
		}
		if (nextpos.z < -200.0f + size.z){
			nextpos.z = -200.0f + size.z;
		}
		transform.position = nextpos;
		body.transform.rotation = Camera.main.transform.rotation;
	}
}
