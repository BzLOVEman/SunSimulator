using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private float Rotation period;

    //以下現在位置に関する情報
    //観測者か？（falseなら以下パラメータは確認しない）
    public protected bool isThereObserver;
    //経度
    [SerializeField]
    private float longitude;
    //緯度
    [SerializeField]
    private float latitude
    //時刻を主導する
    public bool doTimeLead;
    //現在の時刻
    private int hour, minutes, seconds;
    private float rotateRad;
    float timeWas;

    void Start() {
        worldClock = GameObject.Find("sunCentor").GetComponent<TimeAdministration>();
        clockUpdate();
        timeWas = ( hour * 60 * 60 + minutes * 60 + seconds );
    }

    void Update() {
        clockUpdate();
        rotateRad = (( hour * 60 * 60 + minutes * 60 + seconds )-timeWas) / (float)( 24 * 60 * 60 );
        //Debug.Log(rotateRad);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y+rotateRad*360, transform.localEulerAngles.z);
        //        transform.Rotate(new Vector3(0, rotateRad*10, 0), Space.Self);
        timeWas = hour * 60 * 60 + minutes * 60 + seconds;
    }

    private void clockUpdate() {
        hour = worldClock.Hour;
        minutes = worldClock.Minutes;
        seconds = worldClock.Seconds;
    }
}
