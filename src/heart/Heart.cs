using Godot;
using System;

public partial class Heart : Area2D
{
    private void OnBodyEntered(Node2D body){
        QueueFree();

        int hearts = GetTree().GetNodeCountInGroup("Hearts");
        if(hearts == 1)
        {
            
        }
    }
}
