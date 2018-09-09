using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pcylium : MonoBehaviour {

	[SerializeField]
	private GameObject model;

	Vector3 origin = Vector3.zero;

	// Use this for initialization
	void Start () {
		origin = transform.position;
		DebugOutput.Write ("Pcylium Initialized!");
	}
	
	// Update is called once per frame
	void Update () {
		var controller = OVRInput.GetActiveController();
		var pos = OVRInput.GetLocalControllerPosition (controller);
		var trigger = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);

		// 手に持っているサイリウムをoculusコントローラの座標・回転に追従
		transform.position = origin + pos * 10;
		transform.rotation= OVRInput.GetLocalControllerRotation(controller);

		if (trigger) {
			// 投げ検出
			// サイリウムの投げ検出
			if (model.activeSelf) {
				if(pos.y > -0.2f) {
					System.Console.WriteLine ("Pcylium");
					DebugOutput.Write ("Throw!");

					/* 以下のようにしてコントローラの状態を参照する事ができます。
					DebugOutput.Write(
						"¥n" +
						"Controller Stats" +
						"  Position:" + OVRInput.GetLocalControllerPosition(controller).ToString() +
						"  AngleVel:" + OVRInput.GetLocalControllerAngularVelocity(controller).ToString() + 
						"  AngleAcc:" + OVRInput.GetLocalControllerAngularAcceleration(controller).ToString() +
						"  Rotation:" + OVRInput.GetLocalControllerRotation(controller).ToString()
					);
					*/

					//サイリウム生成
					AttackerPcyliums.Attack(transform.position, transform.rotation);
					model.SetActive (false);
					StartCoroutine (ReloadMagazine (0.5f));
				}
			}
		} else {
			// 音楽に合わせてサイリウムを振っていることを検出
		}
	}

	IEnumerator ReloadMagazine(float sec) {
		yield return new WaitForSeconds (sec);
		model.SetActive (true);
	}
}
