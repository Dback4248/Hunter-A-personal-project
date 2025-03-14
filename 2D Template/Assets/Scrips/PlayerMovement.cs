using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	private new Camera camera;
	private new Rigidbody2D rigidbody;

	private Vector2 velocity;

	public PlayerMovement(float moveSpeed)
	{
		this.moveSpeed = moveSpeed;
	}

	public float moveSpeed = 8f;
	public float maxJumpHeight = 5f;
	public float maxJumpTime = 1f;

	public float JumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
	public float Gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2f);

	public bool Grounded { get; private set; }
	public bool Jumping { get; private set; }
	private float inputAxis;

	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
		camera = Camera.main;
	}


	private void Update()
	{
		HorizontalMovement();
		Grounded = rigidbody.Raycast(direction: Vector2.down);

		if (Grounded)
		{
			GroundedMovement();
		}

		ApplyGravity();

	}

	private void HorizontalMovement()
	{
		inputAxis = Input.GetAxis("Horizontal");
		velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime);

		if (rigidbody.Raycast(Vector2.right * velocity.x)) {
			velocity.x = 0f;
		}
	}

	private void GroundedMovement()
	{
		velocity.y = Mathf.Max(velocity.y, 0f);
		Jumping = velocity.y > 0f;

		if (Input.GetButtonDown("Jump"))
		{
			velocity.y = JumpForce;
			Jumping = true;
		}
	}

	private void ApplyGravity()
	{
		bool falling = velocity.y < 0f || !Input.GetButton("Jump");
		float multiplier = falling ? 2f : 1f;

		velocity.y += Gravity * multiplier * Time.deltaTime;
		velocity.y = Mathf.Max(velocity.y, Gravity / 2f);
	}

	private void FixedUpdate()
	{
		Vector2 position = rigidbody.position;
		position += velocity * Time.fixedDeltaTime;

		Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
		Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);

		rigidbody.MovePosition(position);
	}
	private void OnCollisionEnter2D(Collision2D collision) 
	{
		if (collision.gameObject.layer != LayerMask.NameToLayer("PowerUp"))
		{
			if (transform.DotTest(collision.transform, Vector2.up)) {
				velocity.y = 0f;
			}
		}
	}
}

