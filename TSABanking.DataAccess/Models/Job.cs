using System;
using System.Collections.Generic;

namespace TSABanking.DataAccess.Models;

public partial class Job
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public bool Active { get; set; }

    public virtual ICollection<JobChangeQueue> JobChangeQueueNewJobs { get; set; } = new List<JobChangeQueue>();

    public virtual ICollection<JobChangeQueue> JobChangeQueueOldJobs { get; set; } = new List<JobChangeQueue>();
}
