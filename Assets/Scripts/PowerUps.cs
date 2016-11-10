﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUps : MonoBehaviour {

    public static PowerUps instance;
    public bool gotPowerUp = false;
    public string powerUpText;
    private string _whichPowerUp = "";
    private IEnumerator coroutine;

    void Awake()
    {
        instance = this;
    }
	// Update is called once per frame    
	void Update () {
        GetComponent<Rigidbody2D>().velocity = Vector2.down * 10f;
    }

    void OnTriggerEnter2D(Collider2D paddle)
    {
        if(paddle.tag == "Paddle")
        {
			AudioSource powerup = GetComponent<AudioSource> ();
			powerup.Play ();

            int rnd = Random.Range(0, 0);
			if (rnd == 0) {
				BiggerBall();
			}
            powerUpText = ("Power Up: " + _whichPowerUp);
            gotPowerUp = true;

            //Disables the sprite, object is destroyed in KillTrigger.cs
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    public void BiggerBall()
    {
        _whichPowerUp = "Bigger Ball!";
        Ball.Instance.transform.localScale = new Vector3(30f, 30f, 1f);
        Ball.Instance.ResetBall();
    }

    public void TimeSaver()
    {
        _whichPowerUp = "Time Saver!";
        GameManager.Instance.timer -= 10;
    }
}
