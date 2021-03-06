﻿using System;
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
            //Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));//opoznienie w czekaniu na otwarcie przegladarki; ten fragment nie potrzebny po wprowadzeniu metody NoWait();   
            TurnOnWait();
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

        public static void NoWait(Action action)// metoda wylaczajaca waita na czas wykonywania akcji
        {
            TurnOffWait();
            action();
            TurnOnWait();
        }

        private static void TurnOnWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));//wlaczenie waita
        }

        private static void TurnOffWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));//wylaczenie waita
        }
    }
}
