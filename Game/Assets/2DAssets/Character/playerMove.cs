using UnityEngine;

public class playerMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private Vector2 lastMoveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        movement.x = Input.GetAxisRaw("Horizontal"); // A/D
        movement.y = Input.GetAxisRaw("Vertical");   // W/S

        movement = movement.normalized;

        if (movement != Vector2.zero)
        {
            lastMoveDir = movement;
        }

        animator.SetFloat("moveX", lastMoveDir.x);
        animator.SetFloat("moveY", lastMoveDir.y);
        animator.SetBool("isMoving", movement.magnitude > 0);
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        Debug.Log($"Input: {input}, moveX: {animator.GetFloat("moveX")}, moveY: {animator.GetFloat("moveY")}");

        if (input != Vector2.zero)
        {
            animator.SetBool("isMoving", true);

            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                animator.SetFloat("moveX", input.x > 0 ? 1 : -1);
                animator.SetFloat("moveY", 0);
            }
            else
            {
                animator.SetFloat("moveX", 0);
                animator.SetFloat("moveY", input.y > 0 ? 1 : -1);
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void FixedUpdate()
    {
        // ÒÆ¶¯½ÇÉ«
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
