/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

using MigraineTrackingApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MigraineTrackingApp.ViewModels
{
    /// <summary>
    /// This class is used to save data belonging to the record migrane usecase
    /// </summary>
    class RecordMigraneViewModel
    {
        List<string> migraneTypes = new List<string>();
        List<string> painLocation = new List<string>();
        List<string> medicationType = new List<string>();
        List<string> symptoms = new List<string>();
        List<string> triggers = new List<string>();
        List<string> foods = new List<string>();
        List<string> allergens = new List<string>();

        List<string> result = new List<string>();

        string location;
        string humidity;
        string temperature;

        string startTime;
        string endTime;

        string startdate;
        string enddate;
        string migraineDuration;

        string painIntensity;
        DbConnect db;
        public RecordMigraneViewModel()
        {
            db = new DbConnect();
        }
        /// <summary>
        /// This menthod saves the migrane types list
        /// </summary>
        /// <param name="types"></param>
        public void setMigraneTypes(List<string> types)
        {
            migraneTypes.AddRange(types);
        }
        /// <summary>
        /// This method returns the migrane types list
        /// </summary>
        /// <returns></returns>
        public List<string> getMigraneTypes()
        {
            return migraneTypes;
        }
        
        /// ///////////////////////////////////////////////////////////////////////////////////////////////
        
        
       
        /// <summary>
        /// This menthod saves the pain locations list
        /// </summary>
        /// <param name="types"></param>
        public void setPainLocation(List<string> types)
        {
            painLocation.AddRange(types);
        }
        /// <summary>
        /// This method returns the pain location  list
        /// </summary>
        /// <returns></returns>
        public List<string> getPainLocation()
        {
            return painLocation;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////
        ///
        /// <summary>
        /// This menthod saves the pain locations list
        /// </summary>
        /// <param name="types"></param>
        public void setMedicationTypes(List<string> types)
        {
            medicationType.AddRange(types);
        }
        /// <summary>
        /// This method returns the pain location  list
        /// </summary>
        /// <returns></returns>
        public List<string> getMedicationTypes()
        {
            return medicationType;
        }
        /////////////////////////////////////////////////////////////////////////////////
        ///
        /// <summary>
        /// This menthod saves the pain locations list
        /// </summary>
        /// <param name="types"></param>
        public void setSymptoms(List<string> types)
        {
            symptoms.AddRange(types);
        }
        /// <summary>
        /// This method returns the pain location  list
        /// </summary>
        /// <returns></returns>
        public List<string> getSymptoms()
        {
            return symptoms;
        }

        ////////////////////////////////////////////////////////////////////////
        ///
        /// <summary>
        /// This menthod saves the triggers list
        /// </summary>
        /// <param name="types"></param>
        public void setTriggers(List<string> types)
        {
            triggers.AddRange(types);
        }
        /// <summary>
        /// This method returns the pain location  list
        /// </summary>
        /// <returns></returns>
        public List<string> getTriggers()
        {
            return triggers;
        }

        /////////////////////////////////////////////////////////////////////////
        ///
        public string Location
        {
            get => location;
            set => location = value;
        }

        public string Humidity
        {
            get => humidity;
            set => humidity = value;
        }

        public string Temperature
        {
            get => temperature;
            set => temperature = value;
        }

        ///////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        public string StartTimeOfMigraine
        {
            get => startTime;
            set => startTime = value;
        }
        public string EndTimeOfMigraine
        {
            get => endTime;
            set => endTime = value;
        }
        public string LengthOfMigraineAttack
        {
            get => migraineDuration;
            set => migraineDuration = value;
        }
        
        ////////////////////////////////////////////////////////////////////////
        public string StartDate
        {
            get => startdate;
            set => startdate = value;
        }
        public string EndDate
        {
            get => enddate;
            set => enddate = value;
        }
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////
        /// </summary>

        public string PainIntensity
        {
            get => painIntensity;
            set => painIntensity = value;
        }
        ////////////////////////////////////////////////////////////////////////////////
        public void setFoodEaten(List<string> types)
        {
            foods.AddRange(types);
        }
        
        public List<string> getFoodEaten()
        {
            return foods;
        }
        public void resetFoodList()
        {
            foods.Clear();
        }
        /// <summary>
        /// This method sets all allergens for the food products scanned
        /// </summary>
        /// <param name="types"></param>
        public void setAllAllergenypes(string []allergen)
        {
            for(int i = 0;i < allergen.Length; i++)
            {
                if (allergens.Contains(allergen[i]))
                {

                }
                else
                {
                    allergens.Add(allergen[i]);
                }
            }
        }
        /// <summary>
        /// This method returns all allergens for the food products entered
        /// </summary>
        /// <returns></returns>
        public List<string> getAllergenTypes()
        {
            return allergens;
        }
        /// <summary>
        /// This method adds the current scanned allergen info into the user allergen list in the database
        /// </summary>
        /// <param name="uid"></param>
        public async void sendAllergenInfo(string uid)
        {
            bool value = await db.addAllergens(uid, getAllergenTypes());
        }
        /// <summary>
        /// This method returns a list of allergens from the databse for that user 
        /// </summary>
        /// <param name="uid"></param>
        public async Task<List<string>> getAllergenList(string uid)
        {
           result = await db.getAllergenListFromDb(uid);
           return result;
        }
        /// <summary>
        /// This method checks if allergens for a product are already in the database if they are remove them
        /// </summary>
        /// <param name="uid"></param>
        public async void checkIfAllergensAreInDB(string uid)
        {
            result = await getAllergenList(uid);

            if (result != null)
            {
                foreach (var allergen in allergens)
                {
                    if (result.Contains(allergen))
                    {
                        allergens.Remove(allergen);
                    }
                }
            }
        }


        public async Task<string> checkScannedItem(string uid,string[] scannedAllergens)
        {
            string allergensFound = " ";
            result = await getAllergenList(uid);
            foreach (var allergen in scannedAllergens)
            {
                if (result.Contains(allergen))
                {
                    allergensFound += allergen + " "; 
                }
            }
            if(allergensFound == " ")
            {
                return "This Food Item Has Not Caused A Previous Migraine";

            }
            return "This Food Item May Cause A Migraine\n Allergens Found: " + allergensFound + "\n";
        }

        public async void sendRecordDetailsToDataase(string currentDate,string uid)
        {
            setValuesIfNotFilledIn();
            bool value = await db.createMigraineRecord(uid, getMigraneTypes(), getPainLocation(), getMedicationTypes(), getSymptoms(), getTriggers(), getFoodEaten(), Location, Humidity, Temperature, StartTimeOfMigraine, EndTimeOfMigraine, StartDate, EndDate, LengthOfMigraineAttack, PainIntensity, currentDate);
        }

        public void setValuesIfNotFilledIn()
        {
            List<string> ifListEmpty = new List<string>();
            ifListEmpty.Add(" ");
            if (getMigraneTypes().Count == 0)
            {
                setMigraneTypes(ifListEmpty);
            }
            if (getPainLocation().Count == 0)
            {
                setPainLocation(ifListEmpty);
            }
            if (getMedicationTypes().Count == 0)
            {
                setMedicationTypes(ifListEmpty);
            }
            if (getSymptoms().Count == 0)
            {
                setSymptoms(ifListEmpty);
            }
            if (getTriggers().Count == 0)
            {
                setTriggers(ifListEmpty);
            }
            if (getFoodEaten().Count == 0)
            {
                setFoodEaten(ifListEmpty);
            }
            if (Location == null)
            {
                Location = " ";
            }
            if (Humidity == null)
            {
                Humidity = " ";
            }
            if (Temperature == null)
            {
                Temperature = " ";
            }
            if (StartTimeOfMigraine == null)
            {
                StartTimeOfMigraine = " ";
            }
            if (EndTimeOfMigraine == null)
            {
                EndTimeOfMigraine = " ";
            }
            if (StartDate == null)
            {
                StartDate = " ";
            }
            if (EndDate == null)
            {
                EndDate = " ";
            }
            if (PainIntensity == null)
            {
                PainIntensity = " ";
            }
            if (LengthOfMigraineAttack == null)
            {
                LengthOfMigraineAttack = " ";
            }
        }
    }
}
