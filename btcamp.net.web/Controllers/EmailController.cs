using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace btcamp.net.web.Controllers
{
    public class EmailController : Controller
    {
        //
        // GET: /Email/

        public ActionResult Send(Models.SendEmailViewModel model)
        {
            try
            {
                string sendemail = ConfigurationManager.AppSettings["sendemail"];
                string sendpwd = ConfigurationManager.AppSettings["sendpwd"];
                string toemial = ConfigurationManager.AppSettings["toemail"];
                string smtp = ConfigurationManager.AppSettings["smtp"];
                MailMessage mailMessage = new MailMessage(new MailAddress(sendemail, "比特城邦网络科技有限公司-邮件通知"), new MailAddress(toemial, "老板"));
                mailMessage.Subject = string.Format("联系我们-{0}-{1}-{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), model.name, model.email);
                mailMessage.Body = model.message;
                mailMessage.IsBodyHtml = true;

                SmtpClient client = new SmtpClient(smtp);
                client.Credentials = new NetworkCredential(sendemail, sendpwd);
                client.Send(mailMessage);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
