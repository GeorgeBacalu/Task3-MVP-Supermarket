using Supermarket.Core.Dtos.Common;
using Supermarket.Core.Dtos.Request;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services.Interfaces
{
    public interface IUserService
    {
        IList<UserDto> GetAll();

        IList<UserDto> GetByKey(string key);

        UserDto GetById(Guid id);

        UserDto Register(RegisterRequest payload);

        UserDto Login(LoginRequest payload);

        UserDto UpdateById(UserDto userDto, Guid id);

        UserDto DeleteById(Guid id);
    }
}