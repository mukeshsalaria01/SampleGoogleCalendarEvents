using System;
using System.Web.UI;

namespace ASPCalendarEvent
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetEvents_OnClick(object sender, EventArgs e)
        {
            int days;
            int.TryParse(txtDays.Text, out days);
            Response.Redirect("ASPCalendarEvent.aspx?days=" + days);
        }
    }
}