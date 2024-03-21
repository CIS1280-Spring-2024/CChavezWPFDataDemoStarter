using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DialogDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        private Student _student;
        public Student Student 
        { 
            get { return _student; }
            set { _student = value;}
        }   

        public StudentWindow(): this(new Student())
        {
        }

        public StudentWindow(Student student)
        {
            InitializeComponent();
            _student = student;
            txbFirstName.Text = _student.FirstName;
            txbLastName.Text = _student.LastName;
            txbStudentNum.Text = _student.StudentNumber;
            txbMajor.Text = _student.Major;
            lbScores.ItemsSource = _student.Scores;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Assignment assign = new Assignment();
            assign.Title = txbTitle.Text;
            assign.Score = int.Parse(txbScore.Text);
            _student.AddScore(assign);
            lbScores.Items.Refresh();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            //Set the values from our controls into the class
            _student.FirstName = txbFirstName.Text;
            _student.LastName = txbLastName.Text;
            _student.StudentNumber = txbStudentNum.Text;
            _student.Major = txbMajor.Text;

            List<Assignment> scores = new List<Assignment>();
            foreach (Assignment score in lbScores.Items)
            {
                scores.Add(score);    
            }
            _student.Scores = scores;

            //Set the results from the class into a control on the form
            txbResults.Text = _student.ToString();

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}