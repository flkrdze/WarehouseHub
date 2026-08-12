using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseHub.Application.Authentication.Register
{
    public enum RegisterUserError
    {
        None,
        InvalidCompanyName,
        InvalidFirstName,
        InvalidLastName,
        InvalidEmail,
        InvalidPassword,
        EmailAlreadyExists
    }
}
