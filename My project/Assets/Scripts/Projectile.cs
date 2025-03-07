using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 3f;
    private Vector2 direction;
    private Vector2 targetPosition;

    void Start()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (targetPosition - (Vector2)transform.position).normalized;
    }

    void Update()
    {
        // Shoots at mouse point, gets destroyed once it reaches said point
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
        if (HasPassedTarget())
        {
            Destroy(gameObject);
        }
    }

    bool HasPassedTarget()
    {
        return Vector2.Dot((Vector2)transform.position - targetPosition, direction) > 0;
    }
}
