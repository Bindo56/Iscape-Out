using UnityEngine;

public class ElectrodMoveState : ElectrodGroundedState

{
    public ElectrodMoveState(Enemies _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, ElectrodEnemy _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
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
        Debug.Log("EnemyMove");

        enemy.SetVelocity(-enemy.moveSpeed * enemy.facingDir, enemy.rb.velocity.y);

        if (enemy.EnemyisWallDetected())
        {
            // enemy.transform.Rotate(0, 180, 0);
            enemy.flip();
            stateMachine.ChangeState(enemy.idleState);

        }

        if (enemy.IsGroundDetected())
        {
            enemy.flip();
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
