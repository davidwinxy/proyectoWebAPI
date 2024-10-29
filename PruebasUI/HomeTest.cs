using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace PruebasUI
{
    public class HomeTest
    {
        // Declaración del driver
        IWebDriver driver;
        // Declaración de la espera
        private WebDriverWait _wait;

        public HomeTest()
        {
            // Se inicializa el driver con Chrome
            driver = new ChromeDriver();
            // Se inicializa la espera con la cantidad de segundos deseados
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Fact]
        public void test()
        {
            // Navegar a la página deseada
            driver.Navigate().GoToUrl("https://localhost:7088/");
            // Maximizar la ventana
            driver.Manage().Window.Maximize();

            // Hacer clic en el botón de artículo
            _wait.Until(dvr => dvr.FindElement(By.Id("btn-articulo"))).Click();
#if DEBUG
            Thread.Sleep(500); // Pausa para ver la operación (opcional)
#endif
            // Regresar a la vista principal
            _wait.Until(dvr => dvr.FindElement(By.Id("LogoIndex"))).Click();
#if DEBUG
            Thread.Sleep(500); // Pausa para ver la operación (opcional)
#endif

            // Hacer clic en el botón de préstamo
            _wait.Until(dvr => dvr.FindElement(By.Id("btn-prestamo"))).Click();
#if DEBUG
            Thread.Sleep(500); // Pausa para ver la operación (opcional)
#endif
            // Regresar a la vista principal
            _wait.Until(dvr => dvr.FindElement(By.Id("LogoIndex"))).Click();
#if DEBUG
            Thread.Sleep(500); // Pausa para ver la operación (opcional)
#endif

            // Hacer clic en el botón de proveedor
            _wait.Until(dvr => dvr.FindElement(By.Id("btn-proveedor"))).Click();
#if DEBUG
            Thread.Sleep(500); // Pausa para ver la operación (opcional)
#endif
            // Regresar a la vista principal
            _wait.Until(dvr => dvr.FindElement(By.Id("LogoIndex"))).Click();
#if DEBUG
            Thread.Sleep(500); // Pausa para ver la operación (opcional)
#endif

            // Hacer clic en el botón de usuarios
            _wait.Until(dvr => dvr.FindElement(By.Id("btn-usuarios"))).Click();
#if DEBUG
            Thread.Sleep(500); // Pausa para ver la operación (opcional)
#endif
            // Regresar a la vista principal
            _wait.Until(dvr => dvr.FindElement(By.Id("LogoIndex"))).Click();
#if DEBUG
            Thread.Sleep(500); // Pausa para ver la operación (opcional)
#endif
            _wait.Until(dvr => dvr.FindElement(By.Id("btn-compra"))).Click();
#if DEBUG
            Thread.Sleep(500); // Pausa para ver la operación (opcional)
#endif
            _wait.Until(dvr => dvr.FindElement(By.Id("LogoIndex"))).Click();
#if DEBUG
            Thread.Sleep(500); // Pausa para ver la operación (opcional)
#endif

            // Cerrar el driver después de que las interacciones hayan terminado
            driver.Quit();
        }
    }
}
