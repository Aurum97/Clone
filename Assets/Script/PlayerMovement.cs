using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    public bool CanMove(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(transform.position.x, transform.position.y) + direction);
        if (hit.collider.tag != "Untagged" || hit.collider.tag != "Player") return true;
        Debug.Log("we can't move!");
        return false;
    }

    public void GetInput()
    {
        if (Input.GetKeyUp(KeyCode.W) && CanMove(Vector2.up))
        {
            rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + Vector2.up);
        }

        if (Input.GetKeyUp(KeyCode.A) && CanMove(Vector2.left))
        {
            rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + Vector2.left);
        }

        if (Input.GetKeyUp(KeyCode.S) && CanMove(Vector2.down))
        {
            rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + Vector2.down);
        }

        if (Input.GetKeyUp(KeyCode.D) && CanMove(Vector2.right))
        {
            rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + Vector2.right);
        }
    }
}
