/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 18/4/2022
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using MigraineTrackingApp.Models;

namespace MigraineTrackingApp.Services
{
    /// <summary>
    /// these methods connect the application to the firebase database
    /// </summary>
    class DbConnect
    {
        
        FirebaseClient firebase;
        private FirebaseStorage firebaseStorage = new FirebaseStorage("migrainetrackapp.appspot.com");
        private static Member member = new Member();
        private List<Migraine> migraines = new List<Migraine>();
        public DbConnect()
        {
            firebase = new FirebaseClient("https://migrainetrackapp-default-rtdb.europe-west1.firebasedatabase.app/");
        }
        public async Task<Member> GetMember(string userId)
        { 
            try
            {
                return await firebase.Child("member").Child(userId).OnceSingleAsync<Member>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        /// <summary>
        /// Create member profile add into database
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dob"></param>
        /// <param name="gender"></param>
        /// <param name="userid"></param>
        /// <returns>user profile info</returns>
        public async Task<bool> createProfile(string firstName,string dob,string gender,string userid)
        {
            await firebase
                .Child("member").Child(userid)
                .PutAsync(new Member()
                {
                    FirstName = firstName,
                    Dob = dob,
                    Gender = gender,
                });
            return true;
        }
        /// <summary>
        /// This method saves a record of a users migraine data
        /// </summary>
        /// <param name="uid">user ID</param>
        /// <param name="migranetypes"></param>
        /// <param name="painlocation"></param>
        /// <param name="medicationtype"></param>
        /// <param name="symm">symptoms</param>
        /// <param name="trig">triggers</param>
        /// <param name="food">food eaten</param>
        /// <param name="loc">location of migraine</param>
        /// <param name="hum">humidity</param>
        /// <param name="temp">temperture</param>
        /// <param name="sTime">start time</param>
        /// <param name="eTime">end time</param>
        /// <param name="sdate">start date</param>
        /// <param name="edate">end date</param>
        /// <param name="migDuration"></param>
        /// <param name="painInten">pain intensity</param>
        /// <param name="todaysDate"></param>
        /// <returns>bool depending if migraine record succefully created</returns>
        public async Task<bool> createMigraineRecord(string uid,List<string> migranetypes, List<string> painlocation, List<string> medicationtype, List<string> symm, List<string> trig, List<string> food,string loc,string hum,string temp,string sTime,string eTime,string sdate,string edate,string migDuration,string painInten,string todaysDate)
        {
            try
            {
                await firebase
                .Child("RecordMigraine").Child(uid).Child(todaysDate)
                .PutAsync(new Migraine()
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
                    painIntensity = painInten,
                    dateEntered = todaysDate
                });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        /// <summary>
        /// gets migraine records from database related to user
        /// </summary>
        /// <param name="uid"> User ID</param>
        /// <returns>list of migraine records</returns>
        public async Task<List<Migraine>> getMigraineRecords(string uid)
        {
            try
            {
                   migraines = (await firebase
                  .Child("RecordMigraine").Child(uid)
                  .OnceAsync<Migraine>()).Select(item => new Migraine
                  {
                           endDate = item.Object.endDate,
                           startDate = item.Object.startDate,
                           foods = item.Object.foods,
                           humidity = item.Object.humidity,
                           migraineDuration = item.Object.migraineDuration,
                           location = item.Object.location,
                           medicationType = item.Object.medicationType,
                           migraineType = item.Object.migraineType,
                           painIntensity = item.Object.painIntensity,
                           symptoms = item.Object.symptoms,
                           triggers = item.Object.triggers,
                           endTime = item.Object.endTime,
                           painLocation = item.Object.painLocation,
                           startTime = item.Object.startTime,
                           temperature = item.Object.temperature,
                           dateEntered = item.Object.dateEntered

                  }).ToList();
                return migraines;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        /// <summary>
        /// This method adds allergens to a list of allergens in the data base
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="migranetypes"></param>
        /// <returns></returns>
        public async Task<bool> addAllergens(string userid,List<string> migranetypes)
        {
            try
            {
                await firebase
                .Child("allergyList").Child(userid)
                .PutAsync(new Allergen()
                {
                    allergenList = migranetypes
                });
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }
        /// <summary>
        /// This method returns a list of allergens
        /// </summary>
        /// <param name="userid">user ID</param>
        /// <returns>list of strings</returns>
        public async Task<List<string>> getAllergenListFromDb(string userid)
        {
            try
            {
               var allergens = (await firebase
                   .Child("allergyList").Child(userid).OnceSingleAsync<Allergen>());
                if(allergens != null)
                {
                    return allergens.allergenList;
                }
                else{
                    return null;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return new List<string>();
            }
        }
   
    
    }
}
