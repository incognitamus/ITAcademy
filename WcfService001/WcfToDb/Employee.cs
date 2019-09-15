using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfService001
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int EmployeeID { get; set; }
        [DataMember]
        public string Firstname { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string TitleofCourtesy { get; set; }
        [DataMember]
        public string BirthDate { get; set; }
        [DataMember]
        public string HireDate { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Region { get; set; }
        [DataMember]
        public int PostalCode { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public int HomePhone { get; set; }
        [DataMember]
        public int Extension { get; set; }
        [DataMember]
        public string Photo { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public int ReportsTo { get; set; }
        [DataMember]
        public string PhotoPath { get; set; }

    }
}
