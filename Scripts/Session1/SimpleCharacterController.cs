using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimpleCharacterController : MonoBehaviour {

	// Physics parameters
	public float moveSpeed = 5f;
	public float jumpForce = 10f;
	
	// Ground checking
	public float checkRadius = 0.1f;
	public Transform footTransform;
	
	private Vector3 movementInput;
	private bool isGrounded;
	private Rigidbody rb;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
		// Ground checking - Collider checking method
		// Get all the colliders inside a sphere used for ground checking
		Collider[] ground = Physics.OverlapSphere(footTransform.position, checkRadius, LayerMask.GetMask("Ground"));
		// We touch the ground is there is at least one object on the layer "Ground"  
		isGrounded = ground.Length > 0;

		// Input movement gathering, normalize the vector to get the direction as a circle and not a square
		movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
			
		if (Input.GetButtonDown("Jump") && isGrounded) {
			rb.AddForce(new Vector3(0, jumpForce, 0));
		}
			
		// We'll see later better ways to move our character, using physics updates and better collision detection
		transform.Translate(movementInput * Time.deltaTime * moveSpeed);
			
	}
	
	void OnDrawGizmosSelected() {
		// This is used to draw a sphere on the editor that represent the ground checking sphere
		Gizmos.color = Color.blue;
		Gizmos.DrawWireSphere(footTransform.position, checkRadius);
	}
}
