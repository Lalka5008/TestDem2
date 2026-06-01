using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using TestWpfApp.Data;
using TestWpfApp.Model;

namespace TestWpfApp.Service
{
    internal class Auth
    {
        public User TryAuth(string login, string password)
        {
            using (var context = new LeonDataBaseContext())
            {
                User user = context.Users
                    .Include(u => u.Role)
                    .FirstOrDefault(u => u.Login == login && u.Password == password);
                if (user == null) return null;
                return user;
            }   
        }
    }
}
