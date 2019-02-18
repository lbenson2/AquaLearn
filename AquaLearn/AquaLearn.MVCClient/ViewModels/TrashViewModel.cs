using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ald = AquaLearn.Domain.Models;
using AquaLearn.Data.Helpers;

namespace AquaLearn.MVCClient.ViewModels
{
    public class TrashViewModel
    {
        public List<ald.Trash> GetTrash()
        {
            var helper = new TrashHelper();
            return helper.GettheTrash2();
        }
    }
}
