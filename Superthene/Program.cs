using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Superthene
{
    internal class Program
    {
        enum MainMenu
        {
            Create_new_blend____ = 1,
            Log_matierials_order,
            Create_new_matierial,
            Exit________________
        }

        public static int userInput = -1;
        public static int LoadMainMenu()
        {
            int counter = 0;
            Console.Clear();

            foreach (string Option in Enum.GetNames(typeof(MainMenu)))
            {
                Console.WriteLine(counter++ + Option.Replace('_',' '));
                while(!int.TryParse(Console.ReadLine(),out userInput))
                {
                    Console.WriteLine("please input a valid option");
                }
            }

            return userInput;
        }
        static void Main(string[] args)
        {
            do
            {
                switch(LoadMainMenu())
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:
                        
                        break;
                    default:
                        break;
                }
            } while (userInput != 99);
        }
    }
}
