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
    // Main entry point and core logic for the Superthene material management and production tracking application.
    internal class Program
    {
        public static Utilities utils = new Utilities();
        public static int userInput = -1;
        public static Events AlertsObject = new Events();
        public static IList<Blend> blendList = new List<Blend>();
        public static IList<Product> productList = new List<Product>();
        public static IList<Machine> machineList = new List<Machine>();
        public static IList<WeightLog> weightLogs = new List<WeightLog>();
        public static IList<Material> materialsList = new List<Material>();
        public static IList<MaterialSupply> materialSuppliesList = new List<MaterialSupply>();

        enum MainMenu
        {
            Material_management_ = 1,
            Production_Tracking_,
            Alerts_AND_Reports____,
            Exit________________
        }
        enum ProductionTrackingMenu
        {
            Create_new_product =1,
            Create_weight_log_,
            Product_details___,
            Sell_product______,
            Exit______________
        }
        enum MaterialManagementMenu
        {
            Create_new_blend____ = 1,
            Log_materials_order_,
            Create_new_material_,
            Log_materials_used__,
            Materials_Stored____,
            Blends_Details______,
            Create_New_Machine__,
            Exit________________
        }


        // Returns the highest value in the MainMenu enum.
        public static int MainMenuInOptions()
        {
            int output = -1;
            foreach (var options in Enum.GetValues(typeof(MainMenu))) 
            {
                output = (int)options;
            }
            return output;
        }
        // Displays the main menu and handles user input for navigation.
        public static int LoadMainMenu()
        {
            int counter = 1;
            bool valid = false;
            Console.Clear();
            UIManager.ClearAndShowTitle("Main Menu");
            foreach (MainMenu Option in Enum.GetValues(typeof(MainMenu)))
            {
                //Console.WriteLine(counter++ +": " + Option.Replace('_', ' ').Replace("AND", "&"));
                Console.WriteLine((int)Option+":  "+Option.ToString().Replace("_"," ").Replace("AND","&"));
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
                        Console.WriteLine("Please input a valid option");
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
                        Console.WriteLine("Please input a valid option");
                    }
                    
                }
            }


            return userInput;
        }
                
        // Returns the highest value in the MainMenu enum (for production management menu).
        public static int ProductionManagementInOptions()
        {
            int output = -1;
            foreach (var options in Enum.GetValues(typeof(ProductionTrackingMenu)))
            {
                output = (int)options;
            }
            return output;
        }
        // Displays the production management menu and handles user input for navigation.
        public static int ProductionManagementMenu()
        {
            int counter = 1;
            bool valid = false;
            Console.Clear();
            UIManager.ClearAndShowTitle("Production Tracking");
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
                        Console.WriteLine("Please input a valid option");
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
                        Console.WriteLine("Please input a valid option");
                    }

                }
            }

            return userInput;
        }

        // Returns the highest value in the MaterialManagementMenu enum.
        public static int MaterialmanagementMenuInOptions()
        {
            int output = -1;
            foreach (var options in Enum.GetValues(typeof(MaterialManagementMenu)))
            {
                output = (int)options;
            }
            return output;
        }
        // Displays the material management menu and handles user input for navigation.
        public static int LoadMaterialManagementMenu()
        {
            int counter = 1;
            bool valid = false;
            Console.Clear();
            UIManager.ClearAndShowTitle("Material Management");
            foreach (string Option in Enum.GetNames(typeof(MaterialManagementMenu)))
            {
                Console.WriteLine(counter++ + ": " + Option.Replace('_', ' '));
            }
            Console.WriteLine();

            int returnValue = -1;
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
                    if (userInput > MaterialmanagementMenuInOptions() || userInput < 1)
                    {
                        Console.WriteLine("Please input a valid option");
                    }
                    else
                    {
                        valid = true;
                        returnValue = userInput;
                    }
                }
                else
                {
                    List<string> list = new List<string>();
                    foreach (string Option in Enum.GetNames(typeof(MaterialManagementMenu)))
                    {
                        list.Add(Option.Replace('_', ' ').TrimEnd().ToLower());
                    }
                    if (list.IndexOf(userInputString.TrimEnd().ToLower()) > -1)
                    {
                        userInput = list.IndexOf(userInputString.TrimEnd()) + 1;
                        valid = true;
                        returnValue = userInput;
                    }
                    else
                    {
                        Console.WriteLine("Please input a valid option");
                    }

                }
            }

            return returnValue;
        }

        // Handles the creation of a new product, including blend selection and material deduction.
        public static void CreateNewProduct()
        {
            if (blendList.Count > 0)
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
                        }
                    }
                    else
                    {
                        blendID += -1;
                    }
                }

                while (initialWeight == -1)
                {
                    Console.WriteLine("Please enter the initial weight of the product in tonnes (0,00):");
                    userInput = Console.ReadLine();
                    if (double.TryParse(userInput, out initialWeight))
                    {
                        blendList[blendID].BlendStores(materialsList, materialSuppliesList, out string sTemp, out double dTemp);
                        if (initialWeight > dTemp)
                        {
                            initialWeight = -1;
                            Console.WriteLine("Not enough material in stock");
                        }
                    }

                }

                foreach (int MatID in blendList[blendID].MaterialIDs(materialsList))
                {
                    double quantity = blendList[blendID].TotalMatUsed(materialsList, materialSuppliesList, initialWeight, materialsList[MatID].MaterialName);
                    Product tempObj = new Product(blendID, productList, initialWeight, blendList[blendID].PricePerTonne(materialsList, materialSuppliesList));
                    productList.Add(tempObj);

                    IList<int> Supplies = materialsList[(utils.MaterialIndex(materialsList, materialsList[MatID].MaterialName))].GetSupplyIDs();

                    if (utils.MaterialSupply(Supplies, materialSuppliesList) >= quantity)
                    {
                        foreach (int supplyID in Supplies)
                        {
                            if (materialSuppliesList[supplyID - 1].Stock > 0)
                            {
                                double stock = materialSuppliesList[supplyID - 1].Stock;
                                if (stock > quantity)
                                {
                                    materialSuppliesList[supplyID - 1].UseMaterial(quantity);
                                    quantity = 0;
                                    break;
                                }
                                else
                                {
                                    materialSuppliesList[supplyID - 1].UseMaterial(stock);
                                    quantity -= stock;
                                }
                            }
                        }
                    }
                }

            }
        }
        // Handles the creation of a new weight log for a product.
        public static void CreateWeightLog()
        {
            if (productList.Where(p => p.Sold == false).OrderBy(p => p.ManufactureDate).Count() > 0)
            {
                int PointerTop;
                Console.Clear();
                Console.WriteLine("=====================================================================================================");

                foreach (Product obj in productList.Where(p => p.Sold == false).OrderBy(p => p.ManufactureDate))
                {
                    Console.WriteLine($"Product ID :{obj.ProductID}  \n\tBlend: {blendList[obj.BlendID].Name} \n\tDate of manufacture: {obj.ManufactureDate} \n\tLast recorded weight: {obj.weight}");
                }

                Console.WriteLine("=====================================================================================================");

                int ProductID;
                Console.WriteLine("\n Please enter the Product ID number that you are updating");
                while (!int.TryParse(Console.ReadLine(), out ProductID) || ProductID < 0 || ProductID > productList.Count)
                {
                    PointerTop = Console.CursorTop;

                    Console.SetCursorPosition(0, PointerTop - 2);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, (PointerTop - 1));
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, PointerTop - 2);

                    Console.WriteLine("Please enter a valid number that represents a product ID");
                }

                Console.Clear();
                Console.WriteLine("=====================================================================================================");

                foreach (Machine obj in machineList)
                {
                    Console.WriteLine($"{obj.MachineID}: {obj.MachineDetails}\n");
                }

                Console.WriteLine("=====================================================================================================");


                int MachineID;
                Console.WriteLine("\n Please enter the machine ID number of the machine used");
                while (!int.TryParse(Console.ReadLine(), out MachineID) || MachineID < 0 || MachineID > machineList.Count - 1)
                {
                    PointerTop = Console.CursorTop;

                    Console.SetCursorPosition(0, PointerTop - 2);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, (PointerTop - 1));
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, PointerTop - 2);

                    Console.WriteLine("Please enter a valid number that represents a machine ID");
                }

                double Weight;
                Console.WriteLine("\n Please enter the Product's weight in tonnes");
                while (!Double.TryParse(Console.ReadLine(), out Weight) || Weight < 0)
                {
                    PointerTop = Console.CursorTop;

                    Console.SetCursorPosition(0, PointerTop - 2);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, (PointerTop - 1));
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(0, PointerTop - 2);

                    Console.WriteLine("Please enter a valid weight in the format '00,00'");
                }

                productList[ProductID].UpdateWeight(Weight);
                WeightLog tempObj = new WeightLog(ProductID, Weight, MachineID, weightLogs);
                weightLogs.Add(tempObj);

                Console.WriteLine($"New weight of product {ProductID} has been logged at {Weight} Tonnes");
            }
        }
        // Displays all products and their details.
        public static void DisplayProducts()
        {
            UIManager.ClearAndShowTitle("Product Details");
            Console.WriteLine("=====================================================================================================");

            foreach (Product obj in productList.OrderBy(p => p.ManufactureDate))
            {
                Console.WriteLine($"Product ID :{obj.ProductID} \n\tBlend: {blendList[obj.BlendID].Name} \n\tDate of manufacture: {obj.ManufactureDate} \n\tLast recorded weight: {obj.weight}\n\tSold: {obj.Sold}");
            }

            Console.WriteLine("=====================================================================================================");
            Console.ReadKey();
        }

        // Handles the creation of a new blend.
        public static void CreateNewBlend()
        {
            if (materialsList.Count > 0)
            {
                Console.Clear();
                UIManager.ClearAndShowTitle("Create New Blend");
                foreach (Material obj in materialsList)
                {
                    obj.ToString(materialSuppliesList);
                }
                Console.WriteLine("=======================================================");
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
                    tempobj.DetermineBlend(materialsList);
                    blendList.Add(tempobj);

                    Console.WriteLine($"The blend '{name}' has been added successfully");
                }
                else
                {
                    Console.WriteLine("Blend already exists");
                }
                Console.ReadKey();
            }
        }
        // Handles the creation of a new material.
        public static void CreateNewMaterial()
        {   Console.Clear();
            UIManager.ClearAndShowTitle("Create New Material");
            foreach (Material obj in materialsList)
            {
                obj.ToString(materialSuppliesList);
            }
            Console.WriteLine("=======================================================");
            string name;
            bool exists = false;
            Console.WriteLine("Please enter the name of the material ");
           name = Console.ReadLine();

            foreach(var Obj in materialsList)
            {
                if (Obj.MaterialName == name)
                {
                    exists = true;
                    break;
                }
            }

            Console.WriteLine();
            if (!exists)
            {
                Material tempobj = new Material(name, materialsList);
                materialsList.Add(tempobj);
                Console.WriteLine($"The material '{name.ToUpper()}' has been added successfully");
            }
            else
            {
                Console.WriteLine("Material already exists");
            }
            Console.ReadKey();
        }
        // Handles the addition of a new material supply.
        public static void AddNewMaterialSupply()
        {
            if (materialsList.Count > 0)
            {
                Console.Clear();
                UIManager.ClearAndShowTitle("Add New Material Supply");
                foreach (Material obj in materialsList)
                {
                    obj.ToString(materialSuppliesList);
                }
                Console.WriteLine("=======================================================");
                double value;
                double quantity;
                Console.WriteLine("Please enter the name of the material you've purchased:");
                string name = Console.ReadLine();
                while (!utils.MaterialInList(materialsList, name))
                {
                    Console.WriteLine("Please enter a valid name for the material you've purchased:");
                    name = Console.ReadLine();
                }

                Console.WriteLine("Please enter the price you paid for the materials:");
                string userInput = Console.ReadLine().ToUpper().Replace('R', ' ');
                while (!double.TryParse(userInput, out value))
                {
                    Console.WriteLine("Please enter the price you paid for the materials in the format 'R00,00':");
                    userInput = Console.ReadLine().ToUpper().Replace('R', ' ');
                }

                Console.WriteLine("Please enter the weight in tonnes of the material you purchased:");
                userInput = Console.ReadLine();
                while (!double.TryParse(userInput, out quantity))
                {
                    Console.WriteLine("Please enter the weight in tonnes of the material you purchased: in the format '00,00':");
                    userInput = Console.ReadLine();
                }

                MaterialSupply TempObj = new MaterialSupply(name, value, quantity, materialSuppliesList);
                materialSuppliesList.Add(TempObj);
                materialsList[(utils.MaterialIndex(materialsList, name))].AddSupply(materialSuppliesList.Count);


                Console.WriteLine("Supplies successfully added");
                Console.ReadKey();
            }
        }
        // Handles logging the usage of a material and updates supply levels.
        public static void LogMaterialUsage()
        {
            if (materialsList.Count > 0)
            {
                UIManager.ClearAndShowTitle("Log Material Usage");

                int materialNumber = -1;
                int count = 1;
                foreach (var LI in materialsList)
                {
                    Console.WriteLine(count + ":  " + LI.MaterialName + "\t" + utils.MaterialSupply(LI.GetSupplyIDs(), materialSuppliesList) + " tonnes");
                    count++;
                }

                Console.WriteLine("Enter the name of the material used:");
                string material = Console.ReadLine();
                while (!utils.MaterialInList(materialsList, material) && (!int.TryParse(material, out materialNumber) || materialNumber <= 0 || materialNumber > count))
                {
                    Console.WriteLine("Please enter a valid material name:");
                    material = Console.ReadLine();
                }

                if (int.TryParse(material, out materialNumber))
                {
                    material = materialsList[materialNumber - 1].MaterialName;
                }

                Console.WriteLine("Please enter the weight in tonnes of the material you used:");
                string userInput = Console.ReadLine();
                double quantity;
                while (!double.TryParse(userInput, out quantity))
                {
                    Console.WriteLine("Please enter the weight in tonnes of the material you used: in the format '00,00':");
                    userInput = Console.ReadLine();
                }

                IList<int> Supplies = materialsList[(utils.MaterialIndex(materialsList, material))].GetSupplyIDs();

                if (utils.MaterialSupply(Supplies, materialSuppliesList) >= quantity)
                {
                    foreach (int supplyID in Supplies)
                    {
                        if (materialSuppliesList[supplyID - 1].Stock > 0)
                        {
                            double stock = materialSuppliesList[supplyID - 1].Stock;
                            if (stock > quantity)
                            {
                                materialSuppliesList[supplyID - 1].UseMaterial(quantity);
                                quantity = 0;
                                break;
                            }
                            else
                            {
                                materialSuppliesList[supplyID - 1].UseMaterial(stock);
                                quantity -= stock;
                            }
                        }
                    }
                }
                if (quantity == 0)
                {
                    Console.WriteLine("Supply levels updated");
                }
                else
                {
                    Console.WriteLine($"Not enough material in stock. please order at least {quantity - utils.MaterialSupply(Supplies, materialSuppliesList)} tonnes more {material}");
                }

                Console.ReadKey();

            }
        }

        // Displays all materials and their stock/cost details.
        public static void MaterialsData()
        {
            Console.Clear();
            UIManager.ClearAndShowTitle("Materials Data");
            foreach (var LI in materialsList)
            {
                LI.ToString(materialSuppliesList);
            }
            Console.WriteLine("================================================");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        // Displays all blends and their details.
        public static void BlendsData() 
        {
            UIManager.ClearAndShowTitle("Blends Data");
            int count = 1;
            foreach(var LI in blendList)
            {
                IDictionary<string,double> Materialstores = LI.BlendStores(materialsList, materialSuppliesList,out string BindingMat,out double TotalAvailable);
                Console.WriteLine($"{count}:  {LI.Name}\n\tTotal Produceable: {TotalAvailable} tonnes\n\tLimiting Material: {BindingMat}\n\t Price Per Tonne: R{LI.PricePerTonne(materialsList,materialSuppliesList)}");
                count += 1;
            }
        }
        // enables the user to create a new machine object
        public static void CreateMachine()
        {
            Console.Clear();

            UIManager.ClearAndShowTitle("Machine Management");
            Console.WriteLine("=====================================================================================================");

            foreach (Machine obj in machineList)
            {
                Console.WriteLine($"{obj.MachineID}: {obj.MachineDetails}\n");
            }

            Console.WriteLine("=====================================================================================================");


            Console.WriteLine("Please input the description of the machine then press 'Enter' to continue");
            Machine tempObj = new Machine(machineList,Console.ReadLine());
            machineList.Add(tempObj);
            Console.WriteLine("New machine added. press any key to continue");
            Console.ReadKey();
        }
        
        public static void FormatException()
    {
     throw new CustomException("Invalid input. Please enter a valid numeric Product ID.");
     }

        public static void ArgumentException()
        {
            throw new CustomException("The Product ID does not exist or the product is already sold.");
        }
//denotes the sale of a product
        public static void SellProduct()
 {

            if (productList.Where(p => p.Sold == false).OrderBy(p => p.ManufactureDate).Count() > 0)
            {

                Console.Clear();
                Console.WriteLine("=====================================================================================================");

                // Show only unsold products, ordered by date
                foreach (Product obj in productList.Where(p => p.Sold == false).OrderBy(p => p.ManufactureDate))
                {
                    Console.WriteLine($"Product ID : {obj.ProductID}" +
                                      $"\n\tBlend: {blendList[obj.BlendID].Name}" +
                                      $"\n\tDate of manufacture: {obj.ManufactureDate}" +
                                      $"\n\tLast recorded weight: {obj.weight}");
                }

                Console.WriteLine("=====================================================================================================");

                try
                {
                //    int PointerTop;
                    int ProductID;
                    Console.WriteLine("\n Please enter the Product ID number that you are updating");
                    //while (!int.TryParse(Console.ReadLine(), out ProductID) || ProductID < 0 || ProductID > productList.Count)
                    //{
                    //    PointerTop = Console.CursorTop;

                    //    Console.SetCursorPosition(0, PointerTop - 2);
                    //    Console.Write(new string(' ', Console.WindowWidth));
                    //    Console.SetCursorPosition(0, (PointerTop - 1));
                    //    Console.Write(new string(' ', Console.WindowWidth));
                    //    Console.SetCursorPosition(0, PointerTop - 2);

                    //    Console.WriteLine("Please enter a valid number that represents a product ID");
                    //}

                    // Read and parse product ID
                    if (!int.TryParse(Console.ReadLine(), out ProductID))
                    {
                        FormatException();
                    }

                    // Validate if ProductID exists in the product list
                    Product selectedProduct = productList.FirstOrDefault(p => p.ProductID == ProductID && !p.Sold);

                    if (selectedProduct == null)
                    {
                        ArgumentException();
                    }

                    // Update the product status
                    selectedProduct.Sold = true;

                    Console.WriteLine("Product status successfully updated!");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Input Error: {ex.Message}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Validation Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    // Catch any unexpected error
                    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("\nPress any key to return...");
                    Console.ReadKey();
                }
            }
 }

        // Main entry point: runs the main application loop and handles menu navigation.
        static void Main(string[] args)
        {
            TestDataLoad();
            UIManager.DisplayTitle();
            
            Thread alertsThread = new Thread(ThreadErrorAlerts);
            alertsThread.Start();

            do
            {
                switch(LoadMainMenu())
                {
                    case 1:
                        do
                        {
                            switch (LoadMaterialManagementMenu())
                            {
                                case 1:
                                    CreateNewBlend();
                                    break;
                                case 2:
                                    AddNewMaterialSupply();
                                    break;
                                case 3:
                                    CreateNewMaterial();
                                    break;
                                case 4:
                                    LogMaterialUsage();
                                    break;
                                case 5:
                                    MaterialsData();
                                    break;
                                case 6:
                                    BlendsData();
                                    Console.ReadKey();
                                    break;
                                case 7:
                                    CreateMachine();
                                    break;
                                case 8:
                                    userInput = MaterialmanagementMenuInOptions() + 1;
                                    break;
                                default:
                                    break;
                            }
                        } while (userInput != MaterialmanagementMenuInOptions() + 1);
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
                                    DisplayProducts();
                                    break;
                                case 4:
                                    SellProduct();
                                    break;
                                case 5:
                                    userInput = ProductionManagementInOptions() + 1;
                                    break;
                                default :
                                    break;
                            }
                        }while (userInput != ProductionManagementInOptions() + 1);
                    break;
                    case 3:
                        AlertsObject.AlertUser(materialSuppliesList);
                    break;
                    case 4:
                        alertsThread.Abort();
                        Environment.Exit(0);
                        break;
                    default:
                    break;
                }
                AlertsObject.AlertUser(materialSuppliesList);
            } while (true);
        }

        // Background thread for monitoring material stock and alerting the user if levels are low.
        static void ThreadErrorAlerts()
        {
            while (true)
            {
                Events tempAlertsObj = new Events();

                
                foreach (Material obj in materialsList)
                {
                    if (productList.Count > 0)
                    {
                        List<Product> tempListProducts = (List<Product>)productList.Where(p => p.ManufactureDate > DateTime.Now.AddDays(-1214)).Where(p => blendList[p.BlendID].MaterialIDs(materialsList).Contains(obj.MaterialID)).ToList();
                        if (tempListProducts.Count > 0)
                        {
                            double averageRatio = 1.1 * tempListProducts.Average(p => blendList[p.BlendID].MaterialCompositionPercent(obj.MaterialName));
                            double ThreashOldValue = averageRatio * tempListProducts.Average(p => p.InitialWeight) / 100;

                            if (utils.MaterialSupply(obj.GetSupplyIDs(), materialSuppliesList) < ThreashOldValue)
                            {
                                //run event that informs the user that they should order more material of the selected type
                                // if they do not order new material add it to the list of notified materials as to not repeatedly order new material 
                                tempAlertsObj.Alert += obj.AlertUser;
                            }
                        }
                    }

                }
                AlertsObject=tempAlertsObj;
                Thread.Sleep(10000);
            }
        }

        //adds data for display and testing purposes
        static void TestDataLoad()
        {
            Machine tempMachine = new Machine(machineList,"Big Rig- Extruder No: 01");
            machineList.Add(tempMachine);
            tempMachine = new Machine(machineList, "Small Rig- Bag Cutter No: 03");
            machineList.Add(tempMachine);
            tempMachine = new Machine(machineList, "Small Rig- Finisher No: 0100");
            machineList.Add(tempMachine);

            Material tempMaterial = new Material("PVC", materialsList,new List<int> { 1,2 });
            materialsList.Add(tempMaterial);
             tempMaterial = new Material("HTTP", materialsList, new List<int> {3,4,5});
            materialsList.Add(tempMaterial);
             tempMaterial = new Material("Urathaine", materialsList, new List<int> { 6, 7 });
            materialsList.Add(tempMaterial);

            string[,] tempArray = new string[1, 2] { {"PVC", "100"}};
            Blend tempBlend = new Blend("PVC_01", blendList, tempArray);
            blendList.Add(tempBlend);

            tempArray = new string[2, 2] { { "PVC", "50" },{"HTTP","50" } };
            tempBlend = new Blend("HTTP_01", blendList, tempArray);
            blendList.Add(tempBlend);


            tempArray = new string[3, 2] { { "PVC", "20" },{"HTTP","40"},{ "Urathaine","40"} };
            tempBlend = new Blend("HouseBlend_01", blendList, tempArray);
            blendList.Add(tempBlend);

            MaterialSupply tempSupply = new MaterialSupply("PVC", 1000, 4, materialSuppliesList);
            materialSuppliesList.Add(tempSupply);

            tempSupply = new MaterialSupply("PVC", 5000, 18, materialSuppliesList);
            materialSuppliesList.Add(tempSupply);

            tempSupply = new MaterialSupply("HTTP", 1000, 2, materialSuppliesList);
            materialSuppliesList.Add(tempSupply);

            tempSupply = new MaterialSupply("HTTP", 500, 0.5, materialSuppliesList);
            materialSuppliesList.Add(tempSupply);

            tempSupply = new MaterialSupply("HTTP", 800, 4, materialSuppliesList);
            materialSuppliesList.Add(tempSupply);

            tempSupply = new MaterialSupply("Urathaine", 2000, 4, materialSuppliesList);
            materialSuppliesList.Add(tempSupply);

            tempSupply = new MaterialSupply("Urathaine", 1000, 3, materialSuppliesList);
            materialSuppliesList.Add(tempSupply);
        }
    }
}
