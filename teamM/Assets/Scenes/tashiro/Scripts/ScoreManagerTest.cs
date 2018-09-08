using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerTest : MonoBehaviour {

	[SerializeField] private ScoreManager AnotherScript;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		GameObject AnotherObject = GameObject.Find("ScoreManager");
		ScoreManager AnotherScript = AnotherObject.GetComponent<ScoreManager>();
		if (AnotherScript) {
			AnotherScript.addScore();
			Debug.Log(AnotherScript.getScore());
		} else {
			Debug.Log("No game object called wibble found");
		}
	}
}
