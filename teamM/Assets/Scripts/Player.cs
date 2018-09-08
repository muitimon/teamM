using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	Pcylium pcylium;

	[SerializeField]
	PcyliumHolder pcyliumHolder;

	[SerializeField]
	AttackerPcyliums attackerPcylium;

	int count = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (count == 0 && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) {
			var c = OVRInput.GetActiveController();
			var localPos = OVRInput.GetLocalControllerPosition(c);
			if(localPos.y > -0.2f) {
				count = 40;
				/* 以下のようにしてコントローラの状態を参照する事ができます。
				DebugOutput.Write(
					"¥n" +
					"Controller Stats" +
					"  Position:" + OVRInput.GetLocalControllerPosition(c).ToString() +
					"  AngleVel:" + OVRInput.GetLocalControllerAngularVelocity(c).ToString() + 
					"  AngleAcc:" + OVRInput.GetLocalControllerAngularAcceleration(c).ToString() +
					"  Rotation:" + OVRInput.GetLocalControllerRotation(c).ToString()
				);
				*/
			}
		}
	}

	void FixedUpdate() {
		count = Mathf.Max(0, count - 1);
	}
}
