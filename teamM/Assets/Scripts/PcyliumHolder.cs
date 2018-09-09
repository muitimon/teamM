using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcyliumHolder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void MagazineReload(GameObject myHand) {
		myHand.SendMessage ("EnablePcylium");
	}
}
