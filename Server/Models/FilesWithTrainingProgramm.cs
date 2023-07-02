using System;
using System.Collections.Generic;

namespace FitnessHelper;

public partial class FilesWithTrainingProgramm
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string Title { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public byte[] FileData { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;
}
