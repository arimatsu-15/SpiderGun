using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    Vector3 playerPos;
    Vector3 shitenPos;
    Vector3 henka;
    Vector3 nextPlayerPos;
    float distance;
    public GameObject gameManager;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //パッド、トリガー押している時、お互いの位置から接近ベクトルを割り出す
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad) && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            playerPos = this.transform.position;
            shitenPos = gameManager.GetComponent<GameManager>().GetShitenPos();
            distance = Vector3.Distance(playerPos, shitenPos);
            henka = (shitenPos - playerPos) / distance;//接近の単位ベクトルの算出
            this.GetComponent<Rigidbody>().position += henka * 5; //velocityとかrigの世界を動かしてるわけではなくて、直接座標を変えてしまってる
        }
    }
}
