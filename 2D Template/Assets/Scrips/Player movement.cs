using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]// This script can only be added to a Gameobject with a Rigidbody2D
public class Playermovement : MonoBehaviour
{

	public float movementSpeed;
    
    private Rigidbody2D _rb;
	private object _moveAmount;

	void Awake()
    {
        // Set the _rb variable equal to this GameObject's rigidbody.
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
		_rb.linearVelocityX = _moveAmount.x * movementSpeed;
	}
}
