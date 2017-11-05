using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankOfBIT.Models;

namespace WindowsBankingApplication
{
    /// <summary>
    /// given:TO BE MODIFIED
    /// this class is used to capture data to be passed
    /// among the windows forms
    /// </summary>
    public class ConstructorData
    {
        /// <summary>
        /// Creating an autoimplemented property of client
        /// </summary>
        public Client client { get; set; }

        /// <summary>
        /// Creating an autoimlemented property of bank account
        /// </summary>
        public BankAccount bankAccount { get; set; }


     }
}
