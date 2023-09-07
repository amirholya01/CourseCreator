﻿using CourseCreator.Core.Services.Interfaces;
using CourseCreator.Datalayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Core.Services
{
    public class UserService : IUserService
    {

        private readonly CourseCreatorContext _context;
        public UserService(CourseCreatorContext context)
        {
            _context = context;
        }


        public bool IsEmailExist(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsUsernameExist(string username)
        {
            return _context.Users.Any(u => u.Username == username);
        }
    }
}
