using System;
using System.Collections.Generic;
using System.Linq;
using CRMALL.Teste.Domain.Exceptions;
using CRMALL.Teste.Domain.Models.User;
using CRMALL.Teste.Domain.ViewModels.Login;
using Microsoft.AspNetCore.Http;

namespace CRMALL.Api.Security
{
    public static class UserManagement
    {
        private static IList<UserInfo> _users;

        public static UserInfo GetUser(Guid token)
        {
            _users = _users ?? new List<UserInfo>();

            var user = _users.FirstOrDefault(f => f.Token.Equals(token));
            if (user == null || user.LastConnection < DateTime.Now.AddMinutes(-20))
                throw new SessionException("Your session has been terminated");

            user.LastConnection = DateTime.Now;
            return user;
        }

        public static LoginResponseModel RegisterUser(UserModel user)
        {
            var token = Register(user.Id, ProfileEnum.User);
            return new LoginResponseModel { Login = user.Login, Token = token };
        }

        public static LoginResponseModel RegisterUser()
        {
            var token = Register(0, ProfileEnum.Anonymous);
            return new LoginResponseModel { Login = "Anonymous", Token = token };
        }

        public static int Validate(HttpRequest request)
        {
            var header = request.Headers.FirstOrDefault(f => f.Key.ToLower().Equals("authorization"));

            if (!header.Value.ToList().Any())
                throw new TokenException("Authorization is missing");

            var tokenRequest = header.Value.ToArray()[0].Replace("Bearer ", string.Empty);
            var token = Guid.Empty;
            if (string.IsNullOrEmpty(tokenRequest) || !Guid.TryParse(tokenRequest, out token) || token == Guid.Empty)
                throw new TokenException("Authorization invalid");

            return GetUser(token).Id;
        }

        private static Guid Register(int id, ProfileEnum profile)
        {
            _users = _users ?? new List<UserInfo>();

            if (!_users.Any(a => a.Id.Equals(id)))
            {
                _users.Add(new UserInfo(id, Guid.NewGuid(), profile));
            }

            var response = _users.FirstOrDefault(f => f.Id.Equals(id));
            response.LastConnection = DateTime.Now;

            return response.Token;
        }
    }
}
