using Godot;
using System;

[GlobalClass]
public partial class PlayerMovementData : Resource
{
    [Export] public float Speed {get;private set;} = 100; 
    [Export] public float Gravity {get;private set;} =  10;
    [Export] public float JumpSpeed {get;private set;} = 100;
    [ExportGroup("Ground")]
    [Export] public float Acceleration {get;private set;} = 1000;
    [Export] public float Friction {get;private set;} = 1000;
    [ExportGroup("Air")]
    [Export] public float AirAcceleration {get;private set;} = 1000;
    [Export] public float AirFriction {get;private set;} = 1000;
}
