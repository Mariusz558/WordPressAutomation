using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordPressAutomation
{
    public class DashboardPage
    {
        public static bool IsAt//autoproperty; jest bool, wiec trzeba w metodzie zwrocic wartosc logiczna
        {    
            get //sprawdza czy jestesmy na stronie
            {
                var h1s = Driver.Instance.FindElements(By.TagName("h1"));//aby tego dokonac (zwrocic wart. logiczna) wyszukujemy wszystkie elementy o tagu h1 na stronie
                if (h1s.Count > 0)//jesli mamy ich wiecej niz 0
                    return h1s[0].Text == "Dashboard";//zwroc pierwszy, ktorego text jest Dashboard
                return false;//jesli nie ma h1 zwroc falsz - nie jestesmy na stronie Dashboard
            }
        }
    }
}
