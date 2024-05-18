﻿using Supermarket.Core.Dtos;
using System;
using System.Collections.Generic;

namespace Supermarket.Core.Services.Interfaces
{
    public interface IUserService
    {
        IList<UserDto> GetAll();

        UserDto GetById(Guid id);

        UserDto Add(UserDto userDto);

        UserDto UpdateById(UserDto userDto, Guid id);

        UserDto DeleteById(Guid id);
    }
}