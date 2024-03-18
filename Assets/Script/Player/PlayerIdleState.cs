using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.crosshairSprite.enabled = false;
        if (player.IsGroundDetected())
        {

            for (int i = 0; i < player.PlayerPoints.Length; i++)
            {
                player.PlayerPoints[i].gameObject.transform.localPosition = player.PointsPositions[i];//settting points positions
                Debug.Log("resetShape");
            }
            //false
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        Debug.Log("idle");

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            stateMachine.ChangeState(player.aimState);
        }

        /* if(yInput != 0)
         {
             stateMachine.ChangeState(player.climbState);
         }*/

        if (xInput != 0)
        {
            stateMachine.ChangeState(player.moveState);
        }
    }

}
