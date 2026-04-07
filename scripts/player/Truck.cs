using Godot;
using System;

public partial class Truck : CharacterBody2D
{
	[Export] public float maxSpeed = 1000f;
	[Export] public float acceleration = 1200f;
	[Export] public float friction = 800f;
	[Export] public float rotationSpeed = 2.5f;
	[Export] public float traction = 0.1f;
	[Export] public float maxFuel = 100f;
	[Export] public float fuelConsumption = 5f;
	public float fuel;
	private Vector2 velocity = Vector2.Zero;

	[Export] public float nitroMultiplier = 2f;
	[Export] public float nitroFuelMultiplier = 2f;
	[Export] public float nitroDuration = 5f;
	[Export] public float nitroCooldown = 30f;
	private bool isNitroActive = false;
	private bool canUseNitro = true;
	private float nitroTimer = 0f;
	private float cooldownTimer = 0f;

	public override void _Ready()
	{
		fuel = maxFuel;
	}

	public override void _PhysicsProcess(double delta)
	{
		Move((float)delta);
	}

	private void Move(float delta)
	{
		float inputForward = Input.GetActionStrength("down") - Input.GetActionStrength("up");
		float inputTurn = Input.GetActionStrength("left") - Input.GetActionStrength("right");
		Vector2 forward = Vector2.Right.Rotated(Rotation);

		if (fuel <= 0)
		{
			inputForward = 0;
		}

		if (Input.IsActionPressed("ui_accept") && canUseNitro)
		{
			isNitroActive = true;
			canUseNitro = false;
			nitroTimer = 0f;
		}

		if (isNitroActive)
		{
			nitroTimer += delta;
			if (nitroTimer >= nitroDuration)
			{
				isNitroActive = false;
				cooldownTimer = 0f;
			}
		}
		else if (!canUseNitro)
		{
			cooldownTimer += delta;
			if (cooldownTimer >= nitroCooldown)
			{
				canUseNitro = true;
			}
		}

		float actualAcceleration = acceleration;
		float actualFuelConsumption = fuelConsumption;
		if (isNitroActive)
		{
			actualAcceleration *= nitroMultiplier;
			actualFuelConsumption *= nitroFuelMultiplier;
		}

		if (inputForward != 0)
		{
			velocity += forward * inputForward * actualAcceleration * delta;
			velocity = velocity.LimitLength(maxSpeed);
		}
		else
		{
			velocity = velocity.MoveToward(Vector2.Zero, friction * delta);
		}

		if (velocity.Length() > 10f)
		{
			float turnAmount = inputTurn * rotationSpeed * delta;
			if (velocity.Dot(forward) < 0)
			{
				turnAmount *= -1;
			}
			Rotation += turnAmount;
		}

		if (velocity.Length() > 10f && fuel > 0)
		{
			fuel -= actualFuelConsumption * delta;
			fuel = Mathf.Clamp(fuel, 0, maxFuel);
		}

		Vector2 forwardVel = forward * velocity.Dot(forward);
		Vector2 sideVel = velocity - forwardVel;
		velocity = forwardVel + sideVel * (1 - traction);

		Velocity = velocity;
		MoveAndSlide();
	}

	public void Refuel(float amount)
	{
		fuel += amount;
		fuel = Mathf.Clamp(fuel, 0, maxFuel);
	}
}