using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]// This script can only be added to a Gameobject with a Rigidbody2D
public class Playermovement : MonoBehaviour
{

	public float movementSpeed;

	private Rigidbody2D rb;
	public float moveSpeed = 5f;
	private float horizontalMovement;

	void Awake()
	{
		// Set the _rb variable equal to this GameObject's rigidbody.
		rb = GetComponent<Rigidbody2D>();
	}

	[System.Obsolete]
	void Update()
	{
		rb.velocity = new Vector2(horizontalMovement * moveSpeed, rb.velocity.y);
	}


	public void Move(InputAction.CallbackContext context) 
	{
		horizontalMovement = context.ReadValue<Vector2>().x;
	}

}
