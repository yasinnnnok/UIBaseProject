﻿using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IResult Register(AuthDto authDto);
        bool Login(LoginAuthDto loginAuthDto);

    }
}
