using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimarySchoolManagentSystem
{
    class GlobalVariableClass
    {
        private static string v_variable_role = "";

        public static string variable_role
        {
            get {return v_variable_role; }
            set { v_variable_role = value; }
        }
    }
}
