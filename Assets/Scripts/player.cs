using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{


    [SerializeField]
    private GameObject ShitenKPrefab;
    public GameObject supershitenPrefab;
    public GameObject playerllast;
    private Rigidbody _rigidbody;
    private CharacterJoint _characterjoint;
    Vector3 leave_pos = new Vector3();
    Vector3 oss;
    // Use this for initialization
    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
        _characterjoint = this.GetComponent<CharacterJoint>();

        oss = new Vector3(10, 10, 10);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("p"))
        {

            var sShitenInstance = Instantiate(supershitenPrefab,oss, Quaternion.identity) as GameObject;
            sShitenInstance.GetComponent<CharacterJoint>().connectedBody = playerllast.GetComponent<Rigidbody>();

        }


        if (Input.GetKey("k"))
        {
            Debug.Log(_rigidbody.velocity);
            leave_pos = _rigidbody.velocity;
            leave_parent();
        }

        if (Input.GetKeyDown("l")){
            var ShitenInstance = Instantiate(ShitenKPrefab) as GameObject;
            ShitenInstance.GetComponent<Rigidbody>().AddForce(ShitenInstance.transform.forward * 5000f);
        }



        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
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
