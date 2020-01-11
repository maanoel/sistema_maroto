using Tapioca.HATEOAS;
using System.Collections.Generic;
using System;

namespace LojaVirtual.Model
{
    public class UserVO
    {
        public long? Id {get;set;}
        public string Login { get; set; }
        public string AccessKey { get; set; }
        public string Name { get;  set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        
    }
}
