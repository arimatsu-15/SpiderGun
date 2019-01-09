using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shiten : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject player; //playerの現在位置取得
    Vector3 playerPos;
    int shitenPP; //shitenPointの取得
                 // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }

    public void moveShiten(){
        shitenPP = gameManager.GetShitenPoint();
        playerPos = player.transform.position;
        this.transform.position = playerPos + new Vector3(shitenPP, 0, 0);
    }
}
