using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Xunit;

namespace PruebasUI
{
    public class ArticuloTest
    {
        // Declaración del driver
        private IWebDriver driver;
        // Declaración de la espera
        private WebDriverWait _wait;

        public ArticuloTest()
        {
            // Se inicializa el driver con Chrome
            driver = new ChromeDriver();
            // Se inicializa la espera con la cantidad de segundos deseados
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Fact]
        public void TestArticuloNavigation()
        {
            // Navegar a la página deseada
            driver.Navigate().GoToUrl("https://localhost:7088/");
            // Maximizar la ventana
            driver.Manage().Window.Maximize();

            // Hacer clic en el botón de artículo
            _wait.Until(dvr => dvr.FindElement(By.Id("btn-articulo"))).Click();
            Thread.Sleep(500); // Pausa para ver la operación (opcional)

            // Hacer clic en el detalle del artículo
            _wait.Until(dvr => dvr.FindElement(By.Id("Articulodetails"))).Click();
            Thread.Sleep(500); // Pausa para ver la operación (opcional)

            // Aquí puedes agregar más interacciones o verificaciones según lo necesites
        }

        // Este método se llamará después de que se complete la prueba
        public void Dispose()
        {
            // Cerrar el driver después de que las interacciones hayan terminado
            driver.Quit();
        }
    }
}
