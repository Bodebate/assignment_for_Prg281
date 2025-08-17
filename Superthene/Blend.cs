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

        public virtual void DetermineBlend(IList<Material> materialList)
        {
            int numberOfMaterials;
            string materialName;
            double PecentComposition;

            Console.WriteLine("Enter the number of materials in the blend:");

            while (!int.TryParse(Console.ReadLine(), out numberOfMaterials) || numberOfMaterials> materialList.Count())
            {
                Console.WriteLine("Enter a valid number of materials for the blend:");
            }

            _blendMix = new string[numberOfMaterials, 2];

            for (int i = 0; i < numberOfMaterials; i++)
            {
                Console.WriteLine("Please enter the name of the material "+(i+1));
                materialName = Console.ReadLine();

                while (!MaterialInList(materialList, materialName))
                {
                    Console.WriteLine("Please enter a valid material name");
                    materialName = Console.ReadLine();
                }

                Console.WriteLine($"Please enter the percent of this blend that {materialName.ToUpper()} makes up:");

                while (!double.TryParse(Console.ReadLine(), out PecentComposition))
                {
                    Console.WriteLine($"Please enter a valid percent of this blend that {materialName.ToUpper()} could make up:");
                }

                _blendMix[i, 0] = materialName;
                _blendMix[i, 1] = PecentComposition.ToString();
            }
        }

        public virtual IDictionary<string, double> BlendStores(IList<Material> matList, IList<MaterialSupply> supplies, out string BindingMatierial)
        {
            IDictionary<string, double> OutDict = new Dictionary<string, double>();
            BindingMatierial = null;
            double BindingValue = 100000000000;

            for (int i = 0; i < _blendMix.Length / 2; i++)
            {
                string MatierialName = _blendMix[i, 0];
                double MatierialPercent = double.Parse(_blendMix[i, 1]);
                double TotalMatStored = MaterialSupply(matList[MaterialIndex(matList, MatierialName)].GetSupplyIDs(), supplies);

                OutDict.Add(MatierialName, TotalMatStored);

                if (BindingValue > TotalMatStored / MatierialPercent)
                {
                    BindingMatierial = MatierialName;
                    BindingValue = TotalMatStored / MatierialPercent;
                }
            }

            return OutDict;
        }

        public virtual IDictionary<string, double> BlendStores(IList<Material> matList, IList<MaterialSupply> supplies)
        {
            IDictionary<string, double> OutDict = new Dictionary<string, double>();

            for (int i = 0; i < _blendMix.Length / 2; i++)
            {
                string MatierialName = _blendMix[i, 0];
                double MatierialPercent = double.Parse(_blendMix[i, 1]);
                double TotalMatStored = MaterialSupply(matList[MaterialIndex(matList, MatierialName)].GetSupplyIDs(), supplies);

                OutDict.Add(MatierialName, TotalMatStored);
            }

            return OutDict;
        }

        public virtual IDictionary<string, double> BlendStores(IList<Material> matList, IList<MaterialSupply> supplies, out string BindingMatierial, out double TotalAvailable)
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
                double TotalMatStored = MaterialSupply(matList[MaterialIndex(matList, MatierialName)].GetSupplyIDs(), supplies);

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

        public virtual Double PricePerTonne(IList<Material> matList, IList<MaterialSupply> supplies)
        {
            double CostPerTonne = 0;
            double Ratio = 0;

            for (int i = 0; i < _blendMix.Length / 2; i++)
            {
                Double Temp = MaterialCostPerTonne(matList[MaterialIndex(matList, _blendMix[i, 0])].GetSupplyIDs(), supplies);
                Temp = Temp * double.Parse(_blendMix[i, 1]);
                CostPerTonne += Temp;
                Ratio += double.Parse(_blendMix[i, 1]);
            }
            if (Ratio > 0) { return CostPerTonne / Ratio; }
            else { return 0; }

        }
        public virtual Double TotalMatUsed(IList<Material> matList, IList<MaterialSupply> supplies, double weight,string MatierialName)
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
        public virtual int[] MaterialIDs(IList<Material> matList)
        {
            int[] outarray = new int[_blendMix.Length / 2];
            for (int i = 0; i < _blendMix.Length / 2; i++)
            {
                outarray[i] = MaterialIndex(matList, _blendMix[i, 0]);
            }
            return outarray;
        }
        public virtual double MaterialCompositionPercent(string materialName)
        {
            double result = 0;

            for (int i = 0; i < _blendMix.Length / 2; i++)
            {
                if (_blendMix[i,0].ToUpper()== materialName.ToUpper())
                {
                    result += double.Parse(_blendMix[i, 1]);
                }
            }

            return result;
        }
    }
}
