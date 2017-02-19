using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Org.Json;
using Newtonsoft.Json.Linq;

namespace ExchangeRate
{
    class Model
    {
        public string date { get; set; }
        public List<InnerModel> exchangeRate { get; set;}
    }
}
