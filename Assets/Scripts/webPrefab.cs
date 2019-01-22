using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webPrefab : MonoBehaviour
{

    GameObject gameManager;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;//他のオブジェクトと衝突したら止まる
    }

}
