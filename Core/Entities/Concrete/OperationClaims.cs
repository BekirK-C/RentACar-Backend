using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class OperationClaims : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }   
}
