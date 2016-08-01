﻿using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {
	Rigidbody2D ourrigidbody;
	public float torque=4f;
	public float rotationtime = 1f;
	public float delaysecs=0;
	float delay=0;
	float counter=0;
	bool inrotation;
	// Use this for initialization
	void Start () {
	
		ourrigidbody = GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		delay += Time.deltaTime;
		if(Input.GetKeyDown(KeyCode.LeftArrow)&&ourrigidbody.angularVelocity==0f&&delay>=delaysecs){
			inrotation = true;
			ourrigidbody.AddTorque(torque);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)&&ourrigidbody.angularVelocity==0f&&delay>=delaysecs){
			inrotation = true;
			ourrigidbody.AddTorque(-1f*torque);

		}
		if (inrotation == true) {
			counter += Time.deltaTime;
		
			if (counter >= rotationtime) {
				ourrigidbody.angularVelocity = 0;
				counter = 0;
				inrotation = false;
				delay = 0;
			}
		}
			


	}
}
