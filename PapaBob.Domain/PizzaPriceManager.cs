using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBob.DTO;

namespace PapaBob.Domain
{
    public class PizzaPriceManager
    {
        public static decimal CalculateCost(OrdersDto order)
        {
            //var cost = getPizzaPrice();
            decimal cost = 0M;
            var price = getPizzaPrice();
            cost += determineSizeCost(price,order);
            cost += determineCrustCost(price, order);
            cost += determineToppingsCost(price,order);
            return cost;

        }

        private static decimal determineSizeCost(PizzaPriceDto price, OrdersDto order)
        {
            var cost = 0.0M;
            switch (order.Size)
            {
                case DTO.Enums.SizeType.Small:
                    cost = price.SmallSizeCost;
                    break;
                case DTO.Enums.SizeType.Medium:
                    cost = price.MediumSizeCost;
                    break;
                case DTO.Enums.SizeType.Large:
                    cost = price.LargeSizeCost;
                    break;
                default:
                    break;
            }
            return cost;
        }

        private static decimal determineCrustCost(PizzaPriceDto price, OrdersDto order)
        {
            decimal cost = 0.0M;
            switch (order.Crust)
            {
                case DTO.Enums.CrustType.Regular:
                    cost = price.RegularCrustCost;
                    break;
                case DTO.Enums.CrustType.Thin:
                    cost = price.ThinCrustCost;
                    break;
                case DTO.Enums.CrustType.Thick:
                    cost = price.ThickCrustCost;
                    break;
                default:
                    break;
            }
            return cost;
        }

        private static decimal determineToppingsCost(PizzaPriceDto price, OrdersDto order)
        {
            decimal cost = 0.0M;
            cost += (order.Sausage ) ? price.SausageCost : 0M;
            cost += (order.Pepperoni) ? price.PepperoniCost : 0M;
            cost += (order.Onions) ? price.OnionsCost : 0M;
            cost += (order.GreenPeppers) ? price.GreenPeppersCost : 0M;
            return cost;
        }

        private static PizzaPriceDto getPizzaPrice()
        {
            var price = Persistence.PizzaPriceRepository.GetPizzaPrice();
            return price;
        }

    }
}
