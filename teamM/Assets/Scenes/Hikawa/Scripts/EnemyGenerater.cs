using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerater : MonoBehaviour {

	[SerializeField] private float nextGenerate = 5.0f;
	[SerializeField] private float interval = 0.5f;

	public GameObject[] EnemyPrefs = new GameObject[6];

	void Start () {
		StartCoroutine("EnemyGenerate");
	}

	private IEnumerator EnemyGenerate(){
		while(true){
			yield return new WaitForSeconds(nextGenerate);
			nextGenerate = nextGenerate - interval;
			if(nextGenerate < 1.0f){
				nextGenerate = 1.0f;
			}
			// オブジェクトの座標
			float x = Random.Range(-3.5f, 3.2f);
			float y = Random.Range(0.0f, 0.0f);
			float z = Random.Range(0.0f, 0.0f);
			int rand = Random.Range(0, 6);
			GameObject Enemy = Instantiate(EnemyPrefs[rand], new Vector3(x, y, z), Quaternion.identity);
			Enemy.transform.parent = transform;
			Enemy.transform.localScale = new Vector3(1, 1, 1);
		}
	}
}
