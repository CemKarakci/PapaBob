using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PapaBob.DTO;

namespace PapaBob.Persistence
{
    public class OrderRepository
    {
        public static void GetOrder(DTO.OrdersDto orderDto)
        {
            var db = new PapaBobDbEntities();
            var dbOrder = db.Orders;


                var orders = new Orders();
                orders.OrderId = orderDto.OrderId;
                orders.Size = orderDto.Size;
                orders.Crust = orderDto.Crust;
                orders.Sausage = orderDto.Sausage;
                orders.Pepperoni = orderDto.Pepperoni;
                orders.Onions = orderDto.Onions;
                orders.GreenPeppers = orderDto.GreenPeppers;
                orders.Name = orderDto.Name;
                orders.Adress = orderDto.Adress;
                orders.Zip = orderDto.Zip;
                orders.Phone = orderDto.Phone;
                orders.TotalCost = orderDto.TotalCost;
                orders.PaymentType = orderDto.PaymentType;
                orders.Completed = orderDto.Completed;

                dbOrder.Add(orders);
                db.SaveChanges();
             
            

        }

        public static void completeOrder(Guid orderId)
        {
            var db = new PapaBobDbEntities();
            var order = db.Orders.FirstOrDefault(p => p.OrderId == orderId);
            order.Completed = true;
            db.SaveChanges();
            
        }

        public static List<OrdersDto> retrieveOrder()
        {
            var db = new PapaBobDbEntities();
            var OrderDb = db.Orders.Where(p => p.Completed == false).ToList();
            var order = convertToDto(OrderDb);
            return order;
            
        }

       private static List<OrdersDto> convertToDto(List<Orders> orders)
        {
            var dtOrders = new List<OrdersDto>();

            foreach (var order in orders)
            {
                var dto = new OrdersDto();
                dto.OrderId = order.OrderId;
                dto.Size = order.Size;
                dto.Crust = order.Crust;
                dto.Sausage = order.Sausage;
                dto.Pepperoni = order.Pepperoni;
                dto.Onions = order.Onions;
                dto.GreenPeppers = order.GreenPeppers;
                dto.Name = order.Name;
                dto.Adress = order.Adress;
                dto.Zip = order.Zip;
                dto.Phone = order.Phone;
                dto.TotalCost = order.TotalCost;
                dto.PaymentType = order.PaymentType;
                dto.Completed = order.Completed;

                dtOrders.Add(dto);
            }
            return dtOrders;
        }
    }
}
