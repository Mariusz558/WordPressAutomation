using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

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
    }
}
