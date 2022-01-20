using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TidUpWeb.Models
{
    public class MultipModel
    {
        public IEnumerable<TBLUSER> m_user { get; set; }
        public IEnumerable<TBLCOMPANY> m_company { get; set; }

    }
}