using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerColor : NetworkBehaviour {

  [SyncVar] public Color color;

  void Awake() {
    Renderer renderer = transform.Find("Body").GetComponent<Renderer>();
    color = new Color(Random.value, Random.value, Random.value);
    renderer.material.SetColor("_Color", color);
  }

}
