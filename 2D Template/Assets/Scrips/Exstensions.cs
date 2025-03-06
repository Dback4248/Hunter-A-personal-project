using UnityEngine;

public static class Exstensions
{
	private static LayerMask layerMask = LayerMask.GetMask("Default");

	[System.Obsolete]
	public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction)
	{

		if (GetIsKinematic(rigidbody))
		{
		
			return false;
		}

		float radius = 0.25f;
		float distance = 0.375f;

		RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radius, direction, distance, layerMask);
		return hit.collider != null && hit.rigidbody != rigidbody;

		static bool GetIsKinematic(Rigidbody2D rigidbody)
		{
			return rigidbody.isKinematic;
		}
	}
	public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection) 
	{
		Vector2 direction = other.position - transform.position;
		return Vector2.Dot(direction.normalized, testDirection) > 0.25f;
	}

}