using UnityEngine;

public class Player : Entity
{
    [Header("MoveInfo")]
    public float moveSpeed = 12f;
    public float wallClimbSpeed = 15f;
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






  
    public PlayerStateMachine stateMachine { get; private set; }

 

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerWallClimbState climbState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAimState aimState { get; private set; }

   // public PlayerShootState shootState { get; private set; }
   

    protected override void Awake()
    {

        base.Awake();

        stateMachine = new PlayerStateMachine();

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

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
        crosshairSprite.enabled = false;
        
    }



    protected override void Update()
    {
        base.Update();

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

   

    





}
