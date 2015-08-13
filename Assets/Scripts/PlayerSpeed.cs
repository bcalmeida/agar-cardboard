using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSpeed : NetworkBehaviour {

  [SyncVar(hook="OnSpeedChanged")] public float speed;

  void OnSpeedChanged(float newSpeed) {
    Debug.Log(transform.name + " : speed changed to " + speed);
  }

  public void UpdateSpeed(float mass) {
    if (mass < 200) {
      speed = (float)(mass * -0.05 + 12.05);
    } else {
      speed = 2F;
    }
  }

}
