using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerCamera : MonoBehaviour {

	public Transform player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!player) return;
		transform.position = player.position - new Vector3(0, 0, 1);
	}
}
