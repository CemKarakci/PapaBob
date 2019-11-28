using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PapaBob.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void orderButton_Click(object sender, EventArgs e)
        {
            if(nameTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please enter name.";
                validationLabel.Visible = true;
                return;
            }
            if(adressTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please enter adress.";
                validationLabel.Visible = true;
                return;
            }
            if(zipTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please enter zip.";
                validationLabel.Visible = true;
                return;
            }
            if(phoneTextBox.Text.Trim().Length == 0)
            {
                validationLabel.Text = "Please enter phone Number.";
                validationLabel.Visible = true;
                return;
            }
            try
            {
                var order = buildOrder();
                Domain.OrderManager.GetOrders(order);
                Response.Redirect("success.aspx");
            }
            catch (Exception ex)
            {
                validationLabel.Text = ex.Message;
                validationLabel.Visible = true;
            }
           
            
        }
        private DTO.Enums.CrustType determineCrust()
        {
            DTO.Enums.CrustType crust;
            if (!Enum.TryParse(crustDropDownList.SelectedValue, out crust))
            {
                throw new Exception("Can't determine Crust");
            }
            return crust;
        }


        private DTO.Enums.SizeType determineSize()
        {
            DTO.Enums.SizeType size;

            if (!Enum.TryParse(sizeDropDownList.SelectedValue, out size))
            {
                throw new Exception("Can't determine Size");
            }
            return size;
        }


        private DTO.Enums.PaymentType determinePaymentType()
        {
            DTO.Enums.PaymentType paymentType;
            if (cashRadioButton.Checked)
            {
                paymentType = DTO.Enums.PaymentType.Cash;
            }

            else
            {
                paymentType = DTO.Enums.PaymentType.Credit;
            }           

            return paymentType;
        }
        protected void recalculateCost(object sender, EventArgs e)
        {
            if (sizeDropDownList.SelectedValue == String.Empty) return;
            if (crustDropDownList.SelectedValue == String.Empty) return;
            var order = buildOrder();
            try
            {
                paymentLabel.Text = Domain.PizzaPriceManager.CalculateCost(order).ToString("C");
            }
            catch
            {
              
            }
            
           
            
        }

        private DTO.OrdersDto buildOrder()
        {
            var order = new DTO.OrdersDto();


            order.Size = determineSize();
            order.Crust = determineCrust();
            order.Sausage = sausageCheckBox.Checked;
            order.Pepperoni = pepperoniCheckBox.Checked;
            order.Onions = onionsCheckBox.Checked;
            order.GreenPeppers = greenpepperCheckBox.Checked;
            order.Name = nameTextBox.Text;
            order.Adress = adressTextBox.Text;
            order.Zip = zipTextBox.Text;
            order.Phone = phoneTextBox.Text;
            order.PaymentType = determinePaymentType();
            return order;
        }
    }
}