using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{

    protected EnemyStateMachine stateMachine;
    protected Enemies enemyBase;

    protected Rigidbody2D rb;   

    protected float stateTimer;
    protected bool triggerCalled;
    private string animBoolName;

    public EnemyState(Enemies _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, ElectrodEnemy _enemy)
    {
        this.enemyBase = _enemyBase;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Update()
    {


    }

    public virtual void Enter()
    {
        triggerCalled = false;
        rb = enemyBase.rb;
      //  enemyBase.anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
       // enemyBase.anim.SetBool(animBoolName, false);

    }

}
