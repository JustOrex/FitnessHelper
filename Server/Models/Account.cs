using System;
using System.Collections.Generic;

namespace FitnessHelper;

public partial class Account
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<FilesWithTrainingProgramm> FilesWithTrainingProgramms { get; set; } = new List<FilesWithTrainingProgramm>();

    public virtual ICollection<UsersDatum> UsersData { get; set; } = new List<UsersDatum>();
}
