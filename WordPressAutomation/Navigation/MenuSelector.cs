using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WordPressAutomation
{
    public class MenuSelector
    {
        public static void Select(string topLevelMenuID, string subMenuLinkText)
        {
            Driver.Instance.FindElement(By.Id(topLevelMenuID)).Click();
            Driver.Instance.FindElement(By.LinkText(subMenuLinkText)).Click();
        }
    }
}
