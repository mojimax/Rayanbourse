using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        string? CreateById { get; set; }
        bool Deleted { get; set; }
    }

}
