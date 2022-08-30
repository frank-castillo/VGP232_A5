using System;

namespace Assignment5
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Adventure of Assignment 5!");

            // TODO: Create an inventory
            Inventory inventory = new Inventory(2);
            // TODO: Add 2 items to the inventory
            Item potion  = new Item("Potion", 5, ItemGroup.Consumable);
            Item bossKey = new Item("Boss Key", 1, ItemGroup.Key);

            if(inventory.AddItem(potion))
            {
                Console.WriteLine($"Succesfully added {potion.ToString()}");
            }

            if (inventory.AddItem(bossKey))
            {
                Console.WriteLine($"Succesfully added {bossKey.ToString()}");
            }

            // Verify the number of items in the inventory.
            Console.WriteLine($"Number of items in inventory: {inventory.ListAllItems().Count}");
        }
    }
}