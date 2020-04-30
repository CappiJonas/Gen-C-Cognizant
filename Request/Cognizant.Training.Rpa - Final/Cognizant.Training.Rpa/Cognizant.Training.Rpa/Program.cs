using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace Cognizant.Training.Rpa
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Inicia o Chrome e retorna o ChromeDriver
            var driver = GetDriver();

            //Se fizer o login continua
            if (LoginAdp(driver))
            {
                Thread.Sleep(2000);

                //Se acessar o painel continua
                if (AcessarPainel(driver))
                {
                    Thread.Sleep(2000);

                    //Se acessar o demonstrativo continua
                    if (AcessarDemonstrativo(driver))
                    {
                        //Faz o download dos holerites
                        var holerites = DownloadHolerites(driver);

                        //Envia o email com os prints
                        EnviarEmail("Seguem anexados os holerites.", holerites);
                    }
                    else
                    {
                        EnviarEmail("Erro ao coletar holerite - Não foi possível acessar o demonstrativo");
                    }
                }
                else
                {
                    EnviarEmail("Erro ao coletar holerite - Não foi possível acessar o painel");
                }
            }
            else
            {
                EnviarEmail("Erro ao coletar holerite - Não foi possível fazer o login");
            }

            //Encerra o chrome
            driver.Close();
        }

        private static List<string> DownloadHolerites(ChromeDriver driver)
        {
            //Identifica os elementos da tabela do holerite
            var listaElementos = driver.FindElements(By.ClassName("listaval")).ToList();

            //LINQ - Dentro da lista seleciona os elementos que atendem à condição do LAMBDA
            //LAMBDA - Para cada elemento "x" dentro da lista retorna o elemento se cumprir as condições
            var linksDoHolerite = listaElementos.Where(x => x.GetAttribute("onclick") != null
                                                          && x.GetAttribute("onclick").Contains("sendEvent")).ToList();

            //Variavel para armazenar os anexos
            var holerites = new List<string>();

            //Para cada holerite disponivel tira o print e armazena
            for (int i = 0; i < linksDoHolerite.Count; i++)
            {
                //Volta para o frame inicial
                driver.SwitchTo().DefaultContent();

                //Faz a troca para o Frame do login
                driver.SwitchTo().Frame("ADP");

                //Faz a troca para o Frame do painel
                driver.SwitchTo().Frame("BMPROG");

                listaElementos = driver.FindElements(By.ClassName("listaval")).ToList();

                linksDoHolerite = listaElementos.Where(x => x.GetAttribute("onclick") != null
                                                          && x.GetAttribute("onclick").Contains("sendEvent")).ToList();

                //Clica no link do holerite
                linksDoHolerite[i].FindElement(By.TagName("a")).Click();

                //Tira o print da página
                var imagemResultado = driver.GetScreenshot().AsByteArray;

                //Salva o print em uma imagem
                File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Holerite{i}.jpg", imagemResultado);

                holerites.Add(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + $"\\Holerite{i}.jpg");

                //Volta para o frame inicial
                driver.SwitchTo().DefaultContent();

                //Faz a troca para o Frame do login
                driver.SwitchTo().Frame("ADP");

                driver.SwitchTo().Frame("BMBUTTONS");

                driver.FindElement(By.Id("BACK_MENU")).Click();

                AcessarDemonstrativo(driver);
            }

            return holerites;
        }

        public static ChromeDriver GetDriver()
        {
            //Opções do Chrome
            var chromeOptions = new ChromeOptions()
            {
                AcceptInsecureCertificates = true
            };

            //Inicia o chrome com uma janela maximizada
            chromeOptions.AddArguments("start-maximized");

            //Inicializa o driver do chrome
            return new ChromeDriver(Environment.CurrentDirectory, chromeOptions, TimeSpan.FromSeconds(10));
        }

        public static bool LoginAdp(ChromeDriver driver)
        {
            try
            {
                //Navega para a URL indicada
                driver.Url = "https://www.adpweb.com.br/rhweb28/";

                //Tira um print e armazena como base64
                var imagem = driver.GetScreenshot().AsBase64EncodedString;

                //Faz a troca para o Frame do login
                driver.SwitchTo().Frame("ADP");

                //Encontra o campo de usuario
                var campoUsuario = driver.FindElement(By.Name("vt_user"));

                //Digita o termo de busca
                campoUsuario.SendKeys("CVeríssimo_2");

                //Encontra o campo de senha
                var campoSenha = driver.FindElement(By.Name("vt_pass"));

                //Digita o termo de busca
                campoSenha.SendKeys("********");

                //Coleta o botao de login
                var botaoLogin = driver.FindElement(By.XPath("/html/body/form/div[5]/center/table/tbody/tr/td[2]/div/table/tbody/tr[2]/td/table/tbody/tr[2]/td/div/table/tbody/tr[4]/td[2]/a"));

                //Faz o login
                botaoLogin.Click();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AcessarPainel(ChromeDriver driver)
        {
            try
            {
                //Coleta o elemento do link
                var meuPainel = driver.FindElement(By.Id("Meu Painel_navItem_label"));

                //Acessa o meu painel
                meuPainel.Click();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool AcessarDemonstrativo(ChromeDriver driver)
        {
            try
            {
                //Volta para o frame inicial
                driver.SwitchTo().DefaultContent();

                //Faz a troca para o Frame do login
                driver.SwitchTo().Frame("ADP");

                Thread.Sleep(2000);

                //Coleta o elemento do link
                var demonstrativo = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div[1]/div/div/div/div/div[2]/div[1]/div/div/span[2]/a"));

                //Acessa a pagina do demonstrativo
                demonstrativo.Click();

                //Faz a troca para o Frame do painel
                driver.SwitchTo().Frame("BMPROG");

                //Coleta os elementos de combo
                var ano = driver.FindElement(By.Name("vt_ano"));
                var mes = driver.FindElement(By.Name("vt_mes"));

                //Cria um selectElement com base no ano
                var selectElementAno = new SelectElement(ano);

                //Seleciona o ano
                selectElementAno.SelectByValue(DateTime.Now.AddMonths(-1).ToString("yyyy"));

                //Cria um selectElement com base no mes
                var selectElementMes = new SelectElement(mes);

                //Seleciona o mes
                selectElementMes.SelectByValue(DateTime.Now.AddMonths(-1).ToString("MM"));

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool EnviarEmail(string body, List<string> anexos)
        {
            //Cria uma nova mensagem
            var mensagem = new MailMessage("carlos.ale@outlook.com", "carlos.ale@outlook.com");

            //Inicia o client de SMTP do GMAIL
            var email = new SmtpClient("smtp-mail.outlook.com", 587);

            //Tenta executar o que está dentro do try
            try
            {
                //Informa as credenciais utilizadas no seu email
                email.Credentials = new NetworkCredential("carlos.ale@outlook.com", "ekuenhgvhenoirtp");

                //Habilita a segurança de rede
                email.EnableSsl = true;

                //Assunto da mensagem
                mensagem.Subject = "Holerite";

                //Corpo da mensagem
                mensagem.Body = body;

                //Adiciona cada print que foi tirado
                for (int i = 0; i < anexos.Count; i++)
                {
                    mensagem.Attachments.Add(new Attachment(anexos[i]));
                }

                //Envia o email
                email.Send(mensagem);

                return true;
            }
            //Se der Exception(Erro) executa Catch
            catch
            {
                return false;
            }
            //Depois de concluir executa o que está no finally
            finally
            {
                //Limpa a variável para não consumir recursos
                mensagem.Dispose();

                //Limpa a variável para não consumir recursos
                email.Dispose();
            }
        }

        public static bool EnviarEmail(string body)
        {
            //Cria uma nova mensagem
            var mensagem = new MailMessage("carlos.ale@outlook.com", "carlos.ale@outlook.com");

            //Inicia o client de SMTP do GMAIL
            var email = new SmtpClient("smtp-mail.outlook.com", 587);

            //Tenta executar o que está dentro do try
            try
            {
                //Informa as credenciais utilizadas no seu email
                email.Credentials = new NetworkCredential("carlos.ale@outlook.com", "ekuenhgvhenoirtp");

                //Habilita a segurança de rede
                email.EnableSsl = true;

                //Assunto da mensagem
                mensagem.Subject = "Holerite";

                //Corpo da mensagem
                mensagem.Body = body;

                //Envia o email
                email.Send(mensagem);

                return true;
            }
            //Se der Exception(Erro) executa Catch
            catch
            {
                return false;
            }
            //Depois de concluir executa o que está no finally
            finally
            {
                //Limpa a variável para não consumir recursos
                mensagem.Dispose();

                //Limpa a variável para não consumir recursos
                email.Dispose();
            }
        }
    }
}