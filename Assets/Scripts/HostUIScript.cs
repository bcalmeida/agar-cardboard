using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class HostUIScript : MonoBehaviour
{
	public string roomName;
	public uint roomSize = 8;
	
	void Start () 
	{
		System.Random random = new System.Random();
		roomName = "TOG" + random.Next(1000,9999);
	}
	
	void OnGUI()
	{
		int posY = Screen.height/2;
		
		GUI.Label(new Rect(Screen.width/2-400, posY, 400, 60), "Room Name:");
		roomName = GUI.TextField(new Rect(Screen.width/2 - 300, posY, 300, 50), roomName);
		posY += 70;
		
		GUI.Label(new Rect(Screen.width/2-400, posY, 400, 60), "Room Size:");
		roomSize = System.Convert.ToUInt32(GUI.TextField(new Rect(Screen.width/2-300, posY, 400, 50), roomSize.ToString()));
		posY += 70;
		
		if (roomName != "")
		{
			if(GUI.Button(new Rect(Screen.width/2-500,posY,500,60),"Create Room"))
			{
				Debug.Log ("Creating match [" + roomName + ":" + roomSize + "]");
				NetworkManager.singleton.matchMaker.CreateMatch(roomName, roomSize, true, "", NetworkManager.singleton.OnMatchCreate);
			}
		}
		
		posY += 140;
		if (GUI.Button (new Rect(Screen.width/2-100 , Screen.height - 50, 200, 30), "[ Back ]") || Input.GetKeyDown(KeyCode.Escape))
		{
			NetworkManager.singleton.ServerChangeScene("title");
		}
	}	
}
