using MigraineTrackingApp.Models;
using MigraineTrackingApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MigraineTrackingApp.ViewModels
{
    class MemberViewModel
    {
        DbConnect databaseConnection;

        public MemberViewModel()
        {
            databaseConnection = new DbConnect(); //connection to DB
        }

        public async Task <List<Member>> getListOfMembers()
        {
            var result =  await databaseConnection.GetAllMembers();
            return result;
           
        }
    }
}
