using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
	public float jetpackForce = 75.0f;
	public float forwardMovementSpeed = 3.0f;
	public Transform groundCheckTransform;
	private bool grounded;
	public LayerMask groundCheckLayerMask;
	Animator animator;
	public ParticleSystem jetpack;

	private Rigidbody2D rb;
	private bool dead = false;
	private uint coins = 0;
	public ParallaxScroll parallaxScroll;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}

	void FixedUpdate() {
		bool jetpackActive = Input.GetButton("Fire1");

		if (jetpackActive && !dead) {
			rb.AddForce(new Vector2(0, jetpackForce));
		}

		if (!dead) {
			rb.velocity = new Vector2(forwardMovementSpeed, rb.velocity.y);
		}

		UpdateGroundedStatus();
		AdjustJetpack(jetpackActive);
		parallaxScroll.offset = transform.position.x;
	}

	void UpdateGroundedStatus() {
		grounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);
		animator.SetBool("grounded", grounded);
	}

	void AdjustJetpack(bool jetpackActive) {
		ParticleSystem.EmissionModule em = jetpack.emission;
		em.enabled = !grounded;
		em.rateOverTime = jetpackActive ? 300.0f : 75.0f;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Coins")) {
			coins++;
			Destroy(other.gameObject);
		} else {
			HitByLaser(other);
		}
	}

	void HitByLaser(Collider2D other) {
		dead = true;
		animator.SetBool("dead", dead);
		LaserScript ls = other.gameObject.GetComponent<LaserScript>();
		ls.audioSource.Play();
	}
}
