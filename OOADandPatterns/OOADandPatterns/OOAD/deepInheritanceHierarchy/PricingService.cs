using System;
using System.Linq;

namespace OOAD.deepInheritanceHierarchy
{
    internal abstract class PricingService
    {
        public double CalculatePrice(ShoppingBasket shoppingBasket,
                                     User user, String voucher)
        {
            double discount = CalculateDiscount(user);
            double total =
                shoppingBasket.Items().Sum(item => CalculateProductPrice(item.GetProduct(), item.GetQuantity()));
            total = ApplyAdditionalDiscounts(total, user, voucher);
            return total*((100 - discount)/100);
        }

        protected abstract double CalculateDiscount(User user);

        protected abstract double CalculateProductPrice(Product product,
                                                        int quantity);

        protected abstract double ApplyAdditionalDiscounts(double total,
                                                           User user, String voucher);
    }

    internal abstract class UserDiscountPricingService : PricingService
    {
        protected override double CalculateDiscount(User user)
        {
            int discount = 0;
            if (user.IsPrime())
            {
                discount = 10;
            }
            return discount;
        }
    }

    internal abstract class VoucherPricingService :
        UserDiscountPricingService
    {
        private VoucherService _voucherService;

        protected override double ApplyAdditionalDiscounts(double total,
                                                           User user, String voucher)
        {
            double voucherValue = _voucherService.GetVoucherValue(voucher);
            double totalAfterValue = total - voucherValue;
            return (totalAfterValue > 0) ? totalAfterValue : 0;
        }

        public void SetVoucherService(VoucherService voucherService)
        {
            _voucherService = voucherService;
        }
    }

    internal class StandardPricingService : VoucherPricingService
    {
        protected override double CalculateProductPrice(Product product,
                                                        int quantity)
        {
            return product.GetPrice()*quantity;
        }
    }

    internal class BoxingDayPricingService : VoucherPricingService
    {
        public const double BoxingDayDiscount = 0.60;

        protected override double CalculateProductPrice(Product product,
                                                        int quantity)
        {
            return ((product.GetPrice()*quantity)*BoxingDayDiscount);
        }
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