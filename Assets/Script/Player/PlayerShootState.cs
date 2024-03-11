public class PlayerShootState : PlayerGroundedState
{
    public PlayerShootState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
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
        if (yInput != 0)
        {
            stateMachine.ChangeState(player.climbState);
        }

        if (xInput != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }




}
