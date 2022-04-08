using MigraineTrackingApp.Models;
using MigraineTrackingApp.Services;
using System;
using System.Collections.Generic;
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
    }
}
