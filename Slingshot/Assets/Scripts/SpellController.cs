using UnityEngine;
using UnityEngine.SceneManagement;

public class SpellController : MonoBehaviour
{
    private Vector3 initPosition;
    private Rigidbody2D rb;
    private int bounds = 3;
    private bool isLaunched = false;
    private float lauchTimer = 0;
    private float totalTime = 3;
    [SerializeField] private float speed = 550f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        initPosition = transform.position;
    }

    private void Update()
    {
        if (isLaunched && rb.linearVelocity.magnitude <= .3)
        {
            lauchTimer += Time.deltaTime;
        }

        if (transform.position.y > bounds || transform.position.y < -bounds ||
            transform.position.x > bounds || transform.position.x < -bounds ||
            lauchTimer > totalTime)
        {
            //transform.position = initPosition;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }

    private void OnMouseUp()
    {
        Vector2 directionToInitPos = (Vector2)initPosition - (Vector2)transform.position;
        rb.AddForce(directionToInitPos * speed);
        rb.gravityScale = 1;
        isLaunched = true;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }
}
