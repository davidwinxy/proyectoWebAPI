using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PruebasUI
{
    public class HomeTest
    {
        //Declaración del driver
        IWebDriver driver;
        //Declaración de la espera
        private WebDriverWait _wait;

        public HomeTest()
        {
            //Se inicializa el driver con chrome
            driver = new ChromeDriver();
            //Se inicializa la espera con la cantidad de segundos deseados
            //En este ejemplo dejamos 10 segundos como espera máxima
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }



        [Fact]
        public void test()
        {
            //Nos redirigimos a la página deseada, en este caso la de Nerdino
            driver.Navigate().GoToUrl("https://localhost:7088/");
            //Maximizamos la ventana
            driver.Manage().Window.Maximize();
            //Buscamos el elemento por su id y una vez que lo encuentra da click
            _wait.Until(dvr => dvr.FindElement(By.Id("btn-articulo"))).Click();
            //Esperamos medio segundo para poder alcanzar a ver que se haya realizado la operación
#if DEBUG
            Thread.Sleep(500);
#endif
            //Repetimos lo anterior con una pestaña diferente
            _wait.Until(dvr => dvr.FindElement(By.Id("LogoIndex"))).Click();
#if DEBUG
            Thread.Sleep(500);
#endif
            //Cerramos el driver
            driver.Quit();
        }
    }
}
