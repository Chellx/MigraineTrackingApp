using System;
using System.Threading.Tasks;
using Android.Gms.Extensions;
using Firebase.Auth;
using MigraineTrackingApp;
using Xamarin.Forms;

[assembly: Dependency(typeof(LoginAndRegister))]
namespace MigraineTrackingApp
{
    public class LoginAndRegister : IAuth
    {
        public async Task<string> LoginWithEmailPassword(string email, string password)
        {
            try
            {
                //Reference: https://www.lindseybroos.be/2020/03/xamarin-forms-and-firebase-authentication/ 

                var user = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = user.User.Uid;
                string userId = token.ToString();
                return userId;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return "";
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                e.PrintStackTrace();
                return "";
            }
        }

        public async Task<string> SignupWithEmailPassword(string email, string password)
        {
            try
            {
                var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email,password);
                var token = user.User.Uid;
                string userId = token.ToString();
                return userId;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return "";
            }
        }
    }
}