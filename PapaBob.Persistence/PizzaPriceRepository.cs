using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapaBob.Persistence
{
    public class PizzaPriceRepository
    {
        public static DTO.PizzaPriceDto GetPizzaPrice()
        {
            var db = new PapaBobDbEntities();
            var price = db.PizzaPrice.First();
            var priceDto = new DTO.PizzaPriceDto();

            priceDto.SmallSizeCost = price.SmallSizeCost;
            priceDto.MediumSizeCost = price.MediumSizeCost;
            priceDto.LargeSizeCost = price.LargeSizeCost;
            priceDto.RegularCrustCost = price.RegularCrustCost;
            priceDto.ThinCrustCost = price.ThinCrustCost;
            priceDto.ThickCrustCost = price.ThickCrustCost;
            priceDto.SausageCost = price.SausageCost;
            priceDto.PepperoniCost = price.PepperoniCost;
            priceDto.OnionsCost = price.OnionsCost;
            priceDto.GreenPeppersCost = price.GreenPeppersCost;

            return priceDto;

        }
    }
}
