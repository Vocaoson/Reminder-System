using AsteriskConnector;
using DataAccess.Models;
using System;

namespace TestCodeOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Asterisk asterisk = new Asterisk("192.168.100.99", 5038, "son", "123456");
            //asterisk.Login().Wait();
            asterisk.Call("SIP/1002","ActionId=hihi").Wait();
            //ReminderSystemContext test = new ReminderSystemContext();
            //test.User.Add(new User() { UserName = "huhu", Password = "hihi" });
            //test.SaveChanges();
        }
    }
}
