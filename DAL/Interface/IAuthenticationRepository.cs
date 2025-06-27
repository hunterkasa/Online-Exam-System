using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IAuthenticationRepository
    {
        Teacher AuthenticateTeacher(string email, string password);
        Student AuthenticateStudent(string email, string password);
    }
}