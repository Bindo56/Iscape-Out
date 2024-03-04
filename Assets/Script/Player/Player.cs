using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("MoveInfo")]
    public float moveSpeed = 12f;
    public float jumpForce = 10f;


    [Header("Aim")]
    public Transform crosshair;
    public SpriteRenderer crosshairSprite;

    [Header("ShootJelly")]
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public Transform aim;
    public float shootForce;


    [Header("Grapling")]
    public GameObject RopeHinge;
    public DistanceJoint2D DistanceJoint;
  
    public bool ropeAttached;
    public bool distanceSet;
    public Vector2 playerPosition;
    public Rigidbody2D ropeHingeRB;
    public SpriteRenderer ropeHingeSR;
    public LineRenderer RopeRnder;
    public LayerMask ropeLayer;
    [SerializeField] public float ropeDistance = 20f;

    [Header("Swing")]
    public bool isSwinging;
    public SpriteRenderer playerSprite;

    [Header("RopeClimb")]
    public float climbSpeed;
    public bool isColliding;




    [Header("CollisionInfo")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckDistances;
    [SerializeField] Transform wallCheck;
    [SerializeField] float wallCheckDistances;
    [SerializeField] LayerMask whatIsGround;

    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }

    public PlayerStateMachine stateMachine { get; private set; }

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerWallClimbState climbState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAimState aimState { get; private set; }

   // public PlayerShootState shootState { get; private set; }
   

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        // anim =  GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        crosshairSprite.enabled = false;
        DistanceJoint.enabled = false;

        idleState = new PlayerIdleState(stateMachine, this, "Idle");
        moveState = new PlayerMoveState(stateMachine, this, "Move");
        climbState = new PlayerWallClimbState(stateMachine, this, "Climb");
        airState = new PlayerAirState(stateMachine, this, "Air");
        jumpState = new PlayerJumpState(stateMachine, this, "Jump");
        aimState = new PlayerAimState(stateMachine, this, "aim");
      //  shootState = new PlayerShootState(stateMachine, this, "shoot");
       

    }

    private void Start()
    {
        stateMachine.Initialize(idleState);
        crosshairSprite.enabled = false;

    }



    private void Update()
    {
        stateMachine.currentState.Update();

        if(Input.GetKeyDown(KeyCode.F))
        {
            FireJelly();
        }

    }

    

    public void SetVelocity(float _xvelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xvelocity, _yVelocity);
    }

    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistances, whatIsGround);
    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistances, whatIsGround);

    public virtual void FireJelly()
    {
        if (IsGroundDetected())
        {

            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb = projectile.GetComponentInChildren<Rigidbody2D>();

            Vector2 shootDir = (aim.position - shootPoint.position).normalized;
            if (rb != null)
            {
                //  rb.AddForce(shootPoint.right * shootForce, ForceMode2D.Impulse);
                rb.velocity = shootDir * shootForce;
            }
            else
            {
                Debug.LogError("prefabnothere");
            }
        }
    }


    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistances));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistances, wallCheck.position.y));
    }





}
