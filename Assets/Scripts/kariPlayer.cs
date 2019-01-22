using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kariPlayer : MonoBehaviour {
    Vector3 playerPos;
    Vector3 shitenPos;
    Vector3 henka;
    float distance;
    public GameObject gameManager;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad))
        {

            playerPos = this.transform.position;
            shitenPos = gameManager.GetComponent<kariGameManager>().GetShitenPos();
            if (shitenPos == null)
            {
                return;
            }
            distance = Vector3.Distance(playerPos, shitenPos);
            henka = (shitenPos - playerPos) / distance * 50f;
            this.GetComponent<Rigidbody>().position += henka;
        }
    }
}
