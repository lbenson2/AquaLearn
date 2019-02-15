using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AquaLearn.Domain.Models;


namespace AquaLearn.Data.Helpers
{
    public class UserHelper
    {
        public AquaLearnDbContext _db { get; set; }
        public AquaLearnIMDbContext _idb { get; set; }

        public UserHelper()
        {
            _db = new AquaLearnDbContext();
        }

        public UserHelper(AquaLearnIMDbContext idb)
        {
            _idb = idb;
        }



        public List<User> GetUsers()
        {
            if (_db != null)
            {
                var z = _db.User.ToList();
                return z;

            }
            else
            {
                var y = _idb.User.ToList();
                return y;
            }

        }
    }
}

