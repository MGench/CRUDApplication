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
        
        }

        public void Update() 
        { 
        
        }

        public void Delete() {
        
        }
    }
}
