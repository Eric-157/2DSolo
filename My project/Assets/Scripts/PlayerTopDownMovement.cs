using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerTopDownMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public GameObject projectilePrefab;
    private InteriorManager interiorManager;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        GameObject[] system = GameObject.FindGameObjectsWithTag("System");
        interiorManager = system[0].GetComponent<InteriorManager>();
        if(interiorManager.saveData.playerData.interior){
            interiorManager.saveData.playerData.interior = false;
        }
        interiorManager.saveData.SaveToJson();
 
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(!interiorManager.interior){
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // Normalize to prevent diagonal speed boost
            movement = movement.normalized;
            if (Input.GetMouseButtonDown(0))
            {
                ShootProjectile();
            }
            if(!spriteRenderer.enabled){
                spriteRenderer.enabled = true;
            }
        }
        else{
            spriteRenderer.enabled = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = movement * moveSpeed;
    }

    void ShootProjectile()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
}
