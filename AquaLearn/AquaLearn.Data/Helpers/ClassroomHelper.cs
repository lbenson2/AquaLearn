using AquaLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using adm = AquaLearn.Domain.Models;


namespace AquaLearn.Data.Helpers
{
    public class ClassroomHelper
    {
        private static AquaLearnIMDbContext _db = new AquaLearnIMDbContext();
        private static AquaLearnDbContext _dbn = new AquaLearnDbContext();

        public static List<adm.Classroom> GetClassroom()
        {
            var classr = new List<adm.Classroom>();

            foreach (var csr in _db.Classroom.ToList())
            {
                classr.Add(new adm.Classroom()
                {
                    ClassroomId = csr.ClassroomId,
                    Name = csr.Name

                });
            }
            return classr;
        }

        public static adm.Classroom GetClassroomByName(string clname)
        {
            return _dbn.Classroom.FirstOrDefault(m => m.Name == clname);
        }

        public static bool SetClassroom(adm.Classroom classn)
        {
            var checkclass = GetClassroomByName(classn.Name);

            if (checkclass != null && checkclass.Name == classn.Name)
            {
                return false;
            }
            else
            {        
                _dbn.Classroom.Add(classn);
                return _db.SaveChanges() > 0;
            }
        }
    }
}