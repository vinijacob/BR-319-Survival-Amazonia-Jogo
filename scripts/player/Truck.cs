using Godot;
using System;
using System.Numerics;

public partial class Truck : CharacterBody2D
{
	public Godot.Vector2 direction;
	[Export] public float speed = 500f;

	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		Move();
	}

	public void Move()
	{
		direction = Input.GetVector("left", "right", "up", "down");
		Velocity = direction * speed;
		MoveAndSlide();
	}

}
