using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sekkin : MonoBehaviour
{

    float change;
    float distance;
    public GameObject target;
    Vector3 henka;
    Vector3 pos3;

    void Start()
    {

    }

    void Update()
    {

        change += Time.deltaTime;
        //this.transform.localPosition = new Vector3(-15 + change, 0, 0);
        //this.GetComponent<CharacterJoint>().connectedAnchor = new Vector3(-15 + change, 0, 0);

        Vector3 pos1 = this.transform.position;
        Vector3 pos2 = target.transform.position;

        distance = Vector3.Distance(pos1, pos2);

        Debug.Log(distance);
        //Debug.Log((pos2 - pos1)/distance);//(pos2 - pos1)/distanceこれは１秒で1進む速さっぽい

        henka = (pos2 - pos1) / distance * Time.deltaTime * 10 ;

        this.GetComponent<Rigidbody>().position += henka;
        pos3 = pos2 - pos1;//this.transform.localPosition;
        //this.GetComponent<CharacterJoint>().connectedAnchor = pos3;


    }


    private void LateUpdate()
    {

    }

    public Vector3 getHenka(){
        return pos3;
    }
}