using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("CollisionInfo")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistances;
    [SerializeField] protected Transform wallCheck;
    [SerializeField]  protected float wallCheckDistances;
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] protected Vector2 groundchecksize;

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
 
    public virtual bool IsWallDetected() => Physics2D.Raycast(wallCheck.position , Vector2.right, wallCheckDistances, whatIsGround);
    public virtual bool IsGroundDetected() => Physics2D.BoxCast(groundCheck.position, groundchecksize, 0, Vector2.down, whatIsGround);



    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundCheck.position, groundchecksize);
       
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistances, wallCheck.position.y));
    }

    
}
