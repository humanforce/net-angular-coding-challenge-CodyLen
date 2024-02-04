using System;
using System.Collections.Generic;
using HumanForce.Domain.Model.User;

namespace HumanForce.Domain.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();      
    }
}
