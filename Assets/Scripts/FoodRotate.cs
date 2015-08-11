using UnityEngine;
using System.Collections;

public class FoodRotate : MonoBehaviour {

	public int speed;

	void Update () {
		transform.Rotate(new Vector3(15,30,45) * speed * Time.deltaTime);
	}
}
