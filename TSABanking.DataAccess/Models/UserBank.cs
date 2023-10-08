using System;
using System.Collections.Generic;

namespace TSABanking.DataAccess.Models;

public partial class UserBank
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int BankId { get; set; }

    public virtual Bank Bank { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
