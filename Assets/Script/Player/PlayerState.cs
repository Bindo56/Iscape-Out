using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{

    protected PlayerStateMachine stateMachine;
    protected Player player;
    protected Vector2 ropeHook;
    // protected Vector2 aimDir;
    protected Rigidbody2D rb;
    public float swingForce = 20f;

   

    public PlayerAimState aimState;



    public List<Vector2> ropePosVector = new List<Vector2>();

    public Dictionary<Vector2, int> wrapPoints = new Dictionary<Vector2, int>();


    protected float xInput;
    protected float yInput;

    //  private string animBoolName;



    public PlayerState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName)
    {
        this.stateMachine = _stateMachine;
        this.player = _player;
        //this.animBoolName = _animBoolName;
    }


    public virtual void Enter()
    {
        //  player.anim.SetBool(animBoolName, true);
        rb = player.rb;
        // Debug.Log("I Enter " + animBoolName);

    }


    public virtual void Update()
    {
        //  Debug.Log("I'm in " + animBoolName);
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

    }
    public virtual void Exit()
    {
        //  player.anim.SetBool(animBoolName, false);
        // Debug.Log("I exit " + animBoolName);

    }



}
