using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private GameObject Idol;
	[SerializeField] private float rotate = 30f;
	private float rotateSpeed = 2f;

	// 死んだ時のステータス
	private bool death = false;
	private int count = 0;

	//[SerializeField] private float speed = 1f;
	// Idolの前で止まる距離
	[SerializeField] private float stopDistance = 5.0f;

	private Animator animator;

	void Start () {
		Idol = GameObject.Find("Idol");
		animator = GetComponent<Animator>();
	}
	
	void Update () {
		// Idolの方向を向く
		Transform target = Idol.transform;
		this.transform.LookAt(target);
		this.transform.Rotate(new Vector3(0, rotate, 0));

		if(stopDistance <= Vector3.Distance(target.position, this.transform.position)){
			// 前進する
			animator.SetBool("Walk", true);
			//transform.Translate(Vector3.forward * Time.deltaTime * speed * 1);
		}else{
			animator.SetBool("Idle", true);
		}
		if(death){
			if(count >= 240){
				Destroy(this.gameObject);
			}else{
				count++;
			}
		}
	}

	// tag "Pcylium"に触れたら死ぬ
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Pcylium"){
			Death();
		}
	}

	void Death(){
		animator.SetBool("Death", true);
		death = true;
	}

	
}
