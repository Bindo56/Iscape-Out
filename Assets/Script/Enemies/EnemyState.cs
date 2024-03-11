using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{

    protected EnemyStateMachine stateMachine;
    protected Enemies enemy;

    protected float stateTimer;
    protected bool triggerCalled;
    private string animBoolName;

    public EnemyState(Enemies _enemy, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemy = _enemy;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public void Update()
    {


    }

    public void Enter()
    {
        triggerCalled = false;
        enemy.anim.SetBool(animBoolName, true);
    }

    public void Exit()
    {
        enemy.anim.SetBool(animBoolName, false);

    }

}
