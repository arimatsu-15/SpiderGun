using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShitenK : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            Destroy(this.gameObject);
        }
    }
}
