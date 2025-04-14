using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Spell : MonoBehaviour
{
    protected Vector3 initPosition;
    protected Rigidbody2D rb;
    protected int bounds = 3;
    protected bool isLaunched = false;
    protected float launchTimer = 0;
    protected float totalTime = 3;
    protected LineRenderer lineRenderer;
    private int spellCounter;

    [SerializeField] protected float speed = 550f;

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
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }
}
