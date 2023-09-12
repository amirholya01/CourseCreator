using CourseCreator.Core.Services.Interfaces;
using CourseCreator.Datalayer.Context;
using CourseCreator.Datalayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCreator.Core.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly CourseCreatorContext _context;
        public PermissionService(CourseCreatorContext context)
        {
            _context = context;
        }

        public void AddRoleToUser(List<int> roleIds, int userId)
        {
            foreach (var roleId in roleIds)
            {
                _context.userRoles.Add(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userId
                });
            }
            _context.SaveChanges();
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
