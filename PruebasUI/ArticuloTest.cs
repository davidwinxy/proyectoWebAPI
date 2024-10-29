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
        
        private IWebDriver driver;
        private WebDriverWait _wait;

        public ArticuloTest()
        {
            driver = new ChromeDriver();
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Fact]
        public void TestArticuloNavigation()
        {
            driver.Navigate().GoToUrl("https://localhost:7088/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000); 

            _wait.Until(dvr => dvr.FindElement(By.Id("btn-articulo"))).Click();
            Thread.Sleep(2000); 

            _wait.Until(dvr => dvr.FindElement(By.Id("ArticuloCreate"))).Click();
            Thread.Sleep(2000); 

            var nombreInput = _wait.Until(dvr => dvr.FindElement(By.Id("ArticuloNombre")));
            nombreInput.Clear();
            nombreInput.SendKeys("Nombre del Artículo de Prueba");
            Thread.Sleep(2000);

            var descripcionInput = _wait.Until(dvr => dvr.FindElement(By.Id("ArticuloDescripcion")));
            descripcionInput.Clear();
            descripcionInput.SendKeys("Descripción del Artículo de Prueba");
            Thread.Sleep(2000);

            var categoriaInput = _wait.Until(dvr => dvr.FindElement(By.Id("ArticuloCategoria")));
            categoriaInput.Clear();
            categoriaInput.SendKeys("Categoría de Prueba");
            Thread.Sleep(2000); 

            var disponibilidadCheckbox = _wait.Until(dvr => dvr.FindElement(By.Id("ArticuloDisponibilidad")));
            if (!disponibilidadCheckbox.Selected)
            {
                disponibilidadCheckbox.Click();
            }
            Thread.Sleep(2000); 

            var createButton = _wait.Until(dvr => dvr.FindElement(By.Id("ArticuloCreateButton")));
            createButton.Click();
            Thread.Sleep(2000); 

            _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorDetails"))).Click();
            Thread.Sleep(2000); 

            _wait.Until(dvr => dvr.FindElement(By.Id("ArticuloEditLink"))).Click();
            Thread.Sleep(2000); 

            var editNombreInput = _wait.Until(dvr => dvr.FindElement(By.Id("ArticuloNombre")));
            editNombreInput.Clear();
            editNombreInput.SendKeys("Nombre del Artículo Modificado");
            Thread.Sleep(2000); 

            var editDescripcionInput = _wait.Until(dvr => dvr.FindElement(By.Id("ArticuloDescripcion")));
            editDescripcionInput.Clear();
            editDescripcionInput.SendKeys("Descripción del Artículo Modificado");
            Thread.Sleep(2000);

            var saveButton = _wait.Until(dvr => dvr.FindElement(By.Id("ArticuloSaveButton"))); 
            saveButton.Click();
            Thread.Sleep(2000); 

            _wait.Until(dvr => dvr.FindElement(By.Id("ArticuloDelete"))).Click();
            Thread.Sleep(2000); 

            _wait.Until(dvr => dvr.FindElement(By.Id("btnDelete"))).Click();
            Thread.Sleep(500); 


            _wait.Until(dvr => dvr.FindElement(By.Id("BackToList"))).Click();
            Thread.Sleep(500); 
          
            driver.Quit();
        }
    }
}
