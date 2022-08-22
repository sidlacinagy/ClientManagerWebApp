using ClientManager.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManager.Shared.Dtos
{
    public class SearchFilterDto
    {
        public string? IdNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public ClientTypes? ClientType { get; set; }
    }
}
