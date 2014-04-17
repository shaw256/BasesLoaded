using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace OpeningPitch
{
    class RegisterValidation : IDataErrorInfo, INotifyPropertyChanged
    {

        LINQtoSQLDataContext databaseCheck = new LINQtoSQLDataContext();

       #region Private Variables
       private string _FName;
       private string _LName;
       private string _Address1;
       private string _Address2;
       private string _City;
       private string _Zipcode;
       private string _Email;
       private string _PhoneNumber;
       private string _Gender;
       private string _Position; 
       private string _AltPosition1;
       private string _AltPosition2;
       private string _TeamChoice;
       private string _NewTeamName;
       private string _AccountType;
       #endregion

       #region Properties
       public string FName        
        {
            get { return _FName; }

            set 
            { 
                if (_FName != value)
                {
                    _FName = value;
                    OnPropertyChanged("FName");
                    
                }
            }
        }
        public string LName
        {
            get { return _LName; }

            set
            {
                if (_LName != value)
                {
                    _LName = value;
                    OnPropertyChanged("LName");

                }
            }
        }
        public string Address1
        {
            get { return _Address1; }

            set
            {
                if (_Address1 != value)
                {
                    _Address1 = value;
                    OnPropertyChanged("Address1");

                }
            }
        }

        public string Address2
        {
            get { return _Address2; }

            set
            {
                if (_Address2 != value)
                {
                    _Address2 = value;
                    OnPropertyChanged("Address2");

                }
            }
        }

        public string City
        {
            get { return _City; }

            set
            {
                if (_City != value)
                {
                    _City = value;
                    OnPropertyChanged("City");

                }
            }
        }

        public string Zipcode
        {
            get { return _Zipcode; }

            set
            {
                if (_Zipcode != value)
                {
                    _Zipcode = value;
                    OnPropertyChanged("Zipcode");

                }
            }
        }

        public string Email
        {
            get { return _Email; }

            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    OnPropertyChanged("Email");

                }
            }
        }

        public string PhoneNumber
        {
            get { return _PhoneNumber; }

            set
            {
                if (_PhoneNumber != value)
                {
                    _PhoneNumber = value;
                    OnPropertyChanged("PhoneNumber");

                }
            }
        }

        public string Gender
        {
            get { return _Gender; }

            set
            {
                if (_Gender != value)
                {
                    _Gender = value;
                    OnPropertyChanged("Gender");

                }
            }
        }

        public string Position
        {
            get { return _Position; }

            set
            {
                if (_Position != value)
                {
                    _Position = value;
                    OnPropertyChanged("Position");

                }
            }
        }

        public string AltPosition1
        {
            get { return _AltPosition1; }

            set
            {
                if (_AltPosition1 != value)
                {
                    _AltPosition1 = value;
                    OnPropertyChanged("AltPosition1");

                }
            }
        }

        public string AltPosition2
        {
            get { return _AltPosition2; }

            set
            {
                if (_AltPosition2 != value)
                {
                    _AltPosition2 = value;
                    OnPropertyChanged("AltPosition2");

                }
            }
        }

        public string TeamChoice
        {
            get { return _TeamChoice; }

            set
            {
                if (_TeamChoice != value)
                {
                    _TeamChoice = value;
                    OnPropertyChanged("TeamChoice");
                    OnPropertyChanged("NewTeamName");
                    OnPropertyChanged("AccountType");

                }
            }
        }

        public string NewTeamName
        {
            get { return _NewTeamName; }

            set
            {
                if (_NewTeamName != value)
                {
                    _NewTeamName = value;
                    OnPropertyChanged("TeamChoice");
                    OnPropertyChanged("NewTeamName");
                    OnPropertyChanged("AccountType");

                }
            }
        }

        public string AccountType
        {
            get { return _AccountType; }

            set
            {
                if (_AccountType != value)
                {
                    _AccountType = value;
                    OnPropertyChanged("TeamChoice");
                    OnPropertyChanged("NewTeamName");
                    OnPropertyChanged("AccountType");

                }
            }
        }
        #endregion

       #region INotifyPropertyChanged Members
       public event PropertyChangedEventHandler PropertyChanged;
        
        private void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
       #endregion

        private bool ValidateEmail(string emailaddress)
        {

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailaddress);
            if (match.Success)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        private bool ValidatePhone(string phone)
        {
           if (phone.Length == 16)
            {
                return true;
            }
            else return false;


        }

        private bool IsEmailUnique(string emailaddress)
        {
            var checkEmailAddresses = from players in databaseCheck.Players
                                      where players.Email == emailaddress
                                      select players;

            if (checkEmailAddresses.Count() > 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }


        private bool IsTeamUnique(string teamToBeChecked)
        {
            var isThereATeam = from teams in databaseCheck.Teams
                               where teams.TeamName == teamToBeChecked
                               select teams;

            if (isThereATeam.Count() > 0)
            {
                return false;
            }

            else
            {
                return true;
            }
        }


        #region IDataErrorInfo Member
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        #endregion

        #region Error Validation
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

                    else if (Regex.IsMatch(FName, @"[\d]" ))
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

                    else if (!IsEmailUnique(Email))
                    {
                        result = "This email is already in use!";
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
                    else if (!ValidatePhone(PhoneNumber))
                    {
                        result = "Please enter a valid phone number";
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


                if (columnName == "AccountType")
                {
                    if (AccountType == null)
                    {
                        result = "Please make a selection.";
                    }

                    if (AccountType == "Team Captain" && String.IsNullOrEmpty(NewTeamName))
                    {
                        result = "Please enter a team.";
                    }

                    if (AccountType == "Team Player" && String.IsNullOrEmpty(TeamChoice))
                    {
                        result = "Please select a team.";
                    }

                }

                if (columnName == "TeamChoice")
                {
                    if (AccountType == "Team Player")
                    {
                        if (String.IsNullOrEmpty(TeamChoice))
                        {
                            result = "Please select a team.";
                        }
                    }

                    if (AccountType == "Team Captain")
                    {
                        if (!(String.IsNullOrEmpty(TeamChoice)))
                        {
                            result = "Do not select a team if you want to make your own!";
                        }
                    }
                }

                if (columnName == "NewTeamName")
                {
                    if (String.IsNullOrEmpty(NewTeamName))
                    {
                        if (AccountType == "Team Captain")
                        {
                            result = "Please make a selection.";
                        }
                    }

                    else if (Regex.IsMatch(NewTeamName, @"[\W\d]"))
                    {
                        result = "Team name cannot contain non-letters.";
                    }

                    if (AccountType == "Team Player")
                    {
                        if (!(String.IsNullOrEmpty(NewTeamName)))
                        {
                            result = "Please use the selection box to choose a team.";
                        }
                    }

                    if (!IsTeamUnique(NewTeamName))
                    {
                        result = "This team already exists!";
                    }
                        

                }

                return result;
            }
        }
        #endregion

    }
}
