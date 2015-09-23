using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class LeaveMsg
    {
        private int id;
        private string name;
        private string tel;
        private string qq;
        private string email;
        private string company;
        private string industry;
        private string interest;
        private DateTime addDate;

        public DateTime AddDate
        {
            get { return addDate; }
            set { addDate = value; }
        }

        public string Interest
        {
            get { return interest; }
            set { interest = value; }
        }

        public string Industry
        {
            get { return industry; }
            set { industry = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Qq
        {
            get { return qq; }
            set { qq = value; }
        }

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
