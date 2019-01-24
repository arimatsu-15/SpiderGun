using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webPrefab : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    //colliderだと微妙にうまくいかなかった
    private void OnTriggerEnter(Collider other)
    {
        //web飛ばしいて止まるのはtag=stageのみ、tag忘れがち
        if(other.gameObject.tag == "stage"){
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

}
