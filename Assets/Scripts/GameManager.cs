using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private int shitenPoint;
    public GameObject shiten;
    public GameObject player;
    public GameObject web;

	// Use this for initialization
	void Start () {
        shitenPoint = 20;

	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey("j") && shitenPoint<100){
            shitenUpPoint();
        }
        if(Input.GetKey("f") && shitenPoint>19){
            shitenDownPoint();
        }
        if(Input.GetKey("g")){
            player.transform.position += new Vector3(1, 0, 0);
        }





        //web.transform.position = (shiten.transform.position + player.transform.position) / 2;

        shiten.transform.position = player.transform.position + new Vector3(shitenPoint, 0, 0);

        //shitenMove();

        Debug.Log(shitenPoint);
    }

    //void LastUpdate(){
        //float webScale = Vector3.Distance(player.transform.position, shiten.transform.position);
        //web.transform.localScale = new Vector3(1.0f, webScale - 0.5f, 1.0f);
    //}

    public void shitenUpPoint(){
        shitenPoint += 1;

    }
    public void shitenDownPoint(){
        shitenPoint -= 1;

    }
    public void shitenMove(){


    }



    public int GetShitenPoint(){
        return shitenPoint;
    }
}
