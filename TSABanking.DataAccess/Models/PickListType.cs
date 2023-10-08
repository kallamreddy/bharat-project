using System;
using System.Collections.Generic;

namespace TSABanking.DataAccess.Models;

public partial class PickListType
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<PickListMaster> PickListMasters { get; set; } = new List<PickListMaster>();
}
