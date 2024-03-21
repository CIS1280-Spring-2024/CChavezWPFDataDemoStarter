using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DialogDemo
{
    /// <summary>
    /// Interaction logic for SchoolWindow.xaml
    /// </summary>
    public partial class SchoolWindow : Window
    {
        private School school = new School();

        public SchoolWindow()
        {
            InitializeComponent();
            lbCampuses.ItemsSource = school.Campuses;
            lbCourses.ItemsSource = school.Courses;
            lbMajors.ItemsSource = school.Majors;
            lbStudents.ItemsSource = school.Students;
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentWindow studentWindow = new StudentWindow();
            studentWindow.ShowDialog();
            if (studentWindow.DialogResult == true)
            {
                school.Students.Add(studentWindow.Student);
                lbStudents.Items.Refresh();
            }
            else
            {
                MessageBox.Show("User Cancelled");
            }

        }

        private void btnSaveStudentList_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == true)
            {
                using(StreamWriter file = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (Student student in school.Students)
                    {
                        file.WriteLine(student);
                    }
                }
            }
        }

        private void lbStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Student student = lbStudents.SelectedItem as Student;   
            StudentWindow studentWindow = new StudentWindow(student);
            studentWindow.ShowDialog();
            if (studentWindow.DialogResult == true)
            {
                //DOn't need to add anything already part of list!
                lbStudents.Items.Refresh();
            }
            else
            {
                MessageBox.Show("User Cancelled");
            }
        }

        private void lbStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
