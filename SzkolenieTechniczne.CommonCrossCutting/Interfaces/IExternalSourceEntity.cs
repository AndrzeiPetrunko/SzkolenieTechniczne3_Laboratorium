using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzkolenieTechniczne.Common.CrossCutting.Interfaces
{
    public interface IExternalSourceEntity
    {
        [MaxLength(5)]
        string? ExternalSourceName { get; set; }
        [MaxLength(38)]
        string? ExternalId { get; set; }
        public DateTime? LastSynchronizedOn { get; set; }
    }
}
