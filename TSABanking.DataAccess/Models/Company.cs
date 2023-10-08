using System;
using System.Collections.Generic;

namespace TSABanking.DataAccess.Models;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<TerminationQueue> TerminationQueues { get; set; } = new List<TerminationQueue>();
}
