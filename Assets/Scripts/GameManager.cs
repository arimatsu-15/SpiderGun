using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private int shitenPoint;
    public GameObject shiten;
    public GameObject player;
    Vector3 playerPos;
	// Use this for initialization
	void Start () {
        shitenPoint = 20;
        playerPos = player.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(Input.GetKey("j") && shitenPoint<100){
            shitenUpPoint();
        }
        if(Input.GetKey("f") && shitenPoint>19){
            shitenDownPoint();
        }

        //Debug.Log(shitenPoint);
	}

    public void shitenUpPoint(){
        shitenPoint += 1;
        shitenMove();//やりたいことの順番は上から下の順番じゃなくて、クラスの階層に分けて解決するべし
    }
    public void shitenDownPoint(){
        shitenPoint -= 1;
        shitenMove();
    }
    public void shitenMove(){
        shiten.transform.position = playerPos + new Vector3(shitenPoint, 0, 0);
    }

    public int GetShitenPoint(){
        return shitenPoint;
    }
}
