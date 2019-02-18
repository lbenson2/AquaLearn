using AquaLearn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using adm = AquaLearn.Domain.Models;
using AquaLearn.Data.Helpers;



namespace AquaLearn.Data.Helpers
{
    public static class ClassroomHelper
    {
        private static AquaLearnIMDbContext _db = new AquaLearnIMDbContext();
        public static AquaLearnDbContext _dbn = new AquaLearnDbContext();

        public static List<adm.Classroom> GetClassroom()
        {
            var classr = new List<adm.Classroom>();

            foreach (var csr in _dbn.Classroom.ToList())
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

        public static bool SetClassroom(adm.Classroom classroom)
        {
                var checkclass = GetClassroomByName(classroom.Name);

                if (checkclass != null && checkclass.Name == classroom.Name)
                {
                    return false;
                }
                else
                {        
                    _dbn.Classroom.Add(classroom);
                    return _dbn.SaveChanges() > 0;
                }
            }
        }
}