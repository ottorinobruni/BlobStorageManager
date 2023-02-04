using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobStorageManager.Models.Entity
{
    public class EntityBase
    {
        public Guid Id { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
