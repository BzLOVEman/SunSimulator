using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//地球の自転
public class EarthRotation : MonoBehaviour {

    //時間管理プログラムのインスタンス化
    [SerializeField]
    private TimeAdministration worldClock;
    //地軸の傾き
    [SerializeField]
    private float tiltAxis;
    //自転周期(単位：秒)
    [SerializeField]
    private float rotationPeriod;

    //以下現在位置に関する情報
    //観測者か？（falseなら以下パラメータは確認しない）
    public bool isThereObserver;
    //経度
    [SerializeField]
    private float longitude;
    //緯度
    [SerializeField]
    private float latitude;
    //時刻を主導する
    public bool doTimeLead;
    //現在の時刻
    [SerializeField]
    private int month,day,hour, minutes, seconds,miliSeconds;
    
    //以下ローカル変数
    //回転角
    private float rotateRad;
    //1フレーム前の時間
    int timeWas;

    void Start() {
        worldClock = GameObject.Find("sunCentor").GetComponent<TimeAdministration>();
        clockUpdate();
    }

    void Update() {
        clockUpdate();
        rotateRad = (( hour * 60 * 60 + minutes * 60 + seconds )-timeWas) / (float)( 24 * 60 * 60 );
        //Debug.Log(rotateRad);
        //回転角の決定
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y+rotateRad*360, transform.localEulerAngles.z);
        //        transform.Rotate(new Vector3(0, rotateRad*10, 0), Space.Self);
        timeWas = hour * 60 * 60 + minutes * 60 + seconds;
    }

    private void clockUpdate() {
        if(doTimeLead){
            //月の計算を詰める必要あり。
            int[] tmp=new int[5]{
                30*24*60*60*100,
                24*60*60*100,
                60*60*100,
                60*100,
                100,
                1,
            };
            timeWas = (
                (month - 1) * tmp[0] +
                (day - 1) * tmp[1] +
                hour * tmp[2] +
                minutes * tmp[3] +
                seconds*tmp[4] +
                miliSeconds*tmp[5]
            );

            try {
                timeWas += Time.deltaTime*tmp[5];
                
                month = timeWas/tmp[0]+1;
                timeWas%=tmp[0];
                day=timeWas/tmp[1]+1;
                timeWas%=tmp[1];
                hour=timeWas/tmp[2];
                timeWas%=tmp[2];
                minutes=timeWas/tmp[3];
                timeWas%=tmp[3];
                seconds=timeWas/tmp[4];
                timeWas%=tmp[4];
                miliSeconds=timeWas/tmp[5];
                
                 
            } catch (System.Exception) {
                
                throw;
            }
        }else{
            month=worldClock.Month;
            day=worldClock.Day;
            hour = worldClock.Hour;
            minutes = worldClock.Minutes;
            seconds = worldClock.Seconds;
            miliSeconds=worldClock.MiliSeconds;
        }
    }
}
