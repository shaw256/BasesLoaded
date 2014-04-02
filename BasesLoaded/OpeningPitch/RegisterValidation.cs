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

        public string FName         { get; set; }
        public string LName         { get; set; }
        public string Address1      { get; set; }
        public string Address2      { get; set; }
        public string City          { get; set; }
        public string Zipcode       { get; set; }
        public string Email         { get; set; }
        public string PhoneNumber   { get; set; }
        public string Gender        { get; set; }
        public string Position      { get; set; }
        public string AltPosition1  { get; set; }
        public string AltPosition2  { get; set; }


        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "FName")
                {
                    if(string.IsNullOrEmpty(FName))
                    {
                        result = "Please enter a First Name";
                    }
                }

                if (columnName == "LName")
                {
                    if(string.IsNullOrEmpty(LName))
                    {
                        result = "Please enter a Last Name";
                    }
                }

                if (columnName == "Address1")
                {
                    if(string.IsNullOrEmpty(Address1))
                    {
                        result = "Please enter your address.";
                    }
                }

                if (columnName == "Address2")
                {
                }

                if (columnName == "City")
                {
                    if (string.IsNullOrEmpty(City))
                    {
                        result = "Please enter your city.";
                    }
                }

                if (columnName == "Zipcode")
                {
                    if (string.IsNullOrEmpty(Zipcode))
                    {
                        result = "Please enter your Zipcode.";
                    }
                }

                if (columnName == "Email")
                {
                    if (string.IsNullOrEmpty(Email))
                    {
                        result = "Please enter your address.";
                    }
                }

                if (columnName == "PhoneNumber")
                {
                    if (string.IsNullOrEmpty(PhoneNumber))
                    {
                        result = "Please enter your phone number.";
                    }
                }

                if (columnName == "Gender")
                {
                    if (string.IsNullOrEmpty(Gender))
                    {
                        result = "Please select a gender.";
                    }
                }

                if (columnName == "Position")
                {
                    if (string.IsNullOrEmpty(Position))
                    {
                        result = "Please select a position.";
                    }
                }

                if (columnName == "AltPosition1")
                {
                    
                }

                if (columnName == "AltPosition2")
                {

                }
                return result;
            }
        }

    }
}
