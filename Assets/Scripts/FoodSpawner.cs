using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class FoodSpawner : NetworkBehaviour {

	public GameObject foodPrefab;
	public int maxCount;
	private int counter;

	public override void OnStartServer() {
		counter = 0;
		for (int i = 0; i < maxCount; i++) {
			SpawnFood();
		}
	}

	// TODO: Recycle game object instead of recreating
	public void DestroyFood(string foodID) {
		GameObject foodObject = GameObject.Find(foodID);
		Destroy(foodObject);
		SpawnFood();
	}

	void SpawnFood() {
		counter++;
		GameObject foodObject = GameObject.Instantiate(foodPrefab, RandomPosition(), Quaternion.identity) as GameObject;
		foodObject.GetComponent<FoodID>().SetFoodID(counter);
		NetworkServer.Spawn(foodObject);
	}

	Vector3 RandomPosition() {
		float range = 199f;
		float randX = Random.Range(-range, range);
		float randZ = Random.Range(-range, range);
		return new Vector3(randX, 0.5f, randZ);
	}
}
