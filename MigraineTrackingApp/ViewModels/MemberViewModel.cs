/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

using MigraineTrackingApp.Models;
using MigraineTrackingApp.Services;
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
        public async void createProfile(string firstName,string dob,string gender,string userid)
        {
            await databaseConnection.createProfile(firstName, dob, gender, userid);
        }
    }
}
