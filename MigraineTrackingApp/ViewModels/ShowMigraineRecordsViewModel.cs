﻿using MigraineTrackingApp.Models;
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
        public List<string> getListOfMonths(List<Migraine> objList,List<string> months)
        {
            foreach (Migraine obj in objList)
            {
                string monthNumber = obj.dateEntered.Substring(3, 2);
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
            monthList = monthList.OrderBy(s => DateTime.ParseExact(s, "MMMM", new CultureInfo("en-US"))).ToList();//https://stackoverflow.com/questions/8539088/sorting-months-in-a-list
            return monthList;
        }
        public List<DisplayGraph> getRecordsForThatMonth(List<Migraine> objList,string selectedMonth)
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
                if(monthSelected.Equals(obj.dateEntered.Substring(3, 2)))
                {
                    graphObj = new DisplayGraph();
                    //removing the time from the date
                    int firstSpaceIndex = obj.dateEntered.IndexOf(" ");//get first spcae
                    string firstString = obj.dateEntered.Substring(0, firstSpaceIndex); // get date
                    graphObj.Date = firstString;//overwrite date
                    //changing the pain intensity from a string to string number
                    graphObj.PainLevel = (float)Convert.ToDouble( obj.painIntensity.Substring(0, 1));//get string number
                    recordsForThatMonth.Add(graphObj);
                }
            }
            return recordsForThatMonth;
        }
    }
}