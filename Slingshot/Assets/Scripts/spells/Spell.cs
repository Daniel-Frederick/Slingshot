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
    [SerializeField] protected float speed = 550f;

    //public Spell(/* Could do a Enum */) { }

    protected virtual void SpellAwake()
    {
        rb = GetComponent<Rigidbody2D>();
        initPosition = transform.position;
    }

    protected virtual void SpellUpdate()
    {
        if (isLaunched && rb.linearVelocity.magnitude <= .3)
        {
            launchTimer += Time.deltaTime;
        }

        if (transform.position.y < -bounds || launchTimer > totalTime)
        {
            //transform.position = initPosition;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }

    protected virtual void OnMouseUp()
    {
        Vector2 directionToInitPos = (Vector2)initPosition - (Vector2)transform.position;
        rb.AddForce(directionToInitPos * speed);
        rb.gravityScale = 1;
        isLaunched = true;
    }

    protected virtual void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x, newPosition.y, 0);
    }
}
