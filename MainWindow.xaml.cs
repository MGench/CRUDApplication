using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRUDApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<User> DatabaseUsers { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        // Implementing the create method
        public void Create()
        {

            using (DataSession session = new DataSession()) 
            { 
                var name = NameTextBox.Text;
                var address = AddressTextBox.Text;

                //check if Name text box and Address text box is not empty
                if (name != null && address != null)
                {
                    //accesses users table
                    // adds user to table
                    // saves changes to table
                    session.Users.Add(new User() { Name = name, Address = address });
                    session.SaveChanges();
                }
            }
        }

        public void Read() 
        {
            using (DataSession session = new DataSession())
            {
                DatabaseUsers = session.Users.ToList();
                ItemList.ItemsSource = DatabaseUsers; // binds list of users to the list view on UI
            }
        }

        public void Update()
        {
            using (DataSession session = new DataSession())
            {
                User selectedUser = (User)ItemList.SelectedItem; // Selects the user by getting it's ID

                var name = NameTextBox.Text;
                var address = AddressTextBox.Text;

                //check if Name text box and Address text box is not empty
                if (name != null && address != null)
                {
                    User user = session.Users.Find(selectedUser.Id); // finds the specified user defined by it's ID
                    user.Name = name; // updates name of user
                    user.Address = address; // updates address of user

                    session.SaveChanges(); // save changes

                }
            }
        }

        public void Delete()
        {
            using (DataSession session = new DataSession())
            {
                User selectedUser = (User)ItemList.SelectedItem; // Selects the user by getting it's ID

                if (selectedUser != null)
                {
                    User user = session.Users.Single(x=> x.Id == selectedUser.Id); // returns the only element where the id of user matches the selected users id

                    session.Remove(user); // removes user
                    session.SaveChanges(); 
                }

            }
        }

        // creates list
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Create();
        }

        // reads list

        private void ReadButton_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        // updates list
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        // deletes list
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delete();
        }

        // clears list
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            ItemList.Items.Clear();

        }

    }
}
