using System;
using System.Collections.Generic;
using System.Text;

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
        public RecordMigraneViewModel()
        {

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
    }
}
