using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sssiten : MonoBehaviour {

    float change;
    public sekkin Sekkin;
    Vector3 pos7;

    void Start()
    {

    }

    void Update()
    {

        change += Time.deltaTime;
        //this.GetComponent<CharacterJoint>().connectedAnchor = new Vector3(15 - change, 0, 0);

        Vector3 setHenka = Sekkin.getHenka();

        pos7.x = -setHenka.x;
        pos7.y = -setHenka.y;
        pos7.z = -setHenka.z;

        this.GetComponent<CharacterJoint>().connectedAnchor = pos7;
    }
}
