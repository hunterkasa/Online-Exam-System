using DAL.Interface;
using DAL.Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.Repo
{
    public class TokenRepository : ITokenRepository
    {
        private readonly DbContext _context;

        public TokenRepository(DbContext context)
        {
            _context = context;
        }

        public Token GenerateToken(int userId, string userType)
        {
            var tokenValue = Guid.NewGuid().ToString(); 
            var expiryDate = DateTime.Now.AddHours(12); 

            var token = new Token
            {
                TokenValue = tokenValue,
                ExpiryDate = expiryDate,
                UserId = userId,
                //UserType = userType
            };

            _context.Set<Token>().Add(token);
            _context.SaveChanges();

            return token; 
        }

        public Token GetToken(string tokenValue)
        {
            return _context.Set<Token>().FirstOrDefault(t => t.TokenValue == tokenValue && t.ExpiryDate > DateTime.Now);
        }

        public void InvalidateToken(string tokenValue)
        {
            var token = _context.Set<Token>().FirstOrDefault(t => t.TokenValue == tokenValue);
            if (token != null)
            {
                _context.Set<Token>().Remove(token);
                _context.SaveChanges();
            }
        }
    }
}
