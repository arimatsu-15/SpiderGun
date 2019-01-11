using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * レーザーポインターを出すクラス
 */
public class LaserPointer : MonoBehaviour
{

    bool One;

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
    private GameObject ShitenPrefab;
    [SerializeField]
    private float ShitenPower = 50000f;



    private void Start()
    {
        One = true;
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




    public void Shot(Transform pointer){



                var ShitenInstance = Instantiate(ShitenPrefab, pointer.position, pointer.rotation) as GameObject;
                ShitenInstance.GetComponent<Rigidbody>().AddForce(ShitenInstance.transform.forward * ShitenPower);
                


       




    }









    void Update()
    {


        var pointer = Pointer; // コントローラーを取得
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

        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
            Shot(pointer);
        }


    }
}