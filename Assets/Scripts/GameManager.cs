using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * レーザーポインターを出すクラス
 */

public class GameManager : MonoBehaviour
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
    Quaternion shitenRot;

    Vector3 latestPos;
    Vector3 playerSpeed;
    Vector3 leaveSpeed;
    Vector3 startSpeed;

    Vector3 conAncer;

    GameObject webInstance;
    GameObject shitenInstance;

    private void Start()
    {
        //スタート時の動き
        startSpeed = new Vector3(0, 400f, 0);
        player.GetComponent<Rigidbody>().AddForce(startSpeed);
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

    //shiten発射クラス
    public void Shot(Transform pointer)
    {
        webInstance = Instantiate(webPrefab, pointer.position, pointer.rotation) as GameObject;
        webInstance.GetComponent<Rigidbody>().AddForce(webInstance.transform.forward * webPower);

    }

    //振り子生成クラス
    public void makeRope (Vector3 v,Quaternion r){
        Destroy(webInstance); //ぶち当てた最初のweb先端は削除
        shitenInstance = Instantiate(shitenPrefab, v, r) as GameObject; //cahracterJointもちのshitenの先端生成
        shitenInstance.GetComponent<CharacterJoint>().connectedBody = player.GetComponent<Rigidbody>();
    }

    //playerに送るshitenの位置
    public Vector3 GetShitenPos(){
        return shitenPos;
    }

    //普通のリリース
    public void leaveDes1(){
        desDes();
    }
    public void desDes()
    {
        Destroy(webInstance);
        Destroy(shitenInstance);
    }

    //スピード出してリリース
    public void leaveDes2(){
        //leavePos = player.GetComponent<Rigidbody>().velocity;//速さは取得できてないんんだよ、だってrigトランスフォームで動かしてるわけだから
        leaveSpeed = playerSpeed;
        desDes2();
    }
    public void desDes2(){
        Destroy(webInstance);
        Destroy(shitenInstance);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        hassya();
    }
    public void hassya(){
        //*40ぐらいがちょうどいいみたい
        player.GetComponent<Rigidbody>().AddForce(leaveSpeed*40);
    }

    //Log表示に送るleaveSpeed
    public Vector3 GetLeaveSpeed(){
        return leaveSpeed;
    }




    void Update() //update内も上下しっかり関係あり
    {
        //フレーム間でのスピードを測定、transformで強引に動かしてる時に使える！！！！！！
        playerSpeed = (player.transform.position - latestPos) / Time.deltaTime;
        latestPos = player.transform.position;

        var pointer = Pointer; // コントローラーを取得

        //トリガークリックでshitenInstance発射
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            Shot(pointer);
        }

        //トリガー離す、かつパッド押してない時にシンプルにjointから離れる
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            if (!OVRInput.Get(OVRInput.Button.PrimaryTouchpad)){
                leaveDes1();
            }
        }

        //トリガー離す、かつパッド押してる時に速度もらってjointから飛ぶ
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad)&& OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)){
            leaveDes2();
        }

        //トリガー押しっぱなし、かつパッド押した時に、shitenが生成される
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad)&& OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) 
        {
            shitenPos = webInstance.transform.position;
            shitenRot = webInstance.transform.rotation;
            makeRope(shitenPos, shitenRot);
        }

        //パッド、トリガー押しっぱなしでshitenに近づく、rigidのpositionを直接書き換えている
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad) && OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
                conAncer = player.transform.position - shitenInstance.transform.position;
                shitenInstance.GetComponent<CharacterJoint>().connectedAnchor = conAncer;
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