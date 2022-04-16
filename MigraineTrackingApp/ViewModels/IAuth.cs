/*
 * Student Name: Michelle Bolger
 * Student Number C00242743
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MigraineTrackingApp
{ //Reference: https://www.lindseybroos.be/2020/03/xamarin-forms-and-firebase-authentication/ 
    public interface IAuth
    {
        Task<string> LoginWithEmailPassword(string email, string password);

        Task<string> SignupWithEmailPassword(string email, string password);
    }
}
