using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthenticationService
    {
        public TokenDTO AuthenticateUser(string email, string password)
        {
            var authRepo = DataAccessFactory.GetAuthenticationRepository();
            var tokenRepo = DataAccessFactory.GetTokenRepository();
            var teacher = authRepo.AuthenticateTeacher(email, password);
            if (teacher != null)
            {
                var token = tokenRepo.GenerateToken(teacher.TeacherId, "Teacher");
                return MappingToken(token);
            }
            var student = authRepo.AuthenticateStudent(email, password);
            if (student != null)
            {
                var token = tokenRepo.GenerateToken(student.StudentId, "Student");
                return MappingToken(token);
            }
            return null;
        }

        public bool ValidateToken(string tokenValue)
        {
            var tokenRepo = DataAccessFactory.GetTokenRepository();
            var token = tokenRepo.GetToken(tokenValue);
            return token != null;
        }

        private TokenDTO MappingToken(DAL.Model.Token token)
        {
            return new TokenDTO
            {
                TokenId = token.TokenId,
                TokenValue = token.TokenValue,
                ExpiryDate = token.ExpiryDate,
                UserId = token.UserId,
                //UserType = token.UserType
            };
        }
    }
}
