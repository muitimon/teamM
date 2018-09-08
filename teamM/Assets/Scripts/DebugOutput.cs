using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DebugOutput : MonoBehaviour {

	private static DebugOutput inst;

	public static void Write(string str)
	{
		inst._Write(str);
	}

	void Start()
	{
		inst = this;
	}

	void _Write(string str)
	{
		StartCoroutine(Upload(str));
	}

	IEnumerator Upload(string data) {
		var loggingServerURL = "http://b5ae5c08.ngrok.io";
		var www = UnityWebRequest.Post(loggingServerURL, data);
		yield return www.SendWebRequest();
	}
}
