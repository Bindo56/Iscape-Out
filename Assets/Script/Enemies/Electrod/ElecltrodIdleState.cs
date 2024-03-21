using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecltrodIdleState : ElectrodGroundedState
{
    public ElecltrodIdleState(Enemies _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, ElectrodEnemy _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.idleTimer;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("EnemyIdle");

        if(stateTimer > 0f)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
