using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionState
{
    public partial class WebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Set current user prefs.
            UserShoppingCart u = (UserShoppingCart)Session["UserShoppingCartInfo"];

            u.dateOfPickUp = myCalendar.SelectedDate;
            u.desiredCar = txtCarMake.Text;
            u.desiredCarColor = txtCarColor.Text;
            u.downPayment = float.Parse(txtDownPayment.Text);
            u.isLeasing = chkIsLeasing.Checked;
            
            Session["UserShoppingCartInfo"] = u;

            lblUserID.Text = string.Format("Here is your ID: {0}", Session.SessionID);
            lblUserInfo.Text = u.ToString();
        }
    }
}