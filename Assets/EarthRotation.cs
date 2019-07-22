using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//地球の自転
public class EarthRotation : MonoBehaviour {

    [SerializeField]
    private TimeAdministration worldClock;
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
