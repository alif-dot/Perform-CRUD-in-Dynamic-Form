using System;
using System.Collections.Generic;

namespace CrudApi.Models
{
    public partial class NomineeTable
    {
        public int NomineeId { get; set; }
        public string? NomineeName { get; set; }
        public int? NomineeAge { get; set; }
        public string? AddressType { get; set; }
        public string? Address { get; set; }
        public int? AccountHolderId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual AccountHolderTable? AccountHolder { get; set; }
    }
}
