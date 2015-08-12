using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerEat : NetworkBehaviour {

	[SyncVar(hook="OnMassChanged")] public float mass;
	public float threshold;

	void OnMassChanged(float updatedMass) {
		Debug.Log(transform.name + ": mass is now " + updatedMass);
		mass = updatedMass;
		UpdateSize();
		// TODO: UpdateText(); - update the text that displays the mass
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Food")) {
			string foodId = other.transform.name;
			CmdTellServerWhichFoodWasEaten(foodId);
		} else if (other.gameObject.CompareTag("Blob")) {
			float otherMass = other.gameObject.GetComponent<PlayerEat>().mass;
			if (mass > otherMass + threshold) {
				CmdTellServerAteOther(other.gameObject);
			} else if (mass + threshold < otherMass) {
				Debug.Log("Eaten!");
				CmdTellServerEatenByOther(gameObject);
			}
		}
	}

	void UpdateSize() {
		float diameter = Mathf.Pow (mass, 0.5f);
		Vector3 position = new Vector3(0, diameter/2f, 0);
		Vector3 scale = new Vector3(diameter, diameter, diameter);
		transform.GetComponent<SphereCollider>().radius = diameter/2;
		transform.GetComponent<SphereCollider>().center = new Vector3(0, diameter/2, 0);
		transform.Find("Body").transform.localScale = scale;
		transform.Find("Body").transform.localPosition = position;
		transform.Find("Player Head").transform.localPosition = position;
	}

	[Command]
	void CmdTellServerWhichFoodWasEaten(string foodId) {
		Debug.Log("Server: " + foodId + " was eaten");
		mass += 0.5f;
		UpdateSize();
		GameObject.Find("FoodManager").GetComponent<FoodSpawner>().DestroyFood(foodId);
	}

	[Command]
	void CmdTellServerAteOther(GameObject other) {
		float otherMass = other.GetComponent<PlayerEat>().mass;
		mass += otherMass;
		UpdateSize();
	}

	[Command]
	void CmdTellServerEatenByOther(GameObject eaten) {
		Network.CloseConnection (Network.connections [0], true);
		Application.LoadLevel("Menu");
		//Destroy(eaten); // TODO: Handle it better. Go to menu/respawn.
	}
}
