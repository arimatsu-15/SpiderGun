using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public Transform target;
    public float offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x = target.position.x + offset;
        pos.y = target.position.y + offset;
        pos.z = target.position.z + offset;
        transform.position = pos;
    }
}
