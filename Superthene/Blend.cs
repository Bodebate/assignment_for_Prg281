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

        public Blend(string name, IList<Blend> blendList)
        {
            _name = name;
            _blendCode = blendList.Count();

        }

        public virtual void DetermineBlend(IList<Matierial> matierialList)
        {
            int numberOfMatierials;
            string matierialName;
            double PecentComposition;

            Console.WriteLine("Enter the number of matierials in the blend:");

            while (!int.TryParse(Console.ReadLine(), out numberOfMatierials) || numberOfMatierials> matierialList.Count())
            {
                Console.WriteLine("Enter a valid number of matierials for the blend:");
            }

            _blendMix = new string[numberOfMatierials, 2];

            for (int i = 0; i < numberOfMatierials; i++)
            {
                Console.WriteLine("Please enter the name of the matierial "+i);
                matierialName = Console.ReadLine();

                while (!MatierialInList(matierialList, matierialName))
                {
                    Console.WriteLine("Please enter a valid matierial name");
                    matierialName = Console.ReadLine();
                }

                Console.WriteLine($"Please enter the percent of this blend that {matierialName} makes up:");

                while (!double.TryParse(Console.ReadLine(), out PecentComposition))
                {
                    Console.WriteLine($"Please enter a valid percent of this blend that {matierialName} could make up:");
                }

                _blendMix[i, 0] = matierialName;
                _blendMix[i, 1] = PecentComposition.ToString();
            }
        }

        public virtual IDictionary<string, double> BlendStores(IList<Matierial> matList, IList<MatierialSupply> supplies, out string BindingMatierial)
        {
            IDictionary<string, double> OutDict = new Dictionary<string, double>();
            BindingMatierial = null;
            double BindingValue = 100000000000;

            for (int i = 0; i < _blendMix.Length / 2; i++)
            {
                string MatierialName = _blendMix[i, 0];
                double MatierialPercent = double.Parse(_blendMix[i, 1]);
                double TotalMatStored = MatierialSupply(matList[MatierialIndex(matList, MatierialName)].GetSupplyIDs(), supplies);

                OutDict.Add(MatierialName, TotalMatStored);

                if (BindingValue > TotalMatStored / MatierialPercent)
                {
                    BindingMatierial = MatierialName;
                    BindingValue = TotalMatStored / MatierialPercent;
                }
            }

            return OutDict;
        }

        public virtual IDictionary<string, double> BlendStores(IList<Matierial> matList, IList<MatierialSupply> supplies)
        {
            IDictionary<string, double> OutDict = new Dictionary<string, double>();

            for (int i = 0; i < _blendMix.Length / 2; i++)
            {
                string MatierialName = _blendMix[i, 0];
                double MatierialPercent = double.Parse(_blendMix[i, 1]);
                double TotalMatStored = MatierialSupply(matList[MatierialIndex(matList, MatierialName)].GetSupplyIDs(), supplies);

                OutDict.Add(MatierialName, TotalMatStored);
            }

            return OutDict;
        }

        public virtual IDictionary<string, double> BlendStores(IList<Matierial> matList, IList<MatierialSupply> supplies, out string BindingMatierial, out double TotalAvailable)
        {
            IDictionary<string, double> OutDict = new Dictionary<string, double>();
            BindingMatierial = null;
            double BindingValue = 100000000000;
            double BindingQuantity = 0;
            double totalRatio = 0;
            double bindingPercent = 0;

            TotalAvailable = 0;
            for (int i = 0; i < _blendMix.Length / 2; i++)
            {
                string MatierialName = _blendMix[i, 0];
                double MatierialPercent = double.Parse(_blendMix[i, 1]);
                double TotalMatStored = MatierialSupply(matList[MatierialIndex(matList, MatierialName)].GetSupplyIDs(), supplies);

                OutDict.Add(MatierialName, TotalMatStored);

                totalRatio += MatierialPercent;

                if (BindingValue > TotalMatStored / MatierialPercent)
                {
                    BindingMatierial = MatierialName;
                    BindingValue = TotalMatStored / MatierialPercent;
                    BindingQuantity = TotalMatStored;
                    bindingPercent = MatierialPercent;
                }
            }
            if (totalRatio > 0 && bindingPercent > 0)
            {
                TotalAvailable = BindingQuantity * totalRatio / bindingPercent;
            }


            return OutDict;
        }

        public virtual Double PricePerTonne(IList<Matierial> matList, IList<MatierialSupply> supplies)
        {
            double CostPerTonne = 0;
            double Ratio = 0;

            for (int i = 0; i < _blendMix.Length / 2; i++)
            {
                Double Temp = MatierialCostPerTonne(matList[MatierialIndex(matList, _blendMix[i, 0])].GetSupplyIDs(), supplies);
                Temp = Temp * double.Parse(_blendMix[i, 1]);
                CostPerTonne += Temp;
                Ratio += double.Parse(_blendMix[i, 1]);
            }
            if (Ratio > 0) { return CostPerTonne / Ratio; }
            else { return 0; }

        }
        public virtual Double TotalMatUsed(IList<Matierial> matList, IList<MatierialSupply> supplies, double weight,string MatierialName)
        {
            double Ratio = 0;
            double MatierialRatio = 0;
            for (int i = 0; i < _blendMix.Length / 2; i++)
            {
                if (_blendMix[i,0].ToUpper()==MatierialName.ToUpper()) { MatierialRatio = double.Parse(_blendMix[i, 1]); }
                Ratio += double.Parse(_blendMix[i, 1]);
            }
            if(Ratio > 0) { return weight * MatierialRatio / Ratio; }
            else { return 0; }
        }
        public virtual int[] MatierialIDs(IList<Matierial> matList)
        {
            int[] outarray = new int[_blendMix.Length / 2];
            for (int i = 0; i < _blendMix.Length / 2; i++)
            {
                outarray[i] = MatierialIndex(matList, _blendMix[i, 0]);
            }
            return outarray;
        }
        public virtual double MatierialCompositionPercent(string MatierialName)
        {
            double result = 0;

            for (int i = 0; i < _blendMix.Length / 2; i++)
            {
                if (_blendMix[i,0].ToUpper()== MatierialName.ToUpper())
                {
                    result += double.Parse(_blendMix[i, 1]);
                }
            }

            return result;
        }
    }
}
