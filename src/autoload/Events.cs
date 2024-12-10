using Godot;
using System;

public partial class Events : Node
{
    [Signal] public delegate void LevelCompletedEventHandler();
    [Signal] public delegate void HeartPickedUpEventHandler();

    public static Events Instance {get;private set;}

    public override void _EnterTree()
    {
        if(Instance is null){
            Instance = this;
        }
        else
        {
            QueueFree();
        }
    }

    public override void _ExitTree()
    {
        if(Instance == this){
            Instance = null;
        }
    }
}
