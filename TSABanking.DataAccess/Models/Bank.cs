using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSABanking.DataAccess.Models;

public partial class Bank
{
    public int Id { get; set; }

    public string BankName { get; set; } = null!;

    public string Abreviation { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int? CompanyId { get; set; }

    public int Platform { get; set; }

    public string CreatedBy { get; set; } = null!;
    public string? Comments { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public bool Active { get; set; }

    public virtual PickListMaster PlatformNavigation { get; set; } = null!;

    public virtual ICollection<TerminationQueue> TerminationQueues { get; set; } = new List<TerminationQueue>();

    public virtual ICollection<UserBank> UserBanks { get; set; } = new List<UserBank>();

    public virtual Company Company { get; set; } = null!;

    [NotMapped]
    public List<string> SelectedUsers { get; set; } = new List<string>();
}
