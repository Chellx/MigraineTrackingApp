using MigraineTrackingApp.Models;
using MigraineTrackingApp.Services;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// <summary>
        /// Get member
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<Member> getMember(string userId)
        {
            var result = await databaseConnection.GetMember(userId);
            return result;
           
        }
        /// <summary>
        /// Send data to create a member
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dob"></param>
        /// <param name="gender"></param>
        /// <param name="userid"></param>
        public async void createProfile(string firstName,string lastName,string dob,string gender,string userid,string pic)
        {
            await databaseConnection.createProfile(firstName, lastName, dob, gender, userid,pic);
        }
        public async void uploadPhoto(Stream fileStream,string filename)
        {
            await databaseConnection.savePicToStorage(fileStream,filename);
        }
    }
}
