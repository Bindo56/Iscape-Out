using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.crosshairSprite.enabled = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            stateMachine.ChangeState(player.aimState);
        }
     

        if(player.grapplingRope.isGrappling)
        {
          player.SetVelocity(xInput * 8, yInput * 8);

        }
       /* else
        {
          player.SetVelocity(xInput * 8, rb.velocity.y);

        }*/
            Debug.Log("move");

        if(!player.IsGroundDetected() && !player.IsWallDetected())
        {
            rb.gravityScale = 15;
        }

        if (player.IsGroundDetected())
        {
            Debug.Log("move1");
          //  player.SetVelocity(xInput * player.moveSpeed, yInput * player.wallClimbSpeed);

          player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);
        }

         if (player.IsWallDetected() && player.IsGroundDetected())
        {
            Debug.Log("wallmove1");

            player.SetVelocity(xInput * player.moveSpeed, yInput * player.wallClimbSpeed);

        }

        if (player.IsWallDetected())
        {
            player.SetVelocity(xInput * player.moveSpeed, yInput * player.wallClimbSpeed);

        }

        if (xInput == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }

    }


}
