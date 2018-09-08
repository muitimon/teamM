using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour {

	private int count = 0;
	public int speed = 60;

	public GameObject[] EnemyPrefs = new GameObject[6];

	void Start () {

	}
	
	void Update () {
		if(count >= speed){
			// オブジェクトの座標
			float x = Random.Range(-10.0f, 10.0f);
			float y = Random.Range(0.0f, 0.0f);
			float z = Random.Range(0.0f, 0.0f);
			int rand = Random.Range(0, 6);
			GameObject Enemy = Instantiate(EnemyPrefs[rand], new Vector3(x, y, z), Quaternion.identity);
			Enemy.transform.parent = transform;
			count = 0;
		}
		count++;
	}
}
