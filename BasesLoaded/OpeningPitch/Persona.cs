using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpeningPitch;

namespace OpeningPitch
{
    public class Persona
    {
        private string _email;
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _address;
        private string _address2;
        private string _city;
        private string _state;
        private string _zipcode;
        private string _position;
        private string _altPosition;
        private string _altPosition2;
        private string _gender;
        private int _userType;
        private int _PID;
        private System.Nullable<int> _TID;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string Address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string Zipcode
        {
            get { return _zipcode; }
            set { _zipcode = value; }
        }
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public string AltPosition
        {
            get { return _altPosition; }
            set { _altPosition = value; }
        }
        public string AltPosition2
        {
            get { return _altPosition2; }
            set { _altPosition2 = value; }
        }
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public int UserType
        {
            get { return _userType; }
            set { _userType = value; }
        }

        public int PID
        {
            get { return _PID; }
            set { _PID = value; }
        }
        public System.Nullable<int> TID
        {
            get { return _TID; }
            set { _TID = value; }
        }

    }
}
