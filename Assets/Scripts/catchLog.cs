using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class catchLog : MonoBehaviour {

    public Vector3 SetLeaveSpeed;
    public GameObject gameManager;
    // Use this for initialization
    void Start () {
        this.GetComponent<Text>().text = "whatsUp";

    }
	
	// Update is called once per frame
	void Update () {

        SetLeaveSpeed = gameManager.GetComponent<GameManager>().GetLeaveSpeed();

        this.GetComponent<Text>().text = "leaveSpeed=" + SetLeaveSpeed;
    }
}
