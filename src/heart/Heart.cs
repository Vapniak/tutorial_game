using Godot;
using System;

public partial class Heart : Area2D
{
    private void OnBodyEntered(Node2D body){
        QueueFree();

        Events.Instance.EmitSignal(Events.SignalName.HeartPickedUp);

        int hearts = GetTree().GetNodeCountInGroup("Hearts");
        if(hearts == 1)
        {
            Events.Instance.EmitSignal(Events.SignalName.LevelCompleted);
        }
    }
}
