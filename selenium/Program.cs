using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Drawing;
using OpenQA.Selenium.Interactions;

namespace selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            //ChromeOptions options = new ChromeOptions();
            //options.AddArgument("--user-data-dir=C:/Users/Administrator/AppData/Local/Google/Chrome/User Data/Default");



            IWebDriver selenium = new ChromeDriver();

            selenium.Manage().Window.Maximize();
            selenium.Navigate().GoToUrl("https://www.baidu.com");
            System.Threading.Thread.Sleep(1000);

            selenium.FindElement(By.Name("wd")).SendKeys("金属徽章工艺厂家直销");
            System.Threading.Thread.Sleep(1000);
            selenium.FindElement(By.Id("su")).Click();

            int page = 0;

        ck_keyword: System.Threading.Thread.Sleep(2000);
        page++;
        bool isshowpage = false;
            IJavaScriptExecutor js = (IJavaScriptExecutor)selenium;
            Actions action = new Actions(selenium);            

            IList<IWebElement> listOption = selenium.FindElements(By.TagName("h3"));

            string find_title = "金属徽章工艺厂家直销 苍南金属徽章工艺厂家直销价格可定制批发";

            foreach (var item in listOption)
            {
                System.Drawing.Point pt = item.Location;

                if (pt.Y > 600)
                {
                    js.ExecuteScript("window.scrollTo(0, " + (pt.Y - 176) + ");");
                    System.Threading.Thread.Sleep(1000);
                }

                if (find_title.Contains(item.Text.Replace("...", "").Trim()))
                {
                    item.Click();
                    isshowpage = true;
                    break;
                }

                //item.Click();

                //action.MoveByOffset(130,80).Build().Perform();

                //System.Threading.Thread.Sleep(1000);
                //action.Click();

            }

            if (!isshowpage && page<3)
            {
                selenium.FindElement(By.Id("page")).FindElements(By.ClassName("n"))[0].Click();
                goto ck_keyword;
            }

            //selenium.Close();
            //selenium.Quit();

            Console.ReadLine();
            
        }
    }
}
