using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_2_David_Rodier
{
   public partial class Modifier : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         if (Session["Modify"].ToString() == "true")
         {
            TB_Email.Text = Session["Email"].ToString();
            TB_Name.Text = Session["FullName"].ToString();
            TB_Password.Text = Session["Password"].ToString();
            TB_Username.Text = Session["Username"].ToString();
            Session["Modify"] = "false";
         }
      }
      protected void BTN_Submit_Click(object sender, EventArgs e)
      {
         if (Page.IsValid)
         {
            USERS users = new USERS((string)Application["DB"], this);
            users.ID = Convert.ToInt32(Session["ID"]);
            users.UserName = TB_Username.Text;
            users.Password = TB_Password.Text;
            users.FullName = TB_Name.Text;
            users.Email = TB_Email.Text;
            users.Update();

            Session["Modify"] = "true";

            Session["message"] = "(Inscription réussie - complétez maintenant votre profil...)";
            Response.Redirect("Login.aspx");
         }
      }
   }
}