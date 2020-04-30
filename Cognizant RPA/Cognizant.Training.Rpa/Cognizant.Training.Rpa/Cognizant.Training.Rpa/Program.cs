using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;

namespace Cognizant.Training.Rpa
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Opções do Chrome
            var chromeOptions = new ChromeOptions()
            {
                AcceptInsecureCertificates = true
                
            };

            //Inicia o chrome com uma janela maximiada
            chromeOptions.AddArgument("start-maximized");

            //Inicializa o driver do chrome
            var driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions, TimeSpan.FromSeconds(10));

            //Navega para a URL indicada
            driver.Url = "https://www.google.com.br";

            //Tira um print e armazena como base64
            var imagem = driver.GetScreenshot().AsBase64EncodedString;

            //Encontra o campo de pesquisa
            var campoDePesquisa = driver.FindElement(By.Name("q"));

            //Digita o termo de busca
            campoDePesquisa.SendKeys("Cognizant Brasil");

            //Aguarda 2 segundos para clicar no elemento
            Thread.Sleep(2000);

            //Encontra o botão de pesquisa
            var botaoDePesquisa = driver.FindElement(By.Name("btnK"));

            //Clica no botão de pesquisar
            botaoDePesquisa.Click();

            ReadOnlyCollection<IWebElement> resultados;

            //Loop para pegar os primeiros 5 resultados
            for (int i = 0; i < 5; i++)
            {
                //Coleta os resultados
                resultados = driver.FindElements(By.ClassName("rc"));

                //Se não tiver resultados sai do loop
                if (!resultados.Any())
                    break;

                //Clica no resultado
                resultados[i].FindElement(By.TagName("a")).Click();

                //Aguarda 5 segundos para a página carregar
                Thread.Sleep(5000);

                //Tira o print da página
                var imagemResultado = driver.GetScreenshot().AsByteArray;

                //Salva o print em uma imagem
                File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\resultado{i}.jpg", imagemResultado);

                //Volta para a página anterior
                driver.Navigate().Back();

                //Cria o objeto que aguarda a condição
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                //Espera a condição
                wait.Until(ExpectedConditions.ElementExists(By.ClassName("rc")));

                ////Aguarda 5 segundos para a página carregar
                //Thread.Sleep(5000);
            }

            //Encerra o chrome
            driver.Close();
        }
    }
}