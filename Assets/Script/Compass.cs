using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Compass : MonoBehaviour {

    public RawImage rawImage;
    public Transform player;
	// Update is called once per frame
	void Update () {
        rawImage.uvRect = new Rect(player.localEulerAngles.y / 360, 0, 1, 1);
	}
}
