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
        public async Task<bool> createMigraineRecord(string uid,List<string> migranetypes, List<string> painlocation, List<string> medicationtype, List<string> symm, List<string> trig, List<string> food,string loc,string hum,string temp,string sTime,string eTime,string sdate,string edate,string migDuration,string painInten,string todaysDate)
        {
            try
            {
                await firebase
                .Child("RecordMigraine").Child(uid).Child(todaysDate)
                .PutAsync(new SaveMigraine()
                {
                    migraineType = migranetypes,
                    painLocation = painlocation,
                    medicationType = medicationtype,
                    symptoms = symm,
                    triggers = trig,
                    foods = food,
                    startDate = sdate,
                    endDate = edate,
                    startTime = sTime,
                    endTime = eTime,
                    temperature = temp,
                    location = loc,
                    humidity = hum,
                    migraineDuration = migDuration,
                    painIntensity = painInten
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
