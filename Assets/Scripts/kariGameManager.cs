using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * レーザーポインターを出すクラス
 */

public class kariGameManager : MonoBehaviour
{


    [SerializeField]
    private Transform _RightHandAnchor; // 右手

    [SerializeField]
    private Transform _LeftHandAnchor;  // 左手

    [SerializeField]
    private Transform _CenterEyeAnchor; // 目の中心

    [SerializeField]
    private float _MaxDistance = 100.0f; // 距離

    [SerializeField]
    private LineRenderer _LaserPointerRenderer; // LineRenderer

    [SerializeField]
    private GameObject webPrefab;
    [SerializeField]
    private float webPower = 5000f;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject shitenPrefab;

    Vector3 playerPos;
    Vector3 shitenPos;
    Vector3 henka;
    float distance;
    Quaternion shitenRot;

    GameObject webInstance;
    GameObject shitenInstance;

    private void Start()
    {

    }

    // コントローラー
    private Transform Pointer
    {
        get
        {
            // 現在アクティブなコントローラーを取得
            var controller = OVRInput.GetActiveController();
            if (controller == OVRInput.Controller.RTrackedRemote)
            {
                return _RightHandAnchor;
            }
            else if (controller == OVRInput.Controller.LTrackedRemote)
            {
                return _LeftHandAnchor;
            }
            // どちらも取れなければ目の間からビームが出る
            return _CenterEyeAnchor;
        }


    }

    public void Shot(Transform pointer)
    {
        webInstance = Instantiate(webPrefab, pointer.position, pointer.rotation) as GameObject;
        webInstance.GetComponent<Rigidbody>().AddForce(webInstance.transform.forward * webPower);

    }
   
    public void makeRope (Vector3 v,Quaternion r){
        Destroy(webInstance); //ぶち当てた最初のweb先端は削除
        shitenInstance = Instantiate(shitenPrefab, v, r) as GameObject; //cahracterJointもちのshitenの先端生成
        shitenInstance.GetComponent<CharacterJoint>().connectedBody = player.GetComponent<Rigidbody>();
    }

    public Vector3 GetShitenPos(){
        return shitenPos;
    }

    void Update() //update内も上下しっかり関係あり
    {



        var pointer = Pointer; // コントローラーを取得

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Shot(pointer);
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            Destroy(shitenInstance);
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad)) //タッチパッドDown
        {
            shitenPos = webInstance.transform.position;
            shitenRot = webInstance.transform.rotation;
            makeRope(shitenPos, shitenRot);



        }





        // コントローラーがない or LineRendererがなければ何もしない
        if (pointer == null || _LaserPointerRenderer == null)
        {
            return;
        }
        // コントローラー位置からRayを飛ばす
        Ray pointerRay = new Ray(pointer.position, pointer.forward);

        // レーザーの起点
        _LaserPointerRenderer.SetPosition(0, pointerRay.origin);

        RaycastHit hitInfo;
        if (Physics.Raycast(pointerRay, out hitInfo, _MaxDistance))
        {
            // Rayがヒットしたらそこまで
            _LaserPointerRenderer.SetPosition(1, hitInfo.point);//1は終点の合図
        }
        else
        {
            // Rayがヒットしなかったら向いている方向にMaxDistance伸ばす
            _LaserPointerRenderer.SetPosition(1, pointerRay.origin + pointerRay.direction * _MaxDistance);
        }


    }
}