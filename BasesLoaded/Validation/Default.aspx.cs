using System;
using System.Collections.Generic;
using System.Data;
using OpeningPitch;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Validation
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LINQtoSQLDataContext approved = new LINQtoSQLDataContext();


            Player selectedPlayer = (from p in approved.Players
                             where p.PID == globals.user.PID
                             select p).Single();

            selectedPlayer.Activated  = 1;

            approved.SubmitChanges();
        }
    }
}