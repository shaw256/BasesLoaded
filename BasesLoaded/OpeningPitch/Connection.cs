using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasesLoaded
{
    public class Connection
    {
        public void SQL_Connection()
        {
        }
        public void SMTP_Email_Connect()
        {
        }
    }
    public class SQL_Connection : Connection
    {
        public void Open_Connection()
        {
        }
        public void Close_Connection()
        {
        }
    }
    public class SMTP_EmailConnect : Connection
    {
        public void Get_Email()
        {
        }
        public void Send_Email()
        {
        }
    }
}
