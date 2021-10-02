using ModelsPackage;
using OrderSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSystem.Helpers.VMMappers
{
    public class ItemMapper
    {
        public static List<ItemVM> MappToItemVMLis(IList<Items> items)
        {
            var itemsVMList = new List<ItemVM>();

            for (int i = 0; i < items.Count(); i++)
            {
                itemsVMList.Add(
                    new ItemVM
                    {
                        Id = items[i].Id,
                        Brand = items[i].Brand,
                        Model = items[i].Model,
                        Color = items[i].Color,
                        Price= items[i].Price,
                    });
            }

            return itemsVMList;
        }

        public static List<OrderLineVM> MappToOrderLineVMLis(IList<Items> items)
        {
            var itemsVMList = new List<OrderLineVM>();

            for (int i = 0; i < items.Count(); i++)
            {
                itemsVMList.Add(
                    new OrderLineVM
                    {
                        ItemId = items[i].Id,
                        ItemBrand = items[i].Brand,
                        ItemModel = items[i].Model,
                        ItemColor = items[i].Color,
                        Price = items[i].Price,
                    });
            }

            return itemsVMList;
        }
    }
}
