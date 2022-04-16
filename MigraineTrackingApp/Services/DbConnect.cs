/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
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
    class DbConnect
    {
        //private static FirebaseClient firebase = new FirebaseClient("https://migrainetrackapp-default-rtdb.europe-west1.firebasedatabase.app/");
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
        /// Create member
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="dob"></param>
        /// <param name="gender"></param>
        /// <param name="userid"></param>
        /// <returns></returns>
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
        /// <param name="uid"></param>
        /// <param name="migraineT"></param>
        /// <returns></returns>
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
            await firebase
                .Child("allergyList").Child(userid)
                .PutAsync(new Allergen()
                {
                    allergenList = migranetypes
                });
            return true;
        }
        /// <summary>
        /// This method returns a list of allergens
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
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
        /*public async Task<string> GetPicFromStorage(bool isMocked, string picName)
        {
            try
            {
                var pic = await firebaseStorage.Child("pics").Child(picName).GetDownloadUrlAsync();

                return "";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }*/
        public async Task<bool> savePicToStorage(Stream fileStream,string filename)
        {
            try
            {
                await firebaseStorage.Child("pics").Child(filename).PutAsync(fileStream);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }
        }
    }
}
