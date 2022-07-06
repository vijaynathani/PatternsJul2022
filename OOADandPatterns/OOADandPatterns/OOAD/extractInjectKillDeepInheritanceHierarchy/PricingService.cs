using System;
using System.Linq;

namespace OOAD.extractInjectKillDeepInheritanceHierarchy
{
    internal class PricingService
    {
        private readonly IPriceCalculation _priceCalculation;
        private readonly VoucherService _voucherService;

        public PricingService(VoucherService v, IPriceCalculation pc)
        {
            _voucherService = v;
            _priceCalculation = pc;
        }

        public double CalculatePrice(ShoppingBasket shoppingBasket,
                                     User user, String voucher)
        {
            double discount = CalculateDiscount(user);
            double total =
                shoppingBasket.Items().Sum(
                    item => _priceCalculation.CalculateProductPrice(item.GetProduct(), item.GetQuantity()));
            total = ApplyAdditionalDiscounts(total, user, voucher);
            return total*((100 - discount)/100);
        }

        private static double CalculateDiscount(User user)
        {
            var discount = 0;
            if (user.IsPrime())
            {
                discount = 10;
            }
            return discount;
        }

        private double ApplyAdditionalDiscounts(double total, User user,
                                                String voucher)
        {
            var voucherValue = _voucherService.GetVoucherValue(voucher);
            var totalAfterValue = total - voucherValue;
            return (totalAfterValue > 0) ? totalAfterValue : 0;
        }
    }

    internal interface IPriceCalculation
    {
        double CalculateProductPrice(Product product, int quantity);
    }

    internal class StandardPriceCalculation : IPriceCalculation
    {
        public double CalculateProductPrice(Product product, int quantity) => product.GetPrice()*quantity;
    }
    internal class BoxingDayPriceCalculation : IPriceCalculation
    {
        public const double BoxingDayDiscount = 0.60;
        public double CalculateProductPrice(Product product, int quantity) => (product.GetPrice()*quantity)*BoxingDayDiscount;
    }

    //To avoid compilation errors, the following classes are created
    internal class Product
    {
        public double GetPrice() => 0;
    }
    internal class VoucherService
    {
        public double GetVoucherValue(String voucher) => 0;
    }
    internal class User
    {
        public bool IsPrime() => false;
    }
    internal class ShoppingBasket
    {
        public Item[] Items() => null;
    }
    internal class Item
    {
        public Product GetProduct() => null;
        public int GetQuantity() => 0;
    }
}