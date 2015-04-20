using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1_2_David_Rodier
{
    public partial class Gestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            USERS users = new USERS((string)Application["DB"], this);
            users.SelectAll("UserName");
            users.MakeGridView(PN_GridView, "" /*pas de page d’édition pour l’instant */);
        }
    }
}