using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//月の公転
//とりあえず1日で一周させる
public class MoonRevolution : MonoBehaviour {

    [SerializeField]
    private TimeAdministration worldClock;
    private int hour, minutes, seconds;
    private float rotateRad;

    void Start() {
        worldClock = GameObject.Find("sunCentor").GetComponent<TimeAdministration>();
        clockUpdate();

    }

    void Update() {
        clockUpdate();
        rotateRad = ( hour * 60 * 60 + minutes * 60 + seconds ) / (float)( 24 * 60 * 60 );
        //Debug.Log(rotateRad);
        transform.localEulerAngles = new Vector3(0, rotateRad * 360, 0);
//        transform.Rotate(new Vector3(0, rotateRad*10, 0), Space.Self);
    }

    private void clockUpdate() {
        hour = worldClock.Hour;
        minutes = worldClock.Minutes;
        seconds = worldClock.Seconds;
    }
}
