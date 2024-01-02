using System;
using System.Collections.Generic;

namespace CrudApi.Models
{
    public partial class AccountHolderTable
    {
        public AccountHolderTable()
        {
            NomineeTables = new HashSet<NomineeTable>();
        }

        public int AccountholderId { get; set; }
        public string? AccountholderName { get; set; }
        public string? AccountType { get; set; }
        public string? AccountNumber { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<NomineeTable> NomineeTables { get; set; }
    }
}
