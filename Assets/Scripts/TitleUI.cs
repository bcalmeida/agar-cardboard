using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TitleUI : MonoBehaviour {

	void OnGUI()
	{
		int posY = Screen.height/2 - 100;
		posY += 40;

		float middle = Screen.width / 2;

		if (GUI.Button(new Rect(middle - 500, posY, middle + 500, 150), "Single Player Game"))
		{
			NetworkManager.singleton.StartHost();
		}
		posY += 160;
		
		if (GUI.Button(new Rect(middle - 500, posY, middle + 500, 150), "Host Multiplayer Game"))
		{
			NetworkManager.singleton.StartMatchMaker();
			Application.LoadLevel("HostMultiplayer");
		}
		posY += 160;
		
		if (GUI.Button(new Rect(middle - 500, posY, middle + 500, 150), "Join Multiplayer Game"))
		{
			NetworkManager.singleton.StartMatchMaker();
			Application.LoadLevel("JoinMultiplayer");			
		}	
	}
}
