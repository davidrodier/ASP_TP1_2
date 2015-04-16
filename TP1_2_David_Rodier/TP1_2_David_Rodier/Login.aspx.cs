using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SqlExpressUtilities;
using EmailSender;

namespace TP1_2_David_Rodier
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CV_TB_UserName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            USERS users = new USERS((string)Application["DB"], this);
            args.IsValid = users.Username_Exist(TB_Username.Text);
        }
        protected void CV_TB_Password_ServerValidate(object source, ServerValidateEventArgs args)
        {
            USERS users = new USERS((string)Application["DB"], this);
            args.IsValid = users.CheckPassword(TB_Username.Text, TB_Password.Text);

            if (args.IsValid)
            {
                ((Label)Master.FindControl("UserName")).Text = TB_Username.Text;
                Goto_Index("/Index.aspx");
            }
        }
        protected void Oublie_OnClick(Object sender, EventArgs e)
        {
            EMail eMail = new EMail();
            USERS users = new USERS((string)Application["DB"], this);

            // Vous devez avoir un compte gmail
            eMail.From = "davidrodier96@gmail.com";
            eMail.Password = "3gYBoRaS";
            eMail.SenderName = "doNotReply";

            eMail.Host = "smtp.gmail.com";
            eMail.HostPort = 587;
            eMail.SSLSecurity = true;

            eMail.To = users.Getemail(TB_Username.Text);
            eMail.Subject = "Recover Password";
            eMail.Body = users.Getpassword(TB_Username.Text);

            if (eMail.Send())
            {
                ClientAlert(this, "This eMail has been sent with success!");
            }
            else
                ClientAlert(this, "An error occured while sendind this eMail!!!");
        }
        public static void ClientAlert(System.Web.UI.Page page, string message)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "alert", "alert('" + message + "');", true);
        }

        protected void Goto_Index(String index)
        {
            Response.Redirect(index);
        }
    }
}