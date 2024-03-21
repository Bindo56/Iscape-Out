using UnityEngine;

public class PlayerResizeState : PlayerGroundedState
{
    public PlayerResizeState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
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
        if (player.IsGroundDetected())
        {
            player.SetVelocity(xInput * 10, rb.velocity.y);


        }

      /*  for (int i = 0; i < player.CrouchPlayerPoints.Length; i++)
        {
            player.CrouchPlayerPoints[i].gameObject.transform.localPosition = player.PointsPositions[i];//settting points positions
            Debug.Log("resetShape");
        }*/

       /* if (Input.GetKey(KeyCode.LeftShift))
        {


            player.transform.localScale -= new Vector3(player.resizePlayer, player.resizePlayer, 0f) * Time.deltaTime;
            player.transform.localScale = Vector3.Min(player.transform.localScale, new Vector3(player.crouchSize, player.crouchSize, 0f));
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            player.transform.localScale += new Vector3(player.resizePlayer, player.resizePlayer, 0f) * Time.deltaTime;
            player.transform.localScale = Vector3.Max(player.transform.localScale, new Vector3(0.5f, 0.5f, 0f));
            stateMachine.ChangeState(player.idleState);
        }*/
    }


}
