using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsModHarodoor.Common
{
    public class ClsModResultado
    {

        public ClsModResultado()
        {
            this.MsgError = string.Empty;

        }
        public string MsgError { get; set; }
        public string MsgExito { get; set; }
        public int Id { get; set; }

        public bool Error { get { return !String.IsNullOrEmpty(MsgError); } }

    }
}
