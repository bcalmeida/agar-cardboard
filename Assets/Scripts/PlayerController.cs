using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject body;
	public PlayerSpeed playerSpeed;

	void Update () {
		Vector3 diff = Camera.main.transform.forward;
		float speed = playerSpeed.speed;
		diff.y = 0;
		Vector3 distance = diff.normalized * speed * Time.deltaTime;
		Vector3 nextpos = transform.position + distance;
		Vector3 size = body.transform.localScale;
		float radius = size.x/2f;
		float wallThickness = 0.5f;
		float distanceToWall = radius + wallThickness/2f;
		if (nextpos.x > 200.0f - distanceToWall) {
			nextpos.x = 200.0f - distanceToWall;
		}
		if (nextpos.x < -200.0f + distanceToWall) {
			nextpos.x = -200.0f + distanceToWall;
		}
		if (nextpos.z > 200.0f - distanceToWall) {
			nextpos.z = 200.0f - distanceToWall;
		}
		if (nextpos.z < -200.0f + distanceToWall){
			nextpos.z = -200.0f + distanceToWall;
		}
		transform.position = nextpos;
		body.transform.rotation = Camera.main.transform.rotation;
	}
}
