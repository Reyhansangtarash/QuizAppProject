using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quiz_app_project
{
    public class Users
    {
        
            public int Id { get; set; }
            public string UserName { get; set; }
            public int Password { get; set; }
            public DateTime RegisteredAt { get; set; }

            public Users(int id, string name, int pass)
            {
                Id = id;
                UserName = name;
                Password = pass;
                RegisteredAt = DateTime.Now;
            }

            ~Users()
            {
                MessageBox.Show($"{UserName} عزیز، اطلاعات شما حذف شد.");
            }
        

    }
}
