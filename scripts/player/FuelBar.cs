using Godot;
using System;

public partial class FuelBar : ProgressBar
{
	[Export] public NodePath truckPath;

	private Truck truck;

	public override void _Ready()
	{
		if (truckPath != null && truckPath != "")
		{
			truck = GetNode<Truck>(truckPath);
		}

		if (truck != null)
		{
			MaxValue = truck.maxFuel;
			Value = truck.fuel;
		}
	}

	public override void _Process(double delta)
	{
		if (truck != null)
		{
			Value = truck.fuel;
		}
	}
}