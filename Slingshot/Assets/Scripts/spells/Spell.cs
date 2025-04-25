using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Spell : MonoBehaviour
{
    protected GameObject thisSpell;
    protected Vector3 initPosition;
    protected Rigidbody2D rb;
    private int bounds = 3;
    private bool isLaunched = false;
    protected float launchTimer = 0;
    private float totalTime = 3;
    protected LineRenderer lineRenderer;
    protected SpellSelector spellSelector;
    protected bool hasRespawned = false;

    [SerializeField] protected float speed = 550f;
    [SerializeField] private float maxPullDirection = .5f;
    public Vector3 InitPosition => initPosition;
    public bool IsLaunched => isLaunched;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        initPosition = transform.position;
    }

    public void Initialize(SpellSelector selector, GameObject prefab)
    {
        spellSelector = selector;
        thisSpell = prefab;
    }

    protected virtual void Update()
    {
        if (!isLaunched)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, initPosition);
        }

        if (isLaunched && rb.linearVelocity.magnitude <= .3f)
        {
            launchTimer += Time.deltaTime;
        }

        if (transform.position.y < -bounds || launchTimer > totalTime)
        {
            hasRespawned = true;
            rb.gravityScale = 0;
            Destroy(gameObject);
            spellSelector.SpawnSpell(thisSpell);
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goblin"))
        {
            Destroy(collision.gameObject);
        }
    }

    protected virtual void OnMouseDown()
    {
        if (IsLaunched) return;

        lineRenderer.enabled = true;
    }

    protected virtual void OnMouseUp()
    {
        if (IsLaunched) return;

        Vector2 directionToInitPos = (Vector2)initPosition - (Vector2)transform.position;
        rb.AddForce(directionToInitPos * speed);
        rb.gravityScale = 1;
        isLaunched = true;
        LevelController.spellCount++;
        lineRenderer.enabled = false;
    }

    protected virtual void OnMouseDrag()
    {
        if (IsLaunched) return;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = mousePosition - initPosition;
        if (direction.magnitude > maxPullDirection)
        {
            direction = direction.normalized * maxPullDirection;
        }
        transform.position = initPosition + direction;
    }
}
