using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class DebugOutput : MonoBehaviour {

	private static DebugOutput inst;
	private static string loggingServerURL;


	public static void Write(string str) {
		inst.StartCoroutine(Upload(str));
	}

	static IEnumerator Upload(string data) {
		var www = UnityWebRequest.Post(loggingServerURL, data);
		yield return www.SendWebRequest();
	}

	void Start() {
		inst = this;
		loggingServerURL = "http://00e85ee3.ngrok.io";
	}
}
