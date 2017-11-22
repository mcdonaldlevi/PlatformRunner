using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Controller2D1))]
public class Player1 : MonoBehaviour {

	bool isCarried = false;
	float moveSpeed = 6;
	float gravity = -20;
	Controller2D1 controller;
	public Player2 player2;
	public float jumpHeight = 4;
	public float timeToJumpToApex = .4f;
	float accelerationTimeAirborne =.2f;
	float accelerationTimeGrounded = .1f;
	Controller2D2 otherController;
	float throwRange = 1f;

	float targetVelocity = 0;

	public bool isThrown = false;
	float velocityXSmoothing;
	float jumpVelocity = 8;
	Vector3 velocity;
	void Start () {
		controller = GetComponent<Controller2D1> ();
		otherController = player2.GetComponentInParent<Controller2D2> ();
		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpToApex, 2);
		jumpVelocity = Mathf.Abs (gravity) * timeToJumpToApex;
	}

	// Update is called once per frame
	void Update () {

		if(controller.collisions.above || controller.collisions.below){
			velocity.y = 0;
		}
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (Input.GetButtonDown ("Jump1") && controller.collisions.below)
			velocity.y = jumpVelocity;
		if (isThrown) {
			velocity.y = jumpVelocity / 2;
			velocity.x = jumpVelocity;
		}
		targetVelocity = input.x * moveSpeed;
		if (isThrown) {
			targetVelocity += 100;
			isThrown = false;
		}
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocity, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);

		if (Input.GetButton ("Fire1") && Mathf.Abs(this.transform.position.magnitude - player2.transform.position.magnitude) < throwRange) {
			Vector3 holdRange = new Vector3 (0, 1.5f, 0);
			player2.transform.position = Vector3.Lerp(player2.transform.position, this.transform.position + holdRange, 1f );
			isCarried = true;
		}
		if (Input.GetButtonUp ("Fire1") && isCarried) {
			player2.isThrown = true;
			isCarried = false;
		}
	}
}
