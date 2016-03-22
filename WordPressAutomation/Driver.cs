using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace WordPressAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }//automatic property - powtorz!
        public static void Initialize()
        { 
            Instance = new FirefoxDriver();//tworzy nowa instancje drivera
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));//opoznienie w czekaniu na otwarcie przegladarki   
        }

        public static void Close()
        {
            Instance.Close();//zamyka przegladarke po zakonczonym tescie
        }

        public static string BaseAdress 
        { 
            get
            {
                return "http://localhost:15662/";
            }
        }

        public static void Wait(TimeSpan timeSpan)
        {
            Thread.Sleep((int)(timeSpan.TotalSeconds * 5000));
        }
    }
}
