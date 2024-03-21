public class ElectrodGroundedState : EnemyState
{
    protected ElectrodEnemy enemy;

    public ElectrodGroundedState(Enemies _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, ElectrodEnemy _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {
        this.enemy = _enemy;
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

        if (enemy.IsPlayerDetected())
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
