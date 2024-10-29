using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using Xunit;

namespace PruebasUI
{
    public class ProveedorTest
    {
        private IWebDriver driver;
        private WebDriverWait _wait;

        public ProveedorTest()
        {
            driver = new ChromeDriver();
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Fact]
        public void TestProveedorCreation()
        {
      
            driver.Navigate().GoToUrl("https://localhost:7088/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
 //***********************************************PROCESO PARA ABRIR OPCION****************************************************************************//

            _wait.Until(dvr => dvr.FindElement(By.Id("btn-proveedor"))).Click();
            Thread.Sleep(2000);
 //***********************************************PROCESO PARA ABRIR OPCION****************************************************************************//


 //***********************************************PROCESO PARA CREAR****************************************************************************//
            _wait.Until(dvr => dvr.FindElement(By.Id("btnCreateProveedor"))).Click();
            Thread.Sleep(2000); 

         
            var nombreInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorNombre")));
            nombreInput.Clear();
            nombreInput.SendKeys("Nombre del Proveedor de Prueba");
            Thread.Sleep(500);


            var apellidoInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorApellido")));
            apellidoInput.Clear();
            apellidoInput.SendKeys("Apellido del Proveedor de Prueba");
            Thread.Sleep(500);

            var tipoDePersonaInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorTipoDePersona")));
            tipoDePersonaInput.Clear();
            tipoDePersonaInput.SendKeys("Jurídica");
            Thread.Sleep(500);

            var duiInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorDui")));
            duiInput.Clear();
            duiInput.SendKeys("12345678-9");
            Thread.Sleep(500);

            
            var nombreEmpresaInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorNombreEmpresa")));
            nombreEmpresaInput.Clear();
            nombreEmpresaInput.SendKeys("Empresa de Prueba");
            Thread.Sleep(500);

            
            var nrcInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorNrc")));
            nrcInput.Clear();
            nrcInput.SendKeys("NRC-0001");
            Thread.Sleep(500);

      
            var contactoInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorContacto")));
            contactoInput.Clear();
            contactoInput.SendKeys("Contacto Prueba");
            Thread.Sleep(500);

           
            var telefonoInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorTelefono")));
            telefonoInput.Clear();
            telefonoInput.SendKeys("5555-5555");
            Thread.Sleep(500);

      
            var direccionInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorDireccion")));
            direccionInput.Clear();
            direccionInput.SendKeys("Dirección de Prueba");
            Thread.Sleep(500);

           
            var createButton = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorCreateButton")));
            createButton.Click();
            Thread.Sleep(2000);

 //***********************************************FINAL DE PROCESO PARA CREAR****************************************************************************//




//***********************************************PROCESO PARA DETALLES****************************************************************************//

            _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorDetails"))).Click();
            Thread.Sleep(2000);

            _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorEdit"))).Click();
            Thread.Sleep(2000);
//***********************************************FINAL DE PROCESO PARA DETALLES****************************************************************************//


//***********************************************PROCESO PARA EDITAR****************************************************************************//
            var editNombreInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorNombre")));
            editNombreInput.Clear();
            editNombreInput.SendKeys("Nombre del Proveedor Modificado");
            Thread.Sleep(2000); 

            var editApellidoInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorApellido")));
            editApellidoInput.Clear();
            editApellidoInput.SendKeys("Apellido del Proveedor Modificado");
            Thread.Sleep(2000); 

            var editTipoDePersonaInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorTipoDePersona")));
            editTipoDePersonaInput.Clear();
            editTipoDePersonaInput.SendKeys("Tipo de Persona Modificado");
            Thread.Sleep(2000); 

            var editDuiInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorDui")));
            editDuiInput.Clear();
            editDuiInput.SendKeys("DUI Modificado");
            Thread.Sleep(2000); 


            var editNombreEmpresaInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorNombreEmpresa")));
            editNombreEmpresaInput.Clear();
            editNombreEmpresaInput.SendKeys("Nombre de Empresa Modificado");
            Thread.Sleep(2000);

            
            var editNrcInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorNrc")));
            editNrcInput.Clear();
            editNrcInput.SendKeys("111111");
            Thread.Sleep(2000); 

          
            var editContactoInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorContacto")));
            editContactoInput.Clear();
            editContactoInput.SendKeys("Contacto Modificado");
            Thread.Sleep(2000); 

           
            var editTelefonoInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorTelefono")));
            editTelefonoInput.Clear();
            editTelefonoInput.SendKeys("Teléfono Modificado");
            Thread.Sleep(2000); 

            var editDireccionInput = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorDireccion")));
            editDireccionInput.Clear();
            editDireccionInput.SendKeys("Dirección Modificada");
            Thread.Sleep(2000);

            var saveButton = _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorSaveButton")));
            saveButton.Click();
            Thread.Sleep(2000);
//***********************************************FINAL DE PROCESO PARA EDITAR****************************************************************************//



//***********************************************PROCESO PARA ELIMINAR****************************************************************************//

            _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorDelete"))).Click();
            Thread.Sleep(2000);

            _wait.Until(dvr => dvr.FindElement(By.Id("ProveedorDelete"))).Click();
            Thread.Sleep(100);

            _wait.Until(dvr => dvr.FindElement(By.Id("BackToList"))).Click();
            Thread.Sleep(100);
 //***********************************************FINAL DE PROCESO PARA ELIMINAR****************************************************************************//



            //ESTO ES PARA CERRAR EL NAVEGADOR SI ESTO NO ESTA EL NAVEGADOR NO SE CIERRA
            driver.Quit();
        }
    }
}
