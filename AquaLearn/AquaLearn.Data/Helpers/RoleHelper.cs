using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AquaLearn.Domain.Models;

namespace AquaLearn.Data.Helpers
{
    public class RoleHelper
    {
        public AquaLearnDbContext _db { get; set; }
        public AquaLearnIMDbContext _idb { get; set; }

        public RoleHelper()
        {
            _db = new AquaLearnDbContext();
        }

        public RoleHelper(AquaLearnIMDbContext idb)
        {
            _idb = idb;
        }

        public long SetRole(Role role)
        {
            if (_db != null)
            {
                _db.Role.Add(role);
                return _db.SaveChanges();
            }
            else
            {
                _idb.Role.Add(role);
                return _idb.SaveChanges();
            }
            
        }



        public List<Role> GetRoles()
        {
            if (_db != null)
            {
                var z = _db.Role.ToList();
                return z;

            }
            else
            {
                var y = _idb.Role.ToList();
                return y;
            }

        }
    }
}