using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Superthene
{
    internal class Blend
    {
        private string[,] _blendMix;
        private string _name;
        private int _blendCode=-1;

        public int BlendCode { get { return _blendCode; } }
        public Blend(string name)
        {
            _name = name;
        }

        public virtual void CreateCode(List<Blend> blendList)
        {
            if (_blendCode==-1) 
            {
                _blendCode = blendList.Count(); 
            }
        }

        public virtual void DetermineBlend()
        { int numberOfMatierials;
            string matierialName;
            double PecentComposition;

            Console.WriteLine("enter the number of matierials in the blend:");
            while (int.TryParse(Console.ReadLine(), out numberOfMatierials))
            {
                Console.WriteLine("enter the number of matierials in the blend:");
            }
            _blendMix = new string[numberOfMatierials,2];
            for (int i = 0; i < numberOfMatierials; i++)
            {
                Console.WriteLine("Please enter the nanme of the matierial");
                matierialName = Console.ReadLine();
                Console.WriteLine("please enter the percent of this blend that this matierial makes up:");
                while (double.TryParse(Console.ReadLine(), out PecentComposition))
                {
                    Console.WriteLine("please enter the percent of this blend that this matierial makes up:");
                }
                _blendMix[i, 0] = matierialName;
                _blendMix[i, 1] = PecentComposition.ToString();
            }
        }
    }
}
