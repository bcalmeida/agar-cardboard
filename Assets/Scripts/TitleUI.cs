using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TitleUI : MonoBehaviour {

	void OnGUI()
	{
		//GUI.DrawTexture(new Rect(
		//	Screen.width/2 - titleTexture.width, 
		//	Screen.height/2-titleTexture.height*2 - 150, 
		//	titleTexture.width*2,
		//	titleTexture.height*2), titleTexture);

		int posY = Screen.height/2 - 100;

		//tankName = GUI.TextField(new Rect(Screen.width/2 - 10, posY, 100, 20), tankName, 20);	
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
		//posY += 38;
		
		//if (GUI.Button(new Rect(Screen.width/2 - 100, posY, 200, 33), "Join Local Game"))
		//{
		//	NetworkManager.singleton.StartClient();
		//}		
		//posY += 44;		
	}
}
