using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;

namespace OpeningPitch
{
    class RegisterValidation : IDataErrorInfo
    {

        public string FName { get; set; }
        public string LName { get; set; }


        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Please enter your first name.");
                }

            }
        }
    }
}
