using Godot;
using System;

public partial class World : Node2D
{
    [Export] private PackedScene NextLevel;
    [Export] private Label HeartCount;

    public override void _Ready()
    {
        Events.Instance.LevelCompleted += OnLevelCompleted;
        
        CallDeferred(MethodName.UpdateHeartCount);
        Events.Instance.HeartPickedUp += () => {UpdateHeartCount(); }; 
    }

    private void OnLevelCompleted(){
        GoToNextLevel();
    }

    private void GoToNextLevel(){
        if(NextLevel is null) return;

        GetTree().ChangeSceneToPacked(NextLevel);
    }

    private void UpdateHeartCount(){
        HeartCount.Text = GetTree().GetNodeCountInGroup("Hearts") .ToString();
    }
}
