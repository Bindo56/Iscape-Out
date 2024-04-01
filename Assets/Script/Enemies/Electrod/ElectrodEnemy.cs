using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectrodEnemy : Enemies
{
    public ElectrodMoveState moveState {  get;private set; }
    public ElecltrodIdleState idleState {  get; private set; }
    public ElectrodBattleState battleState { get; private set; }

 

    protected override void Awake()
    {
        base.Awake();

        idleState = new ElecltrodIdleState(this,stateMachine,"Idle",this);
        moveState = new ElectrodMoveState(this, stateMachine, "Move",this);
        battleState = new ElectrodBattleState(this, stateMachine, "Move", this);
      

    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }

    public void SetVelocity(float _xvelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xvelocity, _yVelocity);
    }
}
