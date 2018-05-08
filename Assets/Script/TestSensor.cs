using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSensor : MonoBehaviour {


    private Gyroscope gyroscope;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gyroTest())
        {
            transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
        }
	}

    private bool gyroTest()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroscope = Input.gyro;
            gyroscope.enabled = true;

            return true;
        }
        return false;
    }
}
