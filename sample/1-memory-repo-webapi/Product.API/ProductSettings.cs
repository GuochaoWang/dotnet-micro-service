using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceStructure.Service.Product.API
{
    public class ProductSettings
    {
        public string ConnectionString { get; set; }

        public string EventBusConnection { get; set; }
    }
}
