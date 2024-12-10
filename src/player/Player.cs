using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export] public PlayerMovementData MovementData;
    [Export] public AnimatedSprite2D AnimatedSprite;

    private Vector2 velocity;


    private Vector2 startingPosition;

    public override void _Ready()
    {
        startingPosition = GlobalPosition;
    }

    public override void _PhysicsProcess(double delta)
    {
        float inputAxis = Input.GetAxis("move_left", "move_right");

        if(!IsOnFloor()){
            ApplyGravity(delta);

            if(inputAxis != 0){
                Acceleration(delta, inputAxis, MovementData.Speed, MovementData.AirAcceleration);
            }
            else {
                Friction(delta, MovementData.AirFriction);
            }
        }
        else{
            if(inputAxis != 0){
                Acceleration(delta, inputAxis, MovementData.Speed, MovementData.Acceleration);
            }
            else {
                Friction(delta, MovementData.Friction);
            }

            if(Input.IsActionJustPressed("jump")){
                Jump();
            }
        }

        Velocity = velocity;
        MoveAndSlide();
        velocity = Velocity;

        UpdateAnimations(inputAxis);
    }

    private void ApplyGravity(double delta){
        velocity -= UpDirection * MovementData.Gravity * (float)delta;
    }

    private void Acceleration(double delta, float axis, float speed, float acceleration){
        velocity.X = Mathf.Lerp(velocity.X, speed * axis, (float)delta * acceleration);   
    }

    private void Jump(){
        velocity.Y = -Mathf.Sqrt(2 * MovementData.Gravity * MovementData.JumpSpeed);
    }

    private void Friction(double delta, float friction){
        velocity.X = Mathf.Lerp(velocity.X, 0, friction * (float)delta);
    }

    private void UpdateAnimations(float input){
        if(input != 0){
            AnimatedSprite.FlipH = input < 0;
            AnimatedSprite.Play("run");
        }
        else 
        {
            AnimatedSprite.Play("idle");
        }

        if(!IsOnFloor()){
            AnimatedSprite.Play("jump");
        }
    }

    private void OnHazardDetected(Area2D area){
       Reset();
    }

    private void Reset(){
        GlobalPosition = startingPosition;
        velocity = Vector2.Zero;
    }
}
