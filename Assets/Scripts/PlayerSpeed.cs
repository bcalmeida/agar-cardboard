using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerSpeed : NetworkBehaviour {

  [SyncVar(hook="OnSpeedChanged")] public float speed;

  void OnSpeedChanged(float newSpeed) {
    Debug.Log(transform.name + " : speed changed to " + speed);
  }

  public void UpdateSpeed(float mass) {
    speed = (float)(5/(1 + Math.Log(mass, 4.5))) + 2;
  }

}
