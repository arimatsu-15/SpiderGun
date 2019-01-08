using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingTest : MonoBehaviour {
    private Rigidbody _rigidbody;
	// Use this for initialization
	void Start () {
        _rigidbody = this.GetComponent<Rigidbody>();
        _rigidbody.AddForce(10000, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
