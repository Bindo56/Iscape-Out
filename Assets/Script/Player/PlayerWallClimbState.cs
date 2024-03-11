public class PlayerWallClimbState : PlayerGroundedState
{
    public PlayerWallClimbState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

/*        if (player.IsWallDetected())
        {
            player.SetVelocity(rb.velocity.x, yInput * player.moveSpeed);

        }*/

        if (yInput == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
