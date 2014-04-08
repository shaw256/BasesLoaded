using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Net.Mail;

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
        public string TeamChoice    { get; set; }
        public string NewTeamName   { get; set; }

        private bool ValidateEmail(string emailaddress)
        {
            
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailaddress);
            if (match.Success)
                return true;
            else
                return false;
        }

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

                    else if (Regex.IsMatch(FName, @"[\W\d]" ))
                    {
                        result = "First name cannot contain non-letters.";
                    }
                }

                if (columnName == "LName")
                {
                    if(string.IsNullOrEmpty(LName))
                    {
                        result = "Please enter a Last Name";
                    }

                    else if (Regex.IsMatch(LName, @"[\W\d^]"))
                    {
                        result = "Last name cannot contain non-letters.";
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

                    else if (Regex.IsMatch(City, @"\d"))
                    {
                        result = "City can contain only letters.";
                    }
                }

                if (columnName == "Zipcode")
                {
                    if (string.IsNullOrEmpty(Zipcode))
                    {
                        result = "Please enter your Zipcode.";
                    }

                    else if (Zipcode.Length != 5)
                    {
                        result = "Zipcode cannot exceed 5 digits";
                    }

                    else if (Regex.IsMatch(Zipcode, @"\D"))
                    {
                        result = "Zipcode can contain only numbers.";
                    }
                }

                if (columnName == "Email")
                {
                    if (string.IsNullOrEmpty(Email))
                    {
                        result = "Please enter your email address.";
                    }

                    else if (!ValidateEmail(Email))
                    {
                        result = "Please enter a valid email address.";
                    }

                    else if (Email.Length > 50)
                    {
                        result = "Email addresses cannot exceed 50 characters.";
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

                    if (Position != null)
                    {
                        if (Position == AltPosition1 || Position == AltPosition2)
                            {
                                result = "You have selected duplicate positions.";
                            }
                    }
                }

                if (columnName == "AltPosition1")
                {
                    if (AltPosition1 != null && AltPosition1 != "")
                    {

                        if (AltPosition1 == Position || AltPosition1 == AltPosition2)
                        {
                            result = "Please select a different position than already selected.";
                        }
                    }
                }

                if (columnName == "AltPosition2")
                {
                    if (AltPosition2 != null && AltPosition2 != "")
                    {

                        if (AltPosition2 == Position || AltPosition1 == AltPosition2)
                        {
                            result = "Please select a different position than already selected.";
                        }
                    }
                }

                if (columnName == "TeamChoice")
                {
                    if (TeamChoice == null)
                    {
                        if (NewTeamName == null)
                        {
                            result = "Please select an option.";
                        }
                        
                    }
                }

                if (columnName == "NewTeamName")
                {
                    if (NewTeamName == null)
                    {
                        if (TeamChoice == null)
                        {
                            result = "Please select an option.";
                        }
                    }
                }

                return result;
            }
        }

    }
}
