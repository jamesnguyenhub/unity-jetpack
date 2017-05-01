using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {
	public Sprite laserOnSprite;
	public Sprite laserOffSprite;
	public float interval = 0.5f;
	public float rotationSpeed = 0.0f;
	private bool isLaserOn = true;
	private float timeUntilNextToggle;
	private Collider2D cld2D;
	private SpriteRenderer sr;
	public AudioSource audioSource;

	void Start() {
		timeUntilNextToggle = interval;
		cld2D = GetComponent<Collider2D>();
		sr = GetComponent<SpriteRenderer>();
		audioSource = GetComponent<AudioSource>(); 
	}

	void FixedUpdate() {
		timeUntilNextToggle -= Time.fixedDeltaTime;

		if (timeUntilNextToggle <= 0) {
			isLaserOn = !isLaserOn;
			cld2D.enabled = isLaserOn;
			if (isLaserOn) {
				sr.sprite = laserOnSprite;
			} else {
				sr.sprite = laserOffSprite;
			}

			timeUntilNextToggle = interval;
		}

		transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.fixedDeltaTime);
	}
}
