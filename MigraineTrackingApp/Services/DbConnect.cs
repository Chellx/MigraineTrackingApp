using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using MigraineTrackingApp.Models;

namespace MigraineTrackingApp.Services
{
    class DbConnect
    {
        //private static FirebaseClient firebase = new FirebaseClient("https://migrainetrackapp-default-rtdb.europe-west1.firebasedatabase.app/");
        FirebaseClient firebase;
        private static List<Member> memberList = new List<Member>();
        public DbConnect()
        {
            firebase = new FirebaseClient("https://migrainetrackapp-default-rtdb.europe-west1.firebasedatabase.app/");
        }
        public async Task<List<Member>> GetAllMembers() { 
            try
            {
                memberList = (await firebase
                .Child("members")
                .OnceAsync<Member>()).Select(item => new Member
                {
                    Email = item.Object.Email,
                    FirstName = item.Object.FirstName,
                    LastName = item.Object.LastName,
                    Gender = item.Object.Gender,
                    Dob = item.Object.Dob
                }).ToList();
                
                return memberList;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        /// <summary>
        /// This method saves a record of a users migraine data
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="migraineT"></param>
        /// <returns></returns>
        public async Task<bool> createMigraineRecord(string uid,List<string> migraineT, List<string> painLocation)
        {
            try
            {
                await firebase
                .Child("RecordMigraine").Child(uid)
                .PutAsync(new SaveMigraine()
                {
                    migraineType = migraineT,
                    painLocation=painLocation

                });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
