using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour {

	private int count = 0;
	public int speed = 60;

	public GameObject EnemyPrefs;

	void Start () {

	}
	
	void Update () {
		if(count >= speed){
			//オブジェクトの座標
			float x = Random.Range(-10.0f, 10.0f);
			float y = Random.Range(0.0f, 0.0f);
			float z = Random.Range(0.0f, 0.0f);
			GameObject Enemy = Instantiate(EnemyPrefs, new Vector3(x, y, z), Quaternion.identity);
			Enemy.transform.parent = transform;
			count = 0;
		}
		count++;
	}
}
