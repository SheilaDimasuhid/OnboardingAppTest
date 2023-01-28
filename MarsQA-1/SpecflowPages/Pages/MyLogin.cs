using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQA_1.SpecflowPages.Pages
{
    public class MyLogin
    {
        public void loginSteps()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://localhost:5000/Home");
            driver.Manage().Window.Maximize();

            Thread.Sleep(1000);
            IWebElement signInButton = driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a"));
            signInButton.Click();

            Thread.Sleep(1000);
            IWebElement emailAddTxtbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
            emailAddTxtbox.SendKeys("dimasuhidsheila@gmail.com");

            IWebElement passwordTxtbox = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));
            passwordTxtbox.SendKeys("MarsAppTest");

            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();

            Thread.Sleep(5000);
            IWebElement hiMessage = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span"));

            Assert.That(hiMessage.Text == "Hi Sheila", "Login Failed");
            //if (hiMessage.Text == "Hi Sheila")
            //{
            //    Console.Write("Log-In Successful");
            //}
            //else
            //{
            //    Console.Write("Log-In Unsuccessful. Please Try Again");
            //}

            //driver.Quit();
        }
    }
}
