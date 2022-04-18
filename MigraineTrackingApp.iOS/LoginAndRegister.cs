/*
 * Student Name: Michelle Bolger
 * Student Number: C00242743
 * Date: 18/4/2022
 */

using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Firebase.Auth;
using MigraineTrackingApp.iOS;

[assembly: Dependency(typeof(LoginAndRegister))]

namespace MigraineTrackingApp.iOS
{
    class LoginAndRegister : IAuth
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return await user.User.GetIdTokenAsync();
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public Task<string> SignupWithEmailPassword(string email, string password)
        {
            throw new NotImplementedException();
        }
        public void Logout()
        {
            Foundation.NSError error;
            Auth.DefaultInstance.SignOut(out error);
        }
    }
}