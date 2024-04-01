using UnityEngine;

public class Player : Entity
{
    [Header("MoveInfo")]
    public float moveSpeed = 12f;
    public float wallClimbSpeed = 15f;
    public float jumpForce = 10f;


   

    [Header("ShootJelly")]
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public Transform aim;
    public float shootForce;
   


   [HideInInspector] public float resizePlayer;
    [Header("Resize")]
    public float crouchSize = 0.2f;

    [Header("RopeClimb")]
    public float climbSpeed;
    public bool isColliding;

    [Header("Points")]
    public GameObject[] PlayerPoints;
    public Vector2[] PointsPositions;


    [Header("Crouch")]
    public GameObject[] CrouchPlayerPoints;
    public Vector2[] CrouchPointsPositions;

    public GrapplingRope grapplingRope;


    public PlayerStateMachine stateMachine { get; private set; }

 

    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerWallClimbState climbState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAimState aimState { get; private set; }
    public PlayerResizeState resizeState { get; private set; }

   // public PlayerShootState shootState { get; private set; }
   


    protected override void Awake()
    {

        base.Awake();

        stateMachine = new PlayerStateMachine();

       // crosshairSprite.enabled = false;
       // DistanceJoint.enabled = false;

        idleState = new PlayerIdleState(stateMachine, this, "Idle");
        moveState = new PlayerMoveState(stateMachine, this, "Move");
        climbState = new PlayerWallClimbState(stateMachine, this, "Climb");
        airState = new PlayerAirState(stateMachine, this, "Air");
        jumpState = new PlayerJumpState(stateMachine, this, "Jump");
        aimState = new PlayerAimState(stateMachine, this, "aim");
        resizeState = new PlayerResizeState(stateMachine, this, "Idle");

        //  shootState = new PlayerShootState(stateMachine, this, "shoot");

        for (int i = 0; i < PlayerPoints.Length; i++)
        {
            PointsPositions[i] = PlayerPoints[i].gameObject.transform.localPosition;
        }


    }


    

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
        //crosshairSprite.enabled = false;


       

    }



    protected override void Update()
    {
        base.Update();


        if (Input.GetKey(KeyCode.LeftShift))
        {


            transform.localScale -= new Vector3(resizePlayer, resizePlayer, 0f) * Time.deltaTime;
            transform.localScale = Vector3.Min(transform.localScale, new Vector3(crouchSize, crouchSize, 0f));
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            transform.localScale += new Vector3(resizePlayer, resizePlayer, 0f) * Time.deltaTime;
            transform.localScale = Vector3.Max(transform.localScale, new Vector3(0.5f, 0.5f, 0f));
            stateMachine.ChangeState(idleState);
        }

        stateMachine.currentState.Update();

       

      


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
