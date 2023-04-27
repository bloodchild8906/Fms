using System;

namespace Fsm.Domain.Entities;

public class Documents
{
    public Documents()
    {
    }

    public Guid Id { get; set; }

    public string File { get; set; }

    public string FileType { get; set; }

    public bool? RequiresAction { get; set; }

    public bool? TimeSensitive { get; set; }

    public bool? IsComplete { get; set; }

    public string ActionType { get; set; }

    public DateTime? DueOn { get; set; }

    public DateTime SentOn { get; set; }

    public DateTime UpdatedOn { get; set; }
}