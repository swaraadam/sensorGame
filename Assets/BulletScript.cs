using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float bulletSpeed = 1.5f;
    public Rigidbody bullet;
    private Gyroscope gyroscope;
    private bool isGyro = false;

    private void Start()
    {
        isGyro = gyroTest();
    }

    // Update is called once per frame
    void Update () {
        if (PAProximity.proximity == PAProximity.Proximity.NEAR)
        {
            tembak();
        }
        if (isGyro)
        {
            transform.Rotate(0, -Input.gyro.rotationRateUnbiased.y, 0);
        }
    }

    void tembak()
    {
        Rigidbody bulletCreate = (Rigidbody)Instantiate(bullet, transform.position, transform.rotation);
        bulletCreate.velocity = transform.forward * bulletSpeed;
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
