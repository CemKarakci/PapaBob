using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBob.Domain
{
    public class OrderManager
    {
        public static void GetOrders(DTO.OrdersDto ordersDTO)
        {
            ordersDTO.OrderId = Guid.NewGuid();
            ordersDTO.TotalCost = PizzaPriceManager.CalculateCost(ordersDTO);
            Persistence.OrderRepository.GetOrder(ordersDTO);
            

        }

        public static List<DTO.OrdersDto> retrieveOrder()
        {
            return Persistence.OrderRepository.retrieveOrder();
        }

        public static void completeOrder(Guid orderId)
        {
            Persistence.OrderRepository.completeOrder(orderId);
        }
    }
}
