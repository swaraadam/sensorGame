using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public Text score;
    public float speed = 1;
    private int scorePlayer = 0;
    private Transform player;
	// Use this for initialization
	void Start () {
        player = FindObjectOfType<BulletScript>().transform;
        score = FindObjectOfType<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, player.position, step);

        Vector3 targetDir = player.position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);

        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            Debug.Log("hello");
            scorePlayer += 1;
            score.text = "Score :" + scorePlayer;
            Destroy(collision.gameObject);
            Destroy(transform.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bullet")
        {
            Debug.Log("heo");
            scorePlayer += 1;
            score.text = "Score :" + scorePlayer;
            Destroy(other.gameObject);
            Destroy(transform.gameObject);
        }

        if (other.transform.tag == "Player")
        {
            Debug.Log("GameOver");
            score.text = "Game Over";
            Time.timeScale = 0;
            Destroy(transform.gameObject);
        }
    }
}
