using ModelsPackage;
using OrderSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Helpers.VMMappers
{
    public class OrderMapper
    {
        public static IEnumerable<OrderVM> MappToOrdersVMList(IList<Orders> orders, IList<Items> items)
        {
            var ordersVMList = new List<OrderVM>();
          

            for (int i = 0; i < orders.Count(); i++)
            {
                ordersVMList.Add(new OrderVM
                {
                    Id = orders[i].Id,
                    Customer = CustomerMapper.MappToCumsterVM(orders[i].Customer),
                    OrderDate = orders[i].OrderDate,
                    OrderLines = MappToOrderLineVMList(orders[i].OrderLines.ToList(), items),
                    TotalAmount= GetOrderTotalPrice(orders[i].OrderLines.ToList(), items)
                });

            }
            return ordersVMList;
        }

        public static List<OrderLineVM> MappToOrderLineVMList(IList<OrderLines> orderLines, IList<Items> items)
        {
            var orderLinesVMList = new List<OrderLineVM>();

            for (int i = 0; i < orderLines.Count(); i++)
            {
                orderLinesVMList.Add(new OrderLineVM
                {
                    LineNumber = orderLines[i].LineNumber,
                    ItemId = orderLines[i].ItemId,
                    Quantity = orderLines[i].Quantity,
                    OrdernNumber = orderLines[i].OrdernNumber,
                    ItemColor = items.Where(c => c.Id == orderLines[i].ItemId).FirstOrDefault().Color,
                    ItemModel = items.Where(c => c.Id == orderLines[i].ItemId).FirstOrDefault().Model,
                    ItemBrand = items.Where(c => c.Id == orderLines[i].ItemId).FirstOrDefault().Brand,
                    Price = items.Where(c => c.Id == orderLines[i].ItemId).FirstOrDefault().Price
                }); 

            }

            return orderLinesVMList;
        }

        public static int GetOrderTotalPrice(IList<OrderLines> orderLines, IList<Items> items)
        {
            var totalPrice = 0;
            for (int i = 0; i < orderLines.Count(); i++)
            {

                totalPrice = orderLines[i].Quantity * items.Where(p => p.Id == orderLines[i].ItemId).FirstOrDefault().Price + totalPrice;
            }

            return totalPrice;
        }
    }
}
