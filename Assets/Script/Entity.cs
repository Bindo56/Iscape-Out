using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("CollisionInfo")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistances;
    [SerializeField] protected Transform wallCheck;
    [SerializeField]  protected float wallCheckDistances;
    [SerializeField] protected LayerMask whatIsGround;


    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    protected virtual void Awake()
    {

    }


    protected virtual void Start()
    {
         anim =  GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {

    }
    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistances, whatIsGround);
    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistances, whatIsGround);



    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistances));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistances, wallCheck.position.y));
    }
}
