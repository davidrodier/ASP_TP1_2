using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_2_David_Rodier
{
   public partial class MasterPage : System.Web.UI.MasterPage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         Master_User.Text = Session["LogedUser"].ToString();
      }
   }
}