/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 * Date: 19/4/2022
 */

using MigraineTrackingApp.Models;
using MigraineTrackingApp.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigraineTrackingApp.ViewModels
{
    class ShowMigraineRecordsViewModel
    {
        DbConnect db;
        string email;
        public ShowMigraineRecordsViewModel()
        {
            db = new DbConnect();
        }
        /// <summary>
        /// This method returns a list of previous migraine attacks for that user
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public async Task<List<Migraine>> getAllPrevousMigraineRecords(string uid)
        {
            List <Migraine> value = await db.getMigraineRecords(uid);
            return value;
        }
        public string Email
        {
            get => email;
            set => email = value;
        }
       /// <summary>
       /// this method loops through a list of migraines using numeric month value to build a list of months with months name
       /// </summary>
       /// <param name="objList">list of migraine</param>
       /// <param name="months">list of strings</param>
       /// <returns></returns>
        public List<string> getListOfMonths(List<Migraine> objList,List<string> months)
        {
            foreach (Migraine obj in objList)
            {
                string monthNumber = obj.dateEntered.Substring(3, 2); // gets month in numeric value 
                switch (monthNumber)
                {
                    case "01":
                        months.Add("January");
                        break;
                    case "02":
                        months.Add("February");
                        break;
                    case "03":
                        months.Add("March");
                        break;
                    case "04":
                        months.Add("April");
                        break;
                    case "05":
                        months.Add("May");
                        break;
                    case "06":
                        months.Add("June");
                        break;
                    case "07":
                        months.Add("July");
                        break;
                    case "08":
                        months.Add("August");
                        break;
                    case "09":
                        months.Add("September");
                        break;
                    case "10":
                        months.Add("October");
                        break;
                    case "11":
                        months.Add("November");
                        break;
                    case "12":
                        months.Add("December");
                        break;
                }
            }
            List<string> monthList = months.Distinct().ToList();//return no duplicates
            monthList = monthList.OrderBy(s => DateTime.ParseExact(s, "MMMM", new CultureInfo("en-US"))).ToList();//reference: https://stackoverflow.com/questions/8539088/sorting-months-in-a-list
            return monthList;
        }
        /// <summary>
        /// gets the records for the chosen months
        /// </summary>
        /// <param name="objList">list of migraine</param>
        /// <param name="selectedMonth">string</param>
        /// <param name="meds">list of strings</param>
        /// <returns></returns>
        public List<DisplayGraph> getRecordsForThatMonth(List<Migraine> objList,string selectedMonth,ref List<string> meds)
        {
            Dictionary<string, string> months = new Dictionary<string, string>();
            List<DisplayGraph> recordsForThatMonth = new List<DisplayGraph>();
            DisplayGraph graphObj;
            months.Add("January", "01");
            months.Add("February", "02");
            months.Add("March", "03");
            months.Add("April", "04");
            months.Add("May", "05");
            months.Add("June", "06");
            months.Add("July", "07");
            months.Add("August", "08");
            months.Add("September", "09");
            months.Add("October", "10");
            months.Add("November", "11");
            months.Add("December", "12");
            string monthSelected = months[selectedMonth];
            foreach (Migraine obj in objList)
            {
                if(monthSelected.Equals(obj.dateEntered.Substring(3, 2)) && obj.painIntensity != " ")//only look at the selected month entries
                {
                    if(obj.medicationType.Count != 0)//check if the medication list is empty
                    {
                        foreach(string medication in obj.medicationType)//loop through all the mdications 
                        {
                            if (!meds.Contains(medication) && medication != " ")//add medications that are not in the list
                            {
                                meds.Add(medication);
                            }
                        }
                    }
                   
                    graphObj = new DisplayGraph();
                    graphObj.Date = obj.dateEntered; // get the date the migraine was recorded
                    //changing the pain intensity from a string to string number
                    graphObj.PainLevel = (float)Convert.ToDouble( obj.painIntensity.Substring(0, 1));//get pain intensity string number
                    recordsForThatMonth.Add(graphObj);
                }
            }
            return recordsForThatMonth;
        }
    }
}
