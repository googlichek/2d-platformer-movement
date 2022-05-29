using Game.Scripts.Data;
using UnityEngine;

namespace Game.Scripts.Core
{
    public class MovementComponent : TickComponent
    {
        [SerializeField]
        protected Rigidbody2D body = default;

        [Space] [SerializeField]
        protected RaycastComponent raycastComponent = default;

        [Space] [SerializeField]
        protected MovementData data = default;

        protected Vector2 velocity = Vector3.zero;

        protected float movementDirection = 0;

        protected float smoothingX = 0;

        protected float maxJumpVelocity = 0;
        protected float minJumpVelocity = 0;

        protected int jumpsCounter = 0;

        protected float dashVelocity = 0;

        protected float dashRemainingTime = 0;

        public MovementData Data => data;

        public Vector2 Velocity => velocity;

        public float MovementDirection => movementDirection;

        public float MaxJumpVelocity => maxJumpVelocity;
        public float MinJumpVelocity => minJumpVelocity;

        public bool AreConsecutiveJumpsDepleted => jumpsCounter >= data.MaxConsecutiveJumps;

        public bool IsDashInProgress => dashRemainingTime > 0;

        public override void Init()
        {
            maxJumpVelocity = Mathf.Abs(Physics2D.gravity.y) * data.TimeToJumpApex;
            minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(Physics2D.gravity.y) * data.MinJumpHeight);

            dashVelocity = data.DashDistance / data.DashDuration;
        }

        public override void Enable()
        {
            velocity = Vector2.zero;

            smoothingX = 0;
        }

        public override void PhysicsTick()
        {
            HandleVericalVelocity();
            HandleHorizontalVelocity();
            ClampVelocity();

            Move();
        }

        public virtual void SetMovementDirection(float x)
        {
            movementDirection = x;
        }

        public virtual void StartDash()
        {
            dashRemainingTime = data.DashDuration;
        }

        public virtual void Dash()
        {
            dashRemainingTime -= Time.deltaTime;
        }

        public virtual void Jump()
        {
            velocity.y = maxJumpVelocity;
            jumpsCounter++;
        }

        public virtual void MinimizeJump()
        {
            velocity.y = minJumpVelocity;
        }

        protected virtual void HandleVericalVelocity()
        {
            if (raycastComponent.HasGround && velocity.y <= 0)
            {
                velocity.y = -data.DefaultGroundVelocityY;

                jumpsCounter = 0;
            }
            else
            {
                velocity.y += Physics2D.gravity.y * Time.fixedDeltaTime;
            }
        }

        protected void HandleHorizontalVelocity()
        {
            var speed = data.WalkSpeed;

            var accelerationTime =
                raycastComponent.HasGround
                    ? data.AccelerationTimeGrounded
                    : data.AccelerationTimeAirborne;

            if (dashRemainingTime > 0)
            {
                speed = dashVelocity;
                accelerationTime = data.AccelerationTimeDash;
            }

            velocity.x =
                Mathf.SmoothDamp(
                    velocity.x,
                    movementDirection * speed,
                    ref smoothingX,
                    accelerationTime,
                    Mathf.Infinity,
                    Time.fixedDeltaTime);
        }

        protected virtual void ClampVelocity()
        {
            velocity.x = Mathf.Clamp(velocity.x, -data.MaxVelocityX, data.MaxVelocityX);
            velocity.y = Mathf.Clamp(velocity.y, -data.MaxVelocityY, data.MaxVelocityY);
        }

        protected virtual void Move()
        {
            body.velocity = velocity;
        }
    }
}
