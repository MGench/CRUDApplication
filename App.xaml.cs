using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace CRUDApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // this method executes everytime the application is started
        protected override void OnStartup(StartupEventArgs e)
        {
            //creates databasefile if non existent
            //Adds the tables specified in DataSession class
            DatabaseFacade facade = new DatabaseFacade(new DataSession()); 
            facade.EnsureCreated(); // ensures database file is created
        }

    }
}
