using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerPcyliums : MonoBehaviour {

	[SerializeField]
	private GameObject attackerPcyliumPrefab;

	private static AttackerPcyliums inst;

	// Use this for initialization
	void Start () {
		inst = this;
		attackerPcyliumPrefab = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
		attackerPcyliumPrefab.transform.localScale = Vector3.one * 0.5f; //new Vector3 (0.05f, 0.05f, 0.05f);
		attackerPcyliumPrefab.AddComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public static void Attack(Vector3 pos, Quaternion rot) {
		inst._Attack(pos, rot);
	}

	void _Attack(Vector3 pos, Quaternion rot) {
		var obj = Instantiate(attackerPcyliumPrefab, transform);
		//obj.transform.position = pos;
		//obj.transform.rotation = rot;
		//obj.GetComponent<Rigidbody> ().AddForce (rot.eulerAngles);
		StartCoroutine (DelayedRemove (obj, 15));
	}

	IEnumerator DelayedRemove(GameObject attackerPcylium, int seconds) {
		yield return new WaitForSeconds (seconds);
		Destroy (attackerPcylium);
	}
}
