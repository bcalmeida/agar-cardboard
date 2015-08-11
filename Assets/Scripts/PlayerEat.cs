using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerEat : NetworkBehaviour {

	[SyncVar(hook="OnMassChanged")] public float mass;

	void OnMassChanged(float updatedMass) {
		Debug.Log(transform.name + ": mass is now " + updatedMass);
		mass = updatedMass;
		UpdateSize();
		// TODO: UpdateText(); - update the text that displays the mass
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Food")) {
			string foodId = other.transform.name;
			CmdTellServerWhichFoodWasEaten(foodId);
		}
	}

	[Command]
	void CmdTellServerWhichFoodWasEaten(string foodId) {
		Debug.Log("Server: " + foodId + " was eaten");
		mass += 0.5f;
		UpdateSize();
		GameObject.Find("FoodManager").GetComponent<FoodSpawner>().DestroyFood(foodId);
	}

	void UpdateSize() {
		float diameter = Mathf.Pow (mass, 0.5f);
		Vector3 position = new Vector3(0, diameter/2f, 0);
		Vector3 scale = new Vector3(diameter, diameter, diameter);
		transform.Find("Body").transform.localScale = scale;
		transform.Find ("Body").transform.localPosition = position;
		transform.Find("Player Head").transform.localPosition = position;
	}
}
