using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private GameObject Idol;
	private float rotateSpeed = 2f;

	[SerializeField] public float speed = 1f;

	void Start () {
		Idol = GameObject.FindGameObjectWithTag("Idol");
	}
	
	void Update () {
		// Idolの方向を向く
		Transform target = Idol.transform;
		this.transform.LookAt(target);
		// 前進する
		transform.Translate(Vector3.forward * Time.deltaTime * speed * 1 );
	}
}
