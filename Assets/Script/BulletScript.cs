using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float bulletSpeed = 9f;
    public Rigidbody bullet;
    private Gyroscope gyroscope;
    private bool isGyro = false;

    private void Start()
    {
        isGyro = gyroTest();
    }

    // Update is called once per frame
    void LateUpdate () {

        if (PAProximity.proximity == PAProximity.Proximity.NEAR||Input.GetKeyDown(KeyCode.Space))
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
        Destroy(bulletCreate.gameObject, 2f);
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
