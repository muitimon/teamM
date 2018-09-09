using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pcylium : MonoBehaviour {

	[SerializeField]
	private GameObject model;

	Vector3 origin = Vector3.zero;
	int count = 0;

	public bool State {
		get {
			return model.activeSelf;
		}
		set {
			model.SetActive(value);
		}
	}


	void OnEnable() {
		count = 0;
	}

	// Use this for initialization
	void Start () {
		origin = transform.position;
		DebugOutput.Write ("Pcylium Initialized!");
	}
	
	// Update is called once per frame
	void Update () {
		var controller = OVRInput.GetActiveController();
		var pos = OVRInput.GetLocalControllerPosition (controller);

		// 手に持っているサイリウムをoculusコントローラの座標に追従
		transform.position = origin + pos * 10;

		// 投げ検出
		// サイリウムの投げ検出
		if (count == 0 && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) {
			if(pos.y > -0.2f) {
				count = 40;
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
				//var attackerPcyliumPrefab = Instantiate ();

				//
			}
		}
	}

	void FixedUpdate() {
		count = Mathf.Max(0, count - 1);
	}
}
