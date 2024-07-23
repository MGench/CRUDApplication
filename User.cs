using System.ComponentModel.DataAnnotations;

namespace CRUDApplication
{
    public class User
    {
        //defining fields of the datatable
        [Key] // the primary key is Id
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

    }
}