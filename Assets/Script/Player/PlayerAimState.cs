using System.Linq;
using UnityEngine;


public class PlayerAimState : PlayerGroundedState
{
    public PlayerAimState(PlayerStateMachine _stateMachine, Player _player, string _animBoolName) : base(_stateMachine, _player, _animBoolName)
    {
    }

    // static public float aimAngle { get; private set; }
    public float aimAngle;
    public Vector2 aimDir;
    public override void Enter()
    {
        base.Enter();
       // ResetRope();

    }

    public override void Exit()
    {
        base.Exit();
        player.crosshairSprite.enabled = false;
    }

    public override void Update()
    {
        player.crosshairSprite.enabled = true;
        /* Debug.Log("aim");
          player.SetVelocity(xInput * player.moveSpeed, rb.velocity.y);
         Swinging();

         if (Input.GetKeyDown(KeyCode.Alpha1))
         {
             stateMachine.ChangeState(player.idleState);
         }

         base.Update();

         AimDir();


         if (!player.ropeAttached)
         {
             SetAimPos(aimAngle);
             player.isSwinging = false;

         }
         else
         {
             player.crosshairSprite.enabled = false;

             player.isSwinging = true;
             // ropeHook = ropePosVector.Last(); //update


             if (ropePosVector.Count > 0)
             {
                 var lastRopePoint = ropePosVector.Last();
                 var PlayerToNxtHit = Physics2D.Raycast(player.transform.position, (lastRopePoint - player.playerPosition).normalized, Vector2.Distance(player.transform.position, lastRopePoint) - 0.1f, player.ropeLayer);

                 if (PlayerToNxtHit)
                 {
                     var colliderwithVertices = PlayerToNxtHit.collider as PolygonCollider2D;

                     if (colliderwithVertices != null)
                     {
                         var closestPointToHit = RopeWarpToCollider(PlayerToNxtHit, colliderwithVertices);

                         if (wrapPoints.ContainsKey(closestPointToHit))
                         {
                             ResetRope();
                             return;
                         }

                         ropePosVector.Add(closestPointToHit);
                         wrapPoints.Add(closestPointToHit, 0);
                         player.distanceSet = false;
                     }

                 }
             }

         }

         HandleInput(aimDir);
         UpdateRopePos();
         HandleRopeLenght();


     }

     public virtual float AimDir()
     {
         var worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

         var facingDir = worldMousePos - player.transform.position;
         aimAngle = Mathf.Atan2(facingDir.y, facingDir.x);

         if (aimAngle < 0f)
         {
             aimAngle = Mathf.PI * 2 + aimAngle;

         }

         aimDir = Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg) * Vector2.right;
         return aimAngle;
     }

     public virtual void SetAimPos(float _aimAngle)
     {
         if (!player.crosshairSprite.enabled)
         {
             player.crosshairSprite.enabled = true;
             // return;
         }

         var x = player.transform.position.x + 2f * Mathf.Cos(aimAngle);
         var y = player.transform.position.y + 2f * Mathf.Sin(aimAngle);


         var CrossHairPos = new Vector3(x, y, 0);

         player.crosshair.transform.position = CrossHairPos;

     }

     public void Swinging()
     {
         if (yInput < 0f || yInput > 0f) //for climbling teticles
         {


             if (player.isSwinging)
             {
                 player.DistanceJoint.distance -= yInput * player.climbSpeed * Time.deltaTime;


                 var playerToHookDir = (ropeHook - (Vector2)player.transform.position).normalized;

                 Vector2 ppdDir; //perpendicular direction
                 if (xInput < 0)
                 {
                     ppdDir = new Vector2(playerToHookDir.y, playerToHookDir.x);
                     var leftperppos = (Vector2)player.transform.position - ppdDir * -2f;
                     Debug.DrawLine(player.transform.position, leftperppos, Color.green, 0f);

                 }
                 else
                 {
                     ppdDir = new Vector2(playerToHookDir.y, -playerToHookDir.x);
                     var rightperpPos = (Vector2)player.transform.position + ppdDir * 2f;
                     Debug.DrawLine(player.transform.position, rightperpPos, Color.green, 0f);
                 }


                 var force = ppdDir * swingForce;
                 player.rb.AddForce(force, ForceMode2D.Force);

             }
         }
     }

     private void HandleInput(Vector2 aimDir) //detecting the aim and lunching at selected layer where to aatach
     {

         {
             if (Input.GetKeyDown(KeyCode.F))
             {
                 if (player.ropeAttached) //remove crossaim
                     return;

                 Debug.Log("rope");
                 player.RopeRnder.enabled = true;

                 var hit = Physics2D.Raycast(player.transform.position, aimDir, player.ropeDistance, player.ropeLayer);

                 if (hit.collider != null)
                 {
                     player.ropeAttached = true;

                     if (!ropePosVector.Contains(hit.point)) //custom hit target
                     {
                         player.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 0), ForceMode2D.Impulse);

                         ropePosVector.Add(hit.point);
                         player.DistanceJoint.distance = Vector2.Distance(player.transform.position, hit.point);

                         player.DistanceJoint.enabled = true;
                         player.ropeHingeSR.enabled = true;

                     }
                 }
                 else
                 {
                     player.RopeRnder.enabled = false;
                     player.ropeAttached = false;
                     player.DistanceJoint.enabled = false;
                 }

             }
             if (Input.GetMouseButtonDown(1))
             {
                 ResetRope();
             }

         }




     }

     private void ResetRope() //reset tenticles
     {

         player.DistanceJoint.enabled = false;
         player.ropeAttached = false;
         player.isSwinging = false;
         player.RopeRnder.positionCount = 2;
         player.RopeRnder.SetPosition(0, player.transform.position);
         player.RopeRnder.SetPosition(1, player.transform.position);
         ropePosVector.Clear();
         player.ropeHingeSR.enabled = false;
         wrapPoints.Clear();

     }

     private void UpdateRopePos() //if tenticles collide 
     {
         if (!player.ropeAttached) { return; }

         player.RopeRnder.positionCount = ropePosVector.Count + 1;

         for (var i = player.RopeRnder.positionCount - 1; i >= 0; i--)
         {
             if (i != player.RopeRnder.positionCount - 1)
             {
                 player.RopeRnder.SetPosition(i, ropePosVector[i]);

                 if (i == ropePosVector.Count - 1 || ropePosVector.Count == 1)
                 {
                     var ropepos = ropePosVector[ropePosVector.Count - 1];

                     if (ropePosVector.Count == 1)
                     {
                         player.ropeHingeRB.transform.position = ropepos;

                         if (!player.distanceSet)
                         {
                             player.DistanceJoint.distance = Vector2.Distance(player.transform.position, ropepos); //chick ropepos for error
                             player.distanceSet = true;
                         }
                     }
                     else
                     {
                         player.ropeHingeRB.transform.position = ropepos;

                         if (!player.distanceSet)
                         {
                             player.DistanceJoint.distance = Vector2.Distance(player.transform.position, ropepos);
                             player.distanceSet = true;
                         }
                     }
                 }
                 else if (i - 1 == ropePosVector.IndexOf(ropePosVector.Last()))
                 {
                     var ropePos = ropePosVector.Last();
                     player.ropeHingeRB.transform.position = ropePos;

                     if (!player.distanceSet)
                     {
                         player.DistanceJoint.distance = Vector2.Distance(player.transform.position, ropePos); player.distanceSet = true;
                     }

                 }
             }
             else
             {
                 player.RopeRnder.SetPosition(i, player.transform.position);
             }



         }

     }

     private Vector2 RopeWarpToCollider(RaycastHit2D hit, PolygonCollider2D polygonCollider)
     {

         var distanceDictionary = polygonCollider.points.ToDictionary<Vector2, float, Vector2>(Position => Vector2.Distance(hit.point, polygonCollider.transform.TransformPoint(Position)), Position => polygonCollider.transform.TransformPoint(Position));


         var orderedDictionary = distanceDictionary.OrderBy(e => e.Key);

         return orderedDictionary.Any() ? orderedDictionary.First().Value : Vector2.zero;

     }

     private void HandleRopeLenght()
     {
         if (Input.GetAxis("Vertical") >= 1f && player.ropeAttached && !player.isColliding)
         {
             player.DistanceJoint.distance -= Time.deltaTime * player.climbSpeed;

         }
         else if (Input.GetAxis("Vertical") < 0f && player.ropeAttached)
         {
             player.DistanceJoint.distance += Time.deltaTime * player.climbSpeed;
         }


     }

     private void OnTriggerStay2D(Collider2D collision)
     {
         player.isColliding = true;
     }

     private void OnTriggerExit2D(Collider2D collision)
     {
         player.isColliding = false;
     }*/
    }
    }
