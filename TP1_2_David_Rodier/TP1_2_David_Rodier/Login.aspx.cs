using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SqlExpressUtilities;

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

          if(args.IsValid)
              Goto_Index();
      }

       protected void Goto_Index()      
       {
          Response.Redirect("/Index.aspx"); 
      }
   }
}