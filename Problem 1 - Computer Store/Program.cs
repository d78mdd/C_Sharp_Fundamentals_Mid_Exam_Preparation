using System;

namespace Problem_1___Computer_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            const double tax = 0.20;
            const double discount = 0.10;

            double total = 0;
            double totalWithTaxes = 0;
            double totalTaxes = 0;

            string customerType;

            for (; ; )
            {
                string input = Console.ReadLine();

                if (input.Equals("special") || input.Equals("regular"))
                {
                    customerType = input;
                    break;
                }

                double price = double.Parse(input);
                if (price < 0)
                {
                    Console.WriteLine("Invalid price!");
                    continue;
                }

                double priceTax = 0.20 * price;
                double priceTaxed = price + priceTax;

                total += price;
                totalWithTaxes += priceTaxed;
                totalTaxes += priceTax;
            }

            if (customerType.Equals("special"))
            {
                double priceTaxedDiscount = totalWithTaxes * discount;
                double priceTaxedDiscounted = totalWithTaxes - priceTaxedDiscount;

                totalWithTaxes = priceTaxedDiscounted;
            }

            if (totalWithTaxes == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine("Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {total:F2}$");
                Console.WriteLine($"Taxes: {totalTaxes:F2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalWithTaxes:F2}$");
            }
        }
    }
}
