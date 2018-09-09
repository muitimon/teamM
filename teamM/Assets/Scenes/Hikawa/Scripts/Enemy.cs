﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private GameObject Idol;
	private GameObject ScoreManager;
	[SerializeField] private float rotate = 30f;
	private float rotateSpeed = 2f;

	// 死亡フラグ
	private bool death = false;

	//[SerializeField] private float speed = 1f;
	// Idolの前で止まる距離
	[SerializeField] private float stopDistance = 100.0f;

	private Animator animator;

	void Start () {
		Idol = GameObject.FindGameObjectWithTag("Idol");
		animator = GetComponent<Animator>();
		ScoreManager = GameObject.Find("ScoreManager");
	}
	
	void Update () {
		// Idolの方向を向く
		Transform target = Idol.transform;
		this.transform.LookAt(target);
		this.transform.Rotate(new Vector3(0, rotate, 0));

		if(stopDistance <= Vector3.Distance(target.position, this.transform.position)){
			// Idolから遠い場合はIdolに向かう
			animator.SetBool("Walk", true); // アニメーションで前進
			animator.SetInteger("Idle", 0);
			//transform.Translate(Vector3.forward * Time.deltaTime * speed * 1); // 座標移動で前進
		}else{
			// Idolにたどり着いたらIdle状態に変更
			animator.SetInteger("Idle", Random.Range(1, 4));
			animator.SetBool("Walk", false);
		}
	}

	// tag "Pcylium"に触れたら死ぬ
	void OnCollisionEnter(Collision other){
		Debug.Log (other.gameObject.tag);
		if(!death && other.gameObject.tag == "Pcylium"){
			
			//ScoreManager.GetComponent<ScoreManager>().addScore();
			StartCoroutine("Death");
		}
	}

	private IEnumerator Death(){
		Debug.Log ("test");
		death = true;
		animator.SetBool("Death", true);

    	yield return new WaitForSeconds(5.0f);
		Destroy(this.gameObject);
	}
}
