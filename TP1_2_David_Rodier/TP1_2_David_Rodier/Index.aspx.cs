using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_2_David_Rodier
{
   public partial class Index : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         USERS users = new USERS((string)Application["DB"], this);
         Session["ID"] = users.GetInt(Session["LogedUser"].ToString()).ToString();
         Session["Modify"] = "true";
      }
      protected void Deco_OnClick(object sender, EventArgs e)
      {
         USERS users = new USERS((string)Application["DB"], this);
         users.NonQuerySQL("UPDATE USERS SET ONLINE='N' WHERE USERNAME='" + Session["LogedUser"].ToString() + "'");
         Response.Redirect("Login.aspx");
      }
      protected void Modifier_OnClick(object sender, EventArgs e)
      {
         String[] list = { "", "", "", "", "" };
         USERS users = new USERS((string)Application["DB"], this);
         list = users.SelectByUsername(Session["LogedUser"].ToString());

         Session["Username"] = list[0];
         Session["Password"] = list[1];
         Session["Fullname"] = list[2];
         Session["Email"] = list[3];

         Response.Redirect("Modifier.aspx");
      }
   }
}