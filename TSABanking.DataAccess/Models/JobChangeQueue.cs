using System;
using System.Collections.Generic;

namespace TSABanking.DataAccess.Models;

public partial class JobChangeQueue
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int SuperVisorId { get; set; }

    public int OldJobId { get; set; }

    public int NewJobId { get; set; }

    public bool Active { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Job NewJob { get; set; } = null!;

    public virtual Job OldJob { get; set; } = null!;

    public virtual User SuperVisor { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
