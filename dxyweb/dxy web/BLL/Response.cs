using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
   public  class Response
    {

        private int code=-1;

        public int Code
        {
            get { return code; }
            set { code = value; }
        }

        private string msg="UNDEAL";

        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }

        private object data;

        public object Data
        {
            get { return data; }
            set { data = value; }
        }

        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
