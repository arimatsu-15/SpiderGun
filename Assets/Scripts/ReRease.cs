using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReRease : MonoBehaviour {

   
    private Rigidbody _rigidbody;
    private CharacterJoint _characterjoint;

	// Use this for initialization
    void Start () {
        _rigidbody = this.GetComponent<Rigidbody>();
        _characterjoint = this.GetComponent<CharacterJoint>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(Input.GetKey("k")){

            Debug.Log(_rigidbody.velocity);
            //Vector3 start = new Vector3(_rigidbody., 0,0);

            this._characterjoint.connectedBody = null;


            //this._rigidbody.AddForce(start);
        }
	}
}
