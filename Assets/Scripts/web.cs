using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class web : MonoBehaviour
{
    public GameObject shiten;
    public GameObject player;
    Vector3 shitenP;
    Vector3 playerP;
    float dist;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        shitenP = shiten.transform.position;
        playerP = player.transform.position;
        this.transform.position = (shitenP - playerP) / 2.0f;
        dist = Vector3.Distance(shitenP, playerP);
        this.transform.localScale = new Vector3(1.0f, dist - 1.0f, 1.0f);

        Debug.Log("shitenP"+shitenP);
        //Debug.Log("position" + this.transform.position);
        //Debug.Log("playerP"+playerP);
        //Debug.Log("dist-1f"+ this.transform.position.y);//webの長さ確認

    }
}
