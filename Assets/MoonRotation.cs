using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//月の自転
public class MoonRotation : MonoBehaviour {

    

    void Start() {
        
    }

    void Update() {
        transform.LookAt(transform.parent);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 270, transform.localEulerAngles.z);
    }
}
