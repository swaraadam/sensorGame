using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSensor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gyroInput();
	}

    void gyroInput()
    {
        transform.rotation = playerPos(Input.gyro.attitude);
    }

    private static Quaternion playerPos(Quaternion a)
    {
        return new Quaternion(a.x, a.y, -a.z, -a.w);
    }
}
