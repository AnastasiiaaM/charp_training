using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allDetails;

        public ContactData()
        {
        }
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Nickname { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    string bufer = "";

                    if (HomePhone != null && HomePhone != "")
                    {
                        bufer = bufer + CleanUpPhone(HomePhone);
                    }
                    if (MobilePhone != null && MobilePhone != "")
                    {
                        bufer = bufer + "\r\n" + CleanUpPhone(MobilePhone);
                    }
                    if (WorkPhone != null && WorkPhone != "")
                    {
                        bufer = bufer + "\r\n" + CleanUpPhone(WorkPhone);
                    }
                    return bufer;
                }
            }
            set
            {
                allPhones = value;
            }
        }
        private string CleanUpPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[- ()]", "");
        }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    string bufer = "";

                    if (Email != null && Email != "")
                    {
                        bufer = bufer + Email;
                    }
                    if (Email2 != null && Email2 != "")
                    {
                        bufer = bufer + "\r\n" + Email2;
                    }
                    if (Email3 != null && Email3 != "")
                    {
                        bufer = bufer + "\r\n" + Email3;
                    }
                    return bufer;
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string Homepage { get; set; }
        public string Notes { get; set; }
        
        
        private string CleanUpAllDetails(string allDetails)
        {
            if (allDetails == null || allDetails == "")
            {
                return "";
            }
            return allDetails + "\r\n";
        }

        public string AllDetails
        {
            get
            {
                if (allDetails != null)
                {
                    return allDetails;
                }
                else
                {
                    string details = (CleanUpAllDetails(GetContacts(Firstname, Middlename, Lastname, Address))
                        + CleanUpAllDetails(GetPhones(HomePhone, MobilePhone, WorkPhone))
                        + CleanUpAllDetails(GetEmails(Email, Email2, Email3))).Trim();

                    return details;
                }
            }
            set
            {
                allDetails = value;
            }
        }

        private string GetContacts(string firstname, string middlename, string lastname, string address)
        {
            return CleanUpAllDetails(GetFullName(firstname, middlename, lastname))
                + CleanUpAllDetails(address);
        }

        private string GetFullName(string firstname, string middlename, string lastname)
        {
            string bufer = "";
            if (firstname != null && firstname != "")
            {
                bufer = bufer + Firstname + " ";
            }
            if (middlename != null && middlename != "")
            {
                bufer = bufer + Middlename + " ";
            }
            if (lastname != null && lastname != "")
            {
                bufer = bufer + Lastname + " ";
            }
            return bufer.Trim();
        }

        private string GetPhones(string homePhone, string mobilePhone, string workPhone)
        {
            string bufer = "";
            if (homePhone != null && homePhone != "")
            {
                bufer = bufer + "H: " + HomePhone + "\r\n";
            }
            if (mobilePhone != null && mobilePhone != "")
            {
                bufer = bufer + "M: " + MobilePhone + "\r\n";
            }
            if (workPhone != null && workPhone != "")
            {
                bufer = bufer + "W: " + WorkPhone + "\r\n";
            }
            return bufer;
        }

        private string GetEmails(string email, string email2, string email3)
        {
            string bufer = "";

            if (email != null && email != "")
            {
                bufer = bufer + email ;
            }
            if (email2 != null && email2 != "")
            {
                bufer = bufer + "\r\n" + email2 ;
            }
            if (email3 != null && email3 != "")
            {
                bufer = bufer + "\r\n" + email3 ;
            }
            return bufer;
        }


        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "lastname=" + Lastname + "\n" + "firstname=" + Firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }
    }
}
