using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemies : MonoBehaviour
{
   [SerializeField] protected LayerMask whatIsPlayer;

    [Header("MoveInfo")]
    public float moveSpeed;
    public float idleTimer;

    [Header("AttackInfo")]
    public float attackDistance;

    [Header("CollisionInfo")]
    [SerializeField] protected Transform groundCheck;
    [SerializeField] protected float groundCheckDistances;
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] protected float enemywallCheckDist;
    [SerializeField] protected Transform EnemywallCheck;
    [SerializeField] protected float playerDetectRange;
    [SerializeField] protected Transform enemyEyes;
   
    [SerializeField] protected LayerMask EnemywhatIsGround;

    public int facingDir { get; private set; } = 1;
    public bool facingRight = true;

  

    public EnemyStateMachine stateMachine {  get; private set; }

    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }


    protected virtual void Awake()
    {
        
        stateMachine = new EnemyStateMachine();
    }

    protected virtual void Start()
    {
      //  anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
      

      

        stateMachine.currentState.Update();
    }

    public virtual bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistances, whatIsGround);
    
    public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(enemyEyes.position, Vector2.right * -facingDir, attackDistance, whatIsPlayer);
    public virtual bool EnemyisWallDetected() => Physics2D.Raycast(EnemywallCheck.position, Vector2.right * facingDir, enemywallCheckDist, EnemywhatIsGround);

    public virtual void flip()
    {
        Debug.Log("flip");
        facingDir = facingDir * -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);

        /* if (OnFlipped != null)
             OnFlipped();*/
    }

    public virtual void flipController(float _x)
    {
        if (_x > 0 && !facingRight)
            flip();

        else if (_x < 0 && facingRight)
            flip();

    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistances));
      
        Gizmos.DrawLine(EnemywallCheck.position, new Vector3(EnemywallCheck.position.x + enemywallCheckDist, EnemywallCheck.position.y));
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(enemyEyes.position, new Vector3(enemyEyes.position.x * attackDistance * facingDir, enemyEyes.position.y));
    }

}
