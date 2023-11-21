using System.Text;

namespace _03.StoreBoxes
{
    internal class StoreBoxes
    {
        static void Main(string[] args)
        {
            /*
             * Until you receive "end", you will be receiving data in the following format: "{Serial Number} {Item Name} {Item Quantity} {itemPrice}"
             * The Price of one box has to be calculated: itemQuantity * itemPrice.
             */

            var boxes = new List<Box>();

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] split = input.Split();

                string boxSerialNumber = split[0];
                string itemName = split[1];
                int itemQty = int.Parse(split[2]);
                double itemPrice = double.Parse(split[3]);

                var item = new Item(itemName, itemPrice);
                var box = new Box(boxSerialNumber, item, itemQty);

                boxes.Add(box);

                input = Console.ReadLine();
            }

            /*
             * Print all the boxes ordered descending by price for a box, in the following format: 
             *   {boxSerialNumber}
             *   -- {boxItemName} - ${boxItemPrice}: {boxItemQuantity}
             *   -- ${boxPrice}
             * The price should be formatted to the 2nd digit after the decimal separator.
             */

            boxes.OrderByDescending(b => b.Price).ToList().ForEach(b => Console.WriteLine(b));
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Item(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }

    public class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQty { get; set; }
        public double Price { get; private set; }

        public Box(string serialNumber, Item item, int itemQty)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQty = itemQty;
            Price = item.Price * itemQty;
        }

        /*
         * {boxSerialNumber}
         * -- {boxItemName} - ${boxItemPrice}: {boxItemQuantity}
         * -- ${boxPrice}
         * The price should be formatted to the 2nd digit after the decimal separator.
         */
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine(SerialNumber);
            sb.AppendLine($"-- {Item.Name} - ${Item.Price:f2}: {ItemQty}");
            sb.Append($"-- ${Price:f2}");

            return sb.ToString();
        }
    }
}