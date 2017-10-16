using System;
using System.Collections.Generic;

namespace array_3
{
    class Program
    {
        public static void Main(string[] args)
        {
            //'close the app' message
            Console.Write("\n\n  To stop the program and close its window press 'Ctrl+C' combination \n\n");
            //fields declaration block
            List<string> shopList = new List<string>();
            string userInput = "";
            int choiseNum = 0;
            //displaying a list of available options
            Console.Write("\nThis is your personal shopping list.\nYou can manipulate items within one using following options:\n\n[1] View complete list of items\n[2] Create new item on the list\n[3] Remove an item from the list\n");

            do
            {
                //user's input to choose one of available options
                do
                {
                    Console.Write("\nEnter an index of preferable option and press 'Enter': ");
                    if (!Int32.TryParse(Console.ReadLine(), out choiseNum) || choiseNum < 1 || choiseNum > 3)
                        Console.Write("\nYour input is incorrect: there's no option with such an index.");
                } while (choiseNum < 1 || choiseNum > 3);
                //message for 'displaying' & 'deleting' options if were chosen for the empty list
                if ((choiseNum == 1 || choiseNum == 3) & shopList.Count == 0)
                {
                    Console.Write("\nThere're no items in your shopping list yet.\nTo create a new item use an option with index '2'.");
                    continue;
                }
                //processing of chosen option
                switch (choiseNum)
                {
                    //displaying all available items of the list
                    case 1:
                        for (int i = 0; i < shopList.Count; i++)
                            Console.Write("\n{0}. {1}", i + 1, shopList[i]);
                        Console.WriteLine();
                        break;

                    //creating and adding a new item in the list
                    case 2:
                        Console.Write("\nEnter a name for your new item: ");
                        userInput = Console.ReadLine();

                        //'empty or null' input for new item's name rejection
                        if (String.IsNullOrWhiteSpace(userInput))
                            Console.Write("\nThe new item wasn't created because a name wasn't given to one");

                        //adding an item in the empty list
                        else if (shopList.Count == 0)
                        {
                            shopList.Add(userInput);
                            Console.Write("\nThe item was added to your shopping list.");
                        }

                        //prevention of adding an item with a name already existing in the list
                        else
                        {
                            if (shopList.Contains(userInput))
                                Console.Write("\nThe new item wasn't created as there's one with such name in the list already.");
                            else
                            {
                                shopList.Add(userInput);
                                Console.Write("\nThe item was added to your shopping list.");
                            }
                        }
                        break;

                    //removing an item by its name from the list
                    case 3:
                        Console.Write("\nTo remove an item enter its name in the list and press 'Enter': ");
                        userInput = Console.ReadLine();
                        if (shopList.Contains(userInput))
                        {
                            shopList.Remove(userInput);
                            Console.Write("\nThe item was removed from your shopping list.");
                        }
                        else
                            Console.Write("\nThere's no such item within your list.");
                        break;

                    default:
                        Console.WriteLine("Your input is incorrect, please choose any available option to continue.");
                        break;
                }
            } while (true); //infinite loop condition
        }
    }
}