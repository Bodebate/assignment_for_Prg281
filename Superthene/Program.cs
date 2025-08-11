using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Superthene
{
    internal class Program
    {
        public static Utilities utils = new Utilities();
        public static int userInput = -1;
        public static IList<Blend> blendList = new List<Blend>();
        public static IList<Matierial> matierialsList = new List<Matierial>();
        public static IList<MatierialSupply> matierialSuppliesList = new List<MatierialSupply>();

        enum MainMenu
        {
            Create_new_blend____ = 1,
            Log_matierials_order,
            Create_new_matierial,
            Log_matierials_used_,
            Exit________________
        }
        public static int MainMenuInOptions()
        {
            int output = -1;
            foreach (var options in Enum.GetValues(typeof(MainMenu))) 
            {
                output = (int)options;
            }
            return output;
        }
        public static int LoadMainMenu()
        {
            int counter = 1;
            bool valid = false;
            Console.Clear();

            foreach (string Option in Enum.GetNames(typeof(MainMenu)))
            {
                Console.WriteLine(counter++ +": " + Option.Replace('_', ' '));
               
            }


            while (!valid)
            {
                string userInputString = Console.ReadLine();
                if (int.TryParse(userInputString, out userInput))
                {
                    if (userInput > MainMenuInOptions() || userInput < 1)
                    {
                        Console.WriteLine("please input a valid option");
                    }
                    else
                    {
                        valid = true;
                    }
                }
                else
                {
                   List<string> list = new List<string>();
                    foreach (string Option in Enum.GetNames(typeof(MainMenu)))
                    {
                        list.Add(Option.Replace('_',' ').TrimEnd().ToLower());
                    }
                    if (list.IndexOf(userInputString.TrimEnd().ToLower()) > -1)
                    {
                        userInput = list.IndexOf(userInputString.TrimEnd())+1;
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("please input a valid option");
                    }
                    
                }
            }

            return userInput;
        }

        public static void CreateNewBlend()
        {
            Console.WriteLine("Please enter the name of the blend:");
            string name = Console.ReadLine();
            bool exists = false;

            foreach (var obj in blendList)
            {
                if (obj.Name == name)
                {
                    exists = true;
                    break;
                }
            }

            Console.WriteLine();

            if (!exists)
            {
                Blend tempobj = new Blend(name, blendList);
                tempobj.DetermineBlend(matierialsList);
                blendList.Add(tempobj);

                Console.WriteLine($"The blend '{name}' has been added successfully");
            }
            else
            {
                Console.WriteLine("Blend already exists");
            }
            Console.ReadKey();
        }
        public static void CreateNewMatierial()
        {
            string name;
            bool exists = false;
            Console.WriteLine("Please enter the name of the matierial ");
           name = Console.ReadLine();

            foreach(var Obj in matierialsList)
            {
                if (Obj.MatierialName == name)
                {
                    exists = true;
                    break;
                }
            }

            Console.WriteLine();
            if (!exists)
            {
                Matierial tempobj = new Matierial(name, matierialsList);
                matierialsList.Add(tempobj);
                Console.WriteLine($"The matierial '{name}' has been added successfully");
            }
            else
            {
                Console.WriteLine("Matierial already exists");
            }
            Console.ReadKey();
        }
        public static void AddNewMateirialSupply()
        {
            double value;
            double quantity;
            Console.WriteLine("Please enter the name of the matierial youve purchased:");
            string name = Console.ReadLine();
            while (!utils.MatierialInList(matierialsList,name))
            { 
                Console.WriteLine("Please enter a valid name for the matierial youve purchased:");
                name = Console.ReadLine();
            }

            Console.WriteLine("please enter the price you paid for the matierials:");
            string userInput = Console.ReadLine().ToUpper().Replace('R', ' ');
            while (!double.TryParse(userInput, out value))
            {
                Console.WriteLine("please enter the price you paid for the matierials in the format 'R00,00':");
                userInput = Console.ReadLine().ToUpper().Replace('R', ' ');
            }

            Console.WriteLine("please enter the weight in tonnes of the matierial you purchased:");
            userInput = Console.ReadLine();
            while (!double.TryParse(userInput, out quantity))
            {
                Console.WriteLine("please enter the weight in tonnes of the matierial you purchased: in the format '00,00':");
                userInput = Console.ReadLine();
            }

            MatierialSupply TempObj = new MatierialSupply(name,value,quantity, matierialSuppliesList);
            matierialSuppliesList.Add(TempObj);
            matierialsList[(utils.MatierialIndex(matierialsList, name))].AddSupply(matierialSuppliesList.Count);


            Console.WriteLine("supplies successfully added");
            Console.ReadKey();
        }

        public static void LogMatierialUsage()
        { int matierialNumber = -1;
            int count = 1;
            Console.Clear();
            foreach (var LI  in matierialsList)
            {
                
                Console.WriteLine( count+":  "+LI.MatierialName+"        "+utils.MatierialSupply(LI.GetSupplyIDs(),matierialSuppliesList)+" tonnes");
                    
            }

            Console.WriteLine("Enter the name of the matierial used:");
            string matierial = Console.ReadLine();
            while (!utils.MatierialInList(matierialsList, matierial) && (!int.TryParse(matierial,out matierialNumber)||matierialNumber<=0||matierialNumber>count))
            {
                Console.WriteLine("Please enter a valid matierial name:");
                matierial = Console.ReadLine();
            }

            if (int.TryParse(matierial, out matierialNumber))
            {
                matierial = matierialsList[matierialNumber-1].MatierialName;
            }    

            Console.WriteLine("please enter the weight in tonnes of the matierial you used:");
            string userInput = Console.ReadLine();
            double quantity;
            while (!double.TryParse(userInput, out quantity))
            {
                Console.WriteLine("please enter the weight in tonnes of the matierial you used: in the format '00,00':");
                userInput = Console.ReadLine();
            }
            IList<int> Supplies = matierialsList[(utils.MatierialIndex(matierialsList, matierial))].GetSupplyIDs();
            foreach (int supplyID in Supplies)
            {
                if( matierialSuppliesList[supplyID-1].Stock > 0)
                {
                    double stock = matierialSuppliesList[supplyID-1].Stock;
                    if (stock > quantity)
                    {
                        matierialSuppliesList[supplyID-1].UseMatierial(quantity);
                        quantity = 0;
                        break;
                    }
                    else
                    {
                        matierialSuppliesList[supplyID - 1].UseMatierial(stock);
                        quantity -= stock;
                    } 
                }
            }
            if (quantity == 0)
                Console.WriteLine("supply levels updated");
            else
                Console.WriteLine($"Not enough matierial in stock. please order at least {quantity} tonnes more {matierial}");
            Console.ReadKey();

        }

        static void Main(string[] args)
        {
            
            do
            {
                switch(LoadMainMenu())
                {
                    case 1:
                        CreateNewBlend();
                        break;
                    case 2:
                        AddNewMateirialSupply();
                        break;
                    case 3:
                        CreateNewMatierial();
                        break;
                    case 4:
                        LogMatierialUsage();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while (userInput != MainMenuInOptions()+1);
        }
    }
}
