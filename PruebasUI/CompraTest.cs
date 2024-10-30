using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Xunit;

namespace PruebasUI
{
    public class CompraTest
    {
        private IWebDriver driver;
        private WebDriverWait _wait;

        public CompraTest()
        {
            driver = new ChromeDriver();
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Fact]
        public void TestCompraCreation()
        {
            driver.Navigate().GoToUrl("http://localhost:5117/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);

            // Proceso para abrir la opción de compra
            _wait.Until(dvr => dvr.FindElement(By.Id("btn-compra"))).Click();
            Thread.Sleep(2000);

            // Proceso para crear una nueva compra
            _wait.Until(dvr => dvr.FindElement(By.Id("btnCreateCompra"))).Click();
            Thread.Sleep(2000); 

            var numeroFacturaInput = _wait.Until(dvr => dvr.FindElement(By.Id("CompraNumeroFactura")));
            numeroFacturaInput.Clear();
            numeroFacturaInput.SendKeys("12345");
            Thread.Sleep(500);

            var fechaInput = _wait.Until(dvr => dvr.FindElement(By.Id("CompraFecha")));
            fechaInput.Clear();
            fechaInput.SendKeys("2023-10-29");
            Thread.Sleep(500);

            var precioUnitarioInput = _wait.Until(dvr => dvr.FindElement(By.Id("CompraPrecioUnitario")));
            precioUnitarioInput.Clear();
            precioUnitarioInput.SendKeys("50.00");
            Thread.Sleep(500);

            var cantidadInput = _wait.Until(dvr => dvr.FindElement(By.Id("CompraCantidad")));
            cantidadInput.Clear();
            cantidadInput.SendKeys("10");
            Thread.Sleep(500);

            var idProveedorInput = _wait.Until(dvr => dvr.FindElement(By.Id("CompraProveedorId")));
            idProveedorInput.Clear();
            idProveedorInput.SendKeys("1");
            Thread.Sleep(500);

            var createButton = _wait.Until(dvr => dvr.FindElement(By.Id("CompraCreateButton")));
            createButton.Click();
            Thread.Sleep(2000);

            // Proceso para ver detalles de la compra
            _wait.Until(dvr => dvr.FindElement(By.Id("CompraDetails"))).Click();
            Thread.Sleep(2000);

            // Proceso para editar la compra
            _wait.Until(dvr => dvr.FindElement(By.Id("CompraEdit"))).Click();
            Thread.Sleep(2000);

            var editCantidadInput = _wait.Until(dvr => dvr.FindElement(By.Id("CompraCantidad")));
            editCantidadInput.Clear();
            editCantidadInput.SendKeys("15");
            Thread.Sleep(500);

            var saveButton = _wait.Until(dvr => dvr.FindElement(By.Id("CompraSaveButton")));
            saveButton.Click();
            Thread.Sleep(2000);

            // Proceso para eliminar la compra
            _wait.Until(dvr => dvr.FindElement(By.Id("CompraDelete"))).Click();
            Thread.Sleep(2000);

            // Confirmación de eliminación
            _wait.Until(dvr => dvr.FindElement(By.Id("ConfirmDelete"))).Click();
            Thread.Sleep(2000);

            // Cerrar el navegador
            driver.Quit();
        }
    }
}
