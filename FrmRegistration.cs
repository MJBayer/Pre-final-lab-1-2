using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Muit
{
    public partial class FrmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        public static string SetFileName; 
        public FrmRegistration()
        {
            InitializeComponent();
        }
        public long StudentNumber(string studNum)
        {
            if (Regex.IsMatch(studNum, @"^[0-9]{1,15}$"))
            {
                _StudentNo = long.Parse(studNum);
            }
            else
            {
                throw new FormatException("The user must only enter a numeral data in the Student No. textbox.");
            }

            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }
            else
            {
                throw new FormatException("The user must only enter numbers in the Contact No. textbox.");
            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") && Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }
            else
            {
                throw new FormatException("The user must only enter a character or alphabets in the Name's textbox.");
            }

            return _FullName;
        }

        public int Age(string age)
        {
            if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }
            else
            {
                throw new FormatException("The user must only enter a number in the Age textbox.");
            }

            return _Age;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthDay = datePickerBirthday.Value.ToString("yyyyMM-dd");

            }
            catch (FormatException x)
            {
                MessageBox.Show(x.Message);
            }

            string StudNo = txtStudentNo.Text;
            string LastName = txtLastName.Text;
            string FirstName = txtFirstName.Text;
            string MiddleInitial = txtMiddleInitial.Text;
            string getAge = txtAge.Text;
            string getContactNo = txtContactNo.Text;
            string Programs = cbPrograms.Text;
            string Gender = cbGender.Text;
            string Birthday = datePickerBirthday.Text;

            string SetFileName = txtStudentNo.Text + ".txt";

            string docpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docpath, SetFileName)))

            {

                outputFile.WriteLine("Student No.: " + StudNo);
                outputFile.WriteLine("Full Name : " + LastName + FirstName + MiddleInitial);
                outputFile.WriteLine("Program: " + Programs);
                outputFile.WriteLine("Gender: " + Gender);
                outputFile.WriteLine("Age.: " + getAge);
                outputFile.WriteLine("Birthday.: " + Birthday);
                outputFile.WriteLine("Contact No.: " + getContactNo);
            }
            this.Close();
        }

        private void datePickerBirthday_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Information Systems",
                "BS in Accountancy",
                "BS in Hospitality Management",
                "BS in Tourism Management",
            };
            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }

            string[] ListOfGender = new string[]
            {
                "Female",
                "Male",
                "LGBTQ"

            };
            for (int i = 0; i < 3; i++)
            {
                cbGender.Items.Add(ListOfGender[i].ToString());
            }

        }
    }
}

