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
     
            Debug.Log("move");
        
        player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);

        if (player.IsWallDetected())
        {
            player.SetVelocity(rb.velocity.x, yInput * player.wallClimbSpeed);

        }

        if (xInput == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }

    }


}
