using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrodBattleState : EnemyState
{
    ElectrodEnemy enemy;
    Transform player;
    int moveDir;

    public ElectrodBattleState(Enemies _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, ElectrodEnemy _enemy) : base(_enemyBase, _stateMachine, _animBoolName, _enemy)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("BattleMode");


        if(enemy.IsPlayerDetected())
        {
            if(enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                enemy.rb.velocity = Vector3.zero;
                Debug.Log("AttackUGreenSperm");
                return;
            }


        }

        if(player.position.x > enemy.transform.position.x)
        {
            moveDir = 1;
        }
        else if(player.position.x < enemy.transform.position.x)
        {
            moveDir = -1;
        }

        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.velocity.y);

    }

    
}
