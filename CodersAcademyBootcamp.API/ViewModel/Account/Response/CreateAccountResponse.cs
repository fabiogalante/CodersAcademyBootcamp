using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hyperion.ViewModel.Account.Response
{
    public class CreateAccountResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Photo { get; set; }
    }
}
