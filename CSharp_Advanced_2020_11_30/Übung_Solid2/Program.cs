using System;

namespace Übung_Solid2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    #region Bad Sample
    public class Email
    {
        public void SendEmail()
        {
            // code to send mail
        }
    }

    public class Notification
    {
        private Email _email;
        public Notification()
        {
            _email = new Email();
        }

        public void PromotionalNotification()
        {
            _email.SendEmail();
        }
    }
    #endregion
}
