using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading;

namespace Superthene
{
    internal class Program
    {
        public static Utilities utils = new Utilities();
        public static int userInput = -1;

        public static Events AlertsObject = new Events();
        
        public static IList<Blend> blendList = new List<Blend>();
        public static IList<Product> productList = new List<Product>();
        public static IList<Machine> machineList = new List<Machine>();
        public static IList<WeightLog> weightLogs = new List<WeightLog>();
        public static IList<Matierial> matierialsList = new List<Matierial>();
        public static IList<MatierialSupply> matierialSuppliesList = new List<MatierialSupply>();

        enum MainMenu
        {
            Matierial_management = 1,
            Production_Tracking_,
            Alerts_AND_Reports____,
            Exit________________
        }
        enum ProductionTrackingMenu
        {
            Create_new_product =1,
            Create_weight_log_,
            Product_details___,
            Exit______________
        }
        enum MatierialManagementMenu
        {
            Create_new_blend____ = 1,
            Log_matierials_order,
            Create_new_matierial,
            Log_matierials_used_,
            Matierials_Stored___,
            Blends_Details______,
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
                Console.WriteLine(counter++ +": " + Option.Replace('_', ' ').Replace("AND", "&"));
               
            }
            Console.WriteLine();


            while (!valid)
            {
                string userInputString = Console.ReadLine();
                int PointerTop = Console.CursorTop;

                Console.SetCursorPosition(0, PointerTop-2);   
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, (PointerTop - 1));
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, PointerTop-2);

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
                        list.Add(Option.Replace('_',' ').Replace("AND","&").TrimEnd().ToLower());
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

        public static int ProductionManagementInOptions()
        {
            int output = -1;
            foreach (var options in Enum.GetValues(typeof(MainMenu)))
            {
                output = (int)options;
            }
            return output;
        }
        public static int ProductionManagementMenu()
        {
            int counter = 1;
            bool valid = false;
            Console.Clear();

            foreach (string Option in Enum.GetNames(typeof(ProductionTrackingMenu)))
            {
                Console.WriteLine(counter++ + ": " + Option.Replace('_', ' '));

            }
            Console.WriteLine();

            while (!valid)
            {
                string userInputString = Console.ReadLine();
                int PointerTop = Console.CursorTop;

                Console.SetCursorPosition(0, PointerTop - 2);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, (PointerTop - 1));
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, PointerTop - 2);
                if (int.TryParse(userInputString, out userInput))
                {
                    if (userInput > ProductionManagementInOptions() || userInput < 1)
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
                    foreach (string Option in Enum.GetNames(typeof(ProductionTrackingMenu)))
                    {
                        list.Add(Option.Replace('_', ' ').TrimEnd().ToLower());
                    }
                    if (list.IndexOf(userInputString.TrimEnd().ToLower()) > -1)
                    {
                        userInput = list.IndexOf(userInputString.TrimEnd()) + 1;
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

        public static int MatierialmanagementMenuInOptions()
        {
            int output = -1;
            foreach (var options in Enum.GetValues(typeof(MatierialManagementMenu)))
            {
                output = (int)options;
            }
            return output;
        }
        public static int LoadMatierialManagementMenu()
        {
            int counter = 1;
            bool valid = false;
            Console.Clear();

            foreach (string Option in Enum.GetNames(typeof(MatierialManagementMenu)))
            {
                Console.WriteLine(counter++ + ": " + Option.Replace('_', ' '));

            }
            Console.WriteLine();

            while (!valid)
            {   
                string userInputString = Console.ReadLine();
                int PointerTop = Console.CursorTop;

                Console.SetCursorPosition(0, PointerTop - 2);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, (PointerTop - 1));
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, PointerTop - 2);

                if (int.TryParse(userInputString, out userInput))
                {
                    if (userInput > MatierialmanagementMenuInOptions() || userInput < 1)
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
                    foreach (string Option in Enum.GetNames(typeof(MatierialManagementMenu)))
                    {
                        list.Add(Option.Replace('_', ' ').TrimEnd().ToLower());
                    }
                    if (list.IndexOf(userInputString.TrimEnd().ToLower()) > -1)
                    {
                        userInput = list.IndexOf(userInputString.TrimEnd()) + 1;
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

        public static void CreateNewProduct()
        {
            string userInput;
            double initialWeight = -1;
            int blendID = -1;

            Console.Clear();
            BlendsData();
            Console.WriteLine("============================================");
            while (blendID < 0 || blendID > blendList.Count)
            {
                Console.WriteLine("Please enter the name of the blend you are using for this product");
                userInput = Console.ReadLine();
                if (!int.TryParse(userInput, out blendID))
                {
                    blendID = -1;

                    if (utils.BlendInList(blendList, userInput))
                    {
                        blendID = utils.BlendIndex(blendList, userInput);

                        Console.WriteLine("1,5:" + utils.BlendInList(blendList, userInput));
                        Console.WriteLine("2:" + blendID);
                    }
                }
            }

            while (initialWeight == -1)
            {
                Console.WriteLine("Please enter the initial weight of the product in tonnes (0,00):");
                userInput = Console.ReadLine();
                if (double.TryParse(userInput, out initialWeight))
                {
                    blendList[blendID].BlendStores(matierialsList, matierialSuppliesList, out string sTemp, out double dTemp);
                    if (initialWeight > dTemp)
                    {
                        initialWeight = -1;
                        Console.WriteLine("not enough matierial in stock");
                    }
                }

            }

            foreach (int MatID in blendList[blendID].MatierialIDs(matierialsList))
            {
                double quantity = blendList[blendID].TotalMatUsed(matierialsList, matierialSuppliesList, initialWeight, matierialsList[MatID].MatierialName);
                Product tempObj = new Product(blendID, productList, initialWeight, blendList[blendID].PricePerTonne(matierialsList, matierialSuppliesList));
                productList.Add(tempObj);
        
                IList<int> Supplies = matierialsList[(utils.MatierialIndex(matierialsList, matierialsList[MatID].MatierialName))].GetSupplyIDs();

                if (utils.MatierialSupply(Supplies, matierialSuppliesList) >= quantity)
                {
                    foreach (int supplyID in Supplies)
                    {
                        if (matierialSuppliesList[supplyID - 1].Stock > 0)
                        {
                            double stock = matierialSuppliesList[supplyID - 1].Stock;
                            if (stock > quantity)
                            {
                                matierialSuppliesList[supplyID - 1].UseMatierial(quantity);
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
                }
            }

        }
        public static void CreateWeightLog()
        {
            int PointerTop;
           Console.Clear();
           Console.WriteLine("=============================================================================================================================================================");

            foreach (Product obj in productList.Where(p => p.Sold = false).OrderBy(p=>p.ManufactureDate))
            {
                Console.WriteLine($"Product ID :{obj.ProductID}  Blend: {blendList[obj.BlendID].Name} date of manufacture: {obj.ManufactureDate} Last recorded weight: {obj.weight}");
            }

            Console.WriteLine("=============================================================================================================================================================");

            int ProductID;
            Console.WriteLine("\n Please enter the Product ID number that you are updating");
            while(!int.TryParse(Console.ReadLine(),out ProductID) || ProductID < 0 || ProductID > productList.Count)
            {
                PointerTop = Console.CursorTop;

                Console.SetCursorPosition(0, PointerTop - 2);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, (PointerTop - 1));
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, PointerTop - 2);

                Console.WriteLine("please enter a valid number that represents a product ID");
            }

            PointerTop = Console.CursorTop;

            Console.SetCursorPosition(0, PointerTop - 2);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, (PointerTop - 1));
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, PointerTop - 2);

            int MachineID;
            Console.WriteLine("\n Please enter the machine ID number of the machine used");
            while (!int.TryParse(Console.ReadLine(), out MachineID) || MachineID < 0 || MachineID > machineList.Count)
            {
                PointerTop = Console.CursorTop;

                Console.SetCursorPosition(0, PointerTop - 2);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, (PointerTop - 1));
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, PointerTop - 2);

                Console.WriteLine("please enter a valid number that represents a machine ID");
            }

            double Weight;
            Console.WriteLine("\n Please enter the Product's weight in tonnes");
            while (!Double.TryParse(Console.ReadLine(), out Weight) || Weight < 0 )
            {
                PointerTop = Console.CursorTop;

                Console.SetCursorPosition(0, PointerTop - 2);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, (PointerTop - 1));
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, PointerTop - 2);

                Console.WriteLine("please enter a valid weight in the format '00,00'");
            }

            productList[ProductID].UpdateWeight(Weight);
            WeightLog tempObj = new WeightLog(ProductID,Weight,MachineID,weightLogs);
            weightLogs.Add(tempObj);

            Console.WriteLine($"New weight of product {ProductID} has been logged at {Weight} Tonnes");
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
            foreach (var LI in matierialsList)
            {

                Console.WriteLine(count + ":  " + LI.MatierialName + "        " + utils.MatierialSupply(LI.GetSupplyIDs(), matierialSuppliesList) + " tonnes");

            }

            Console.WriteLine("Enter the name of the matierial used:");
            string matierial = Console.ReadLine();
            while (!utils.MatierialInList(matierialsList, matierial) && (!int.TryParse(matierial, out matierialNumber) || matierialNumber <= 0 || matierialNumber > count))
            {
                Console.WriteLine("Please enter a valid matierial name:");
                matierial = Console.ReadLine();
            }

            if (int.TryParse(matierial, out matierialNumber))
            {
                matierial = matierialsList[matierialNumber - 1].MatierialName;
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

            if (utils.MatierialSupply(Supplies, matierialSuppliesList) >= quantity)
            {
                foreach (int supplyID in Supplies)
                {
                    if (matierialSuppliesList[supplyID - 1].Stock > 0)
                    {
                        double stock = matierialSuppliesList[supplyID - 1].Stock;
                        if (stock > quantity)
                        {
                            matierialSuppliesList[supplyID - 1].UseMatierial(quantity);
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
            }
            if (quantity == 0)
            {
                Console.WriteLine("supply levels updated");
            }
            else
            { 
            Console.WriteLine($"Not enough matierial in stock. please order at least {quantity- utils.MatierialSupply(Supplies, matierialSuppliesList)} tonnes more {matierial}");
            }

            Console.ReadKey();

        }
        public static void MatierialsData()
        {
            int count = 1;
            Console.Clear();
            foreach (var LI in matierialsList)
            {

                Console.WriteLine(count + ":  " + LI.MatierialName + "\t " + utils.MatierialSupply(LI.GetSupplyIDs(), matierialSuppliesList) + " tonnes \t R" + utils.MatierialCostPerTonne(LI.GetSupplyIDs(), matierialSuppliesList)+" per tonne");
                count++;
            }
            Console.ReadKey();
        }
        public static void BlendsData() 
        {
            int count = 1;
            Console.Clear();
            foreach(var LI in blendList)
            {
                IDictionary<string,double> Matierialstores = LI.BlendStores(matierialsList, matierialSuppliesList,out string BindingMat,out double TotalAvailable);
                Console.WriteLine($"{count}:  {LI.Name}\n\tTotal Produceable: {TotalAvailable} tonnes\n\tLimiting Matierial: {BindingMat}\n\t Price Per Tonne: R{LI.PricePerTonne(matierialsList,matierialSuppliesList)}");
                count += 1;
            }
        }

        static void Main(string[] args)
        {
            do
            {
                switch(LoadMainMenu())
                {
                    case 1:
                        do
                        {
                            switch (LoadMatierialManagementMenu())
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
                                    MatierialsData();
                                    break;
                                case 6:
                                    BlendsData();
                                    Console.ReadKey();
                                    break;
                                case 7:
                                    userInput = MatierialmanagementMenuInOptions() + 1;
                                    break;
                                default:
                                    break;
                            }
                        } while (userInput != MatierialmanagementMenuInOptions() + 1);
                        break;
                    case 2:
                        do
                        {
                            switch (ProductionManagementMenu())
                            { 
                                case 1:
                                    CreateNewProduct();
                                    break;
                                case 2:
                                    CreateWeightLog();
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    userInput = ProductionManagementInOptions() + 1;
                                    break;
                                default :
                                    break;
                            }
                        }while (userInput != ProductionManagementInOptions() + 1);
                    break;
                    case 3:
                    break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                    break;
                }
                AlertsObject.AlertUser(matierialSuppliesList);
            } while (true);
        }

        static void ThreadErrorAlerts()
        {
            while (true)
            {
                AlertsObject = new Events();

                Thread.Sleep(10000);
                foreach (Matierial obj in matierialsList)
                {
                    List<Product> tempListProducts = (List<Product>)productList.Where(p => p.ManufactureDate > DateTime.Now.AddDays(-1214)).Where(p=>blendList[p.BlendID].MatierialIDs(matierialsList).Contains(obj.MatierialID));
                    double averageRatio = 1.1 * tempListProducts.Average(p => blendList[p.BlendID].MatierialCompositionPercent(obj.MatierialName));
                    Double ThreashHoldValue = averageRatio * tempListProducts.Average(p => p.InitialWeight);
                    if (utils.MatierialSupply(obj.GetSupplyIDs(), matierialSuppliesList)<ThreashHoldValue)
                    {
                        //run event that informs the user that they should order more matierial of the selected type
                        // if they do not order new matierial add it to the list of notified matierials as to not repeatedly order new matierial 
                        AlertsObject.Alert += obj.AlertUser;
                        
                    }

                }
            }
        }
    }
}
