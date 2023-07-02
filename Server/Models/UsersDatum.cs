using System;
using System.Collections.Generic;

namespace FitnessHelper;

public partial class UsersDatum
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public double Height { get; set; }

    public double Weight { get; set; }

    public string Gender { get; set; } = null!;

    public double ActivityRate { get; set; }

    public int Age { get; set; }

    public double BasicСalories { get; set; }

    public string TypeOfDiet { get; set; } = null!;

    public byte[]? WheightChanges { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;
}
