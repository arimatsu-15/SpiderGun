using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webPrefab : MonoBehaviour
{

    GameObject gameManager;



    int hit;
    // Use this for initialization
    void Start()
    {
        //gameManager = GameObject.Find("gamemanager");
        hit = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;//他のオブジェクトと衝突したら止まる
        Debug.Log("Hitting");
        hit = 1;
    }


   



    public int hitTest(){
        return hit;
    }
}
