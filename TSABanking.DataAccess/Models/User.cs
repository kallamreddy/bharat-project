using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSABanking.DataAccess.Models;

public partial class User
{
    public int Id { get; set; }

    public string EmployeeId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string MiddleInitial { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public int UserType { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<JobChangeQueue> JobChangeQueueSuperVisors { get; set; } = new List<JobChangeQueue>();

    public virtual ICollection<JobChangeQueue> JobChangeQueueUsers { get; set; } = new List<JobChangeQueue>();

    public virtual ICollection<TerminationQueue> TerminationQueueSuperVisors { get; set; } = new List<TerminationQueue>();

    public virtual ICollection<TerminationQueue> TerminationQueueUsers { get; set; } = new List<TerminationQueue>();

    public virtual ICollection<UserBank> UserBanks { get; set; } = new List<UserBank>();

    public virtual PickListMaster UserTypeNavigation { get; set; } = null!;

    [NotMapped]
    public List<string> SelectedBanks { get; set; } = new List<string>();

}
