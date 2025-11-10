using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Holcim.DocumetsService.Domain.Models
{
    public class SubastaUpdatePathModel
    {
        public Guid IdSubasta { get; set; }
        public string Path { get; set; } = string.Empty;
    }
}
