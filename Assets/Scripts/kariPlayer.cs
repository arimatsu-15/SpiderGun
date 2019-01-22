using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kariPlayer : MonoBehaviour {
    Vector3 playerPos;
    Vector3 shitenPos;
    Vector3 henka;
    Vector3 nextPlayerPos;
    Vector3 approaching;
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
            distance = Vector3.Distance(playerPos, shitenPos);
            henka = (shitenPos - playerPos) / distance;
            approaching = shitenPos - playerPos;
            this.GetComponent<Rigidbody>().position += henka * 10;
            nextPlayerPos = this.transform.position;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad))
        {
            this.transform.position = nextPlayerPos;
        }

    }

    public Vector3 GetHenka(){
        return approaching;
    }
}
