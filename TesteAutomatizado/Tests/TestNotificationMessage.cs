using NUnit.Framework;
using System;
using System.Threading;
using TesteAutomatizado.Paginas;
using TesteAutomatizado.Testes;

namespace TesteAutomatizado
{
    public class TestNotificationMessage : BaseTeste
    {

        public string url = "http://the-internet.herokuapp.com/notification_message_rendered";

        [Test] [Retry(2)]
        public void MensagemSucesso()
        {
            Console.WriteLine("Executando teste");

            NotificationMessagePage notification = new NotificationMessagePage(driver);
            notification.NavegaParaPagina(url);
            notification.ClickNoLink();
            string msg = notification.PegaMensagem();
            Thread.Sleep(3000);

            #region Assert

            switch (msg)
            {
                case "Action unsuccesful, please try again":
                    Assert.AreEqual(notification.PegaMensagem(), "Action unsuccesful, please try again");
                    break;
                case "Action successful":
                    Assert.AreEqual(notification.PegaMensagem(), "Action successful");
                    break;

            }
            #endregion

        }

        [Test]
        [Retry(2)]
        public void MensagemNaoSucesso()
        {
            Console.WriteLine("Executando teste");

            NotificationMessagePage notification = new NotificationMessagePage(driver);
            notification.NavegaParaPagina(url);
            notification.ClickNoLink();
            string msg = notification.PegaMensagem();
            Thread.Sleep(3000);
            #region Assert
            switch (msg)
            {
                case "Action unsuccesful, please try again":
                    Assert.AreEqual(notification.PegaMensagem(), "Action unsuccesful, please try again");
                    break;
                case "Action successful":
                    Assert.AreEqual(notification.PegaMensagem(), "Action successful");
                    break;
            }
            #endregion
        }

    }
}
