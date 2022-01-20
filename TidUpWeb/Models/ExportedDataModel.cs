using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TidUpWeb.Models
{
    public class ExportedDataModel
    {
        public string name { get; set; }
        public decimal? price { get; set; }
        public System.DateTime date { get; set; }
        public int? Barcode { get; set; }

        public string folder { get; set; }
        public int? quantity { get; set; }

        public static explicit operator ExportedDataModel(List<object> v)
        {
            throw new NotImplementedException();
        }
    }
}