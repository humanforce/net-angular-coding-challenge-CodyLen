using System;
using System.Collections.Generic;
using System.IO;
using HumanForce.Domain.Model.User;
using HumanForce.Domain.Services;
using Newtonsoft.Json;

namespace HumanForce.Services
{
    public class UserService : IUserService
    {

        public IEnumerable<User> GetUsers()
        {
            var teamMemberJson = @"Resources/TeamMembers.json";
            var jsonResult = File.ReadAllText(teamMemberJson);
            return JsonConvert.DeserializeObject<IEnumerable<User>>(jsonResult);
        }
    }
}
