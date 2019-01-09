using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{


    private Rigidbody _rigidbody;
    private CharacterJoint _characterjoint;
    Vector3 leave_pos = new Vector3();
    // Use this for initialization
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        _characterjoint = this.GetComponent<CharacterJoint>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (Input.GetKey("k"))
        {
            Debug.Log(_rigidbody.velocity);
            leave_pos = _rigidbody.velocity;
            leave_parent();
        }
    }

    public void leave_parent ()
    {
        //this._characterjoint.connectedBody = null;
        Destroy(_characterjoint);
        leave_stage();
    }

    public void leave_stage ()
    {
        _rigidbody.AddForce(leave_pos);
    }
}
