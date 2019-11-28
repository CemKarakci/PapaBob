using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBob.Web
{
    public partial class OrderManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            refreshGridView();

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView1.Rows[index];
            var value = row.Cells[1].Text.ToString();

            var OrderId = Guid.Parse(value);

            Domain.OrderManager.completeOrder(OrderId);
            refreshGridView();
        }

        private void refreshGridView()
        {
            var order = Domain.OrderManager.retrieveOrder();
            GridView1.DataSource = order;
            GridView1.DataBind();
        }
    }
}