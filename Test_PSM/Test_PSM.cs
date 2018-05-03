using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrimarySchoolManagentSystem;
using System.Windows.Forms;

namespace Test_PSM
{
    

    [TestClass]
    public class Test_PSM
    {
        [TestMethod]
        public void addStudent()
        {
            //arrange
            StudentProfile sp = new StudentProfile();

            //act
            String name = "Shoma";
            string dob = "17-12-1993";
            string address = "Jessore";
            string fathers_name = "Jamir Uddin Ahmed";
            string fathers_occupation = "Service";
            string mothers_name = "Sarmin Aktar";
            string mothers_occupation = "Housewife";
            String current_class = "5";
            String admitted_in_class = "1";
            String roll_number = "1";
            string archieved_year = "not yet";

            Boolean t = sp.add(name, dob, address, fathers_name, fathers_occupation, mothers_name, mothers_occupation, current_class, admitted_in_class, roll_number, archieved_year);

            //assert
            Assert.AreEqual(true, t);
        }
        [TestMethod]
        public void updateStudent()
        {
            //arrange
            StudentProfile sp = new StudentProfile();

            //act
            String name="Jihad"; 
            string dob="17-12-1993";
            string address="Jessore";
            string fathers_name="Jamir Uddin Ahmed";
            string fathers_occupation="Service";
            string mothers_name="Sarmin Aktar"; 
            string mothers_occupation="Housewife";
            String current_class="5";
            String admitted_in_class="1";
            String roll_number="1";
            string archieved_year="not yet";
           
            Boolean t= sp.update(name, dob, address, fathers_name, fathers_occupation, mothers_name, mothers_occupation, current_class, admitted_in_class, roll_number, archieved_year);
            
            //assert
            Assert.AreEqual(true,t);
        }

        [TestMethod]
        public void deleteStudent()
        {
            //arrange
            StudentProfile sp = new StudentProfile();

            //act
            String name = "Jihad";

            Boolean t = sp.delete(name);

            //assert
            Assert.AreEqual(true, t);
        }

        [TestMethod]
        public void cleartext()
        {
            //arrange
            StudentProfile sp = new StudentProfile();

            //act
            Boolean t = sp.clearText();

            //assert
            Assert.AreEqual(true, t);
            
        }

        [TestMethod]
        public void updateTeacher()
        {
            //arrange
            StaffManagement sm = new StaffManagement();


            //act
            string full_name="aaaa";
            string address="india";
            string phone_number="999767676";
            string email="sdhfsdkfdj@jfhs.jhf";
            string role="Head Master";
            string dob="20-12-1961";
            string sex="Male";
            string jsy = "2007";

            Boolean t = sm.update( full_name, address, phone_number, email, role, dob, sex, jsy);

            //assert
            Assert.AreEqual(true, t);
        }

    }
}
