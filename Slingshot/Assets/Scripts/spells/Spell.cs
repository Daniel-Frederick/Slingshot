using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Spell : MonoBehaviour
{
    protected Vector3 initPosition;
    protected Rigidbody2D rb;
    private int bounds = 3;
    protected bool isLaunched = false;
    protected float launchTimer = 0;
    private float totalTime = 3;
    protected LineRenderer lineRenderer;
    private int spellCounter;

    [SerializeField] protected float speed = 550f;
    [SerializeField] private float maxPullDirection = .5f;

    public abstract void OnCollisionEnter2D(Collision2D collision);

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        initPosition = transform.position;
    }

    protected virtual void Update()
    {
        if (!isLaunched)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, initPosition);
        }

        if (isLaunched && rb.linearVelocity.magnitude <= .3)
        {
            launchTimer += Time.deltaTime;
        }

        if (transform.position.y < -bounds || launchTimer > totalTime)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    protected virtual void OnMouseDown()
    {
        lineRenderer.enabled = true;
    }

    protected virtual void OnMouseUp()
    {
        Vector2 directionToInitPos = (Vector2)initPosition - (Vector2)transform.position;
        rb.AddForce(directionToInitPos * speed);
        rb.gravityScale = 1;
        isLaunched = true;
        lineRenderer.enabled = false;
    }

    protected virtual void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = mousePosition - initPosition;
        if (direction.magnitude > maxPullDirection) {
            direction = direction.normalized * maxPullDirection;
        } 
        transform.position = initPosition + direction;
    }

}
