using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ITokenRepository
    {
        Token GenerateToken(int userId, string userType);
        Token GetToken(string tokenValue);
        void InvalidateToken(string tokenValue);
    }
}
