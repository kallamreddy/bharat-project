using System;
using System.Collections.Generic;

namespace TSABanking.DataAccess.Models;

public partial class PickListMaster
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Value { get; set; } = null!;

    public int Type { get; set; }

    public bool Active { get; set; }

    public virtual ICollection<Bank> Banks { get; set; } = new List<Bank>();

    public virtual PickListType TypeNavigation { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
