using System;
using System.Collections.Generic;
using System.Linq;

namespace Superthene
{
    internal class Blend : Utilities
    {
        private string[,] _blendMix;
        private string _name;
        private int _blendCode = -1;

        public int BlendCode { get { return _blendCode; } }
        public string Name { get { return _name; } }

        public Blend(string name, List<Blend> blendList)
        {
            _name = name;
            _blendCode = blendList.Count();

        }

        public virtual void DetermineBlend(List<Matierial> matierialList)
        {
            int numberOfMatierials;
            string matierialName;
            double PecentComposition;

            Console.WriteLine("enter the number of matierials in the blend:");

            while (!int.TryParse(Console.ReadLine(), out numberOfMatierials))
            {
                Console.WriteLine("enter the number of matierials in the blend:");
            }

            _blendMix = new string[numberOfMatierials, 2];

            for (int i = 0; i < numberOfMatierials; i++)
            {
                Console.WriteLine("Please enter the name of the matierial");
                matierialName = Console.ReadLine();

                while (!MatierialInList(matierialList, matierialName))
                {
                    Console.WriteLine("Please enter a valid matierial name");
                    matierialName = Console.ReadLine();
                }

                Console.WriteLine("please enter the percent of this blend that this matierial makes up:");

                while (!double.TryParse(Console.ReadLine(), out PecentComposition))
                {
                    Console.WriteLine("please enter the percent of this blend that this matierial makes up:");
                }

                _blendMix[i, 0] = matierialName;
                _blendMix[i, 1] = PecentComposition.ToString();
            }
        }
    }
}
