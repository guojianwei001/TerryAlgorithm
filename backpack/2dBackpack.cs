using System;
using System.Collections.Generic;
using System.Text;

namespace TerryAlgorithm
{
    /*
A:3  36 120
B:10 25 129
C:5  50 250
D:1  45 130
E:4  20 119

tartget: 5, 60
         */

    public class Cylinder
    {
        public Cylinder(int w1, int w2, int totalWeight)
        {
            Weight1 = w1;
            Weight2 = w2;
            TotalWeight = totalWeight;
        }

        public int Weight1 { get; set; }

        public int Weight2 { get; set; }

        public int TotalWeight { get; set; }
    }

    partial class Program
    {
        public static List<Cylinder> cylinders = new List<Cylinder>
        {
            new Cylinder(3,36,120),
            new Cylinder(10,25,129),
            new Cylinder(5,50,250),
            new Cylinder(1,45,130),
            new Cylinder(4,20,119)
        };

        public static int[,,] dpArray = new int[5, 10, 61];

        public static int minimumWeight(int oxygen, int nitrogen)
        {
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < 61; k++)
                {
                    if (cylinders[4].Weight1 >= j && cylinders[4].Weight2 >= k)
                    {
                        dpArray[0, j, k] = cylinders[4].TotalWeight;
                    }
                    else
                    {
                        dpArray[0, j, k] = -1;
                    }
                }
            }

            for (int i = 1; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    for (int k = 0; k < 61; k++)
                    {
                        var weight1 = cylinders[4 - i].Weight1;
                        var weight2 = cylinders[4 - i].Weight2;
                        var totalWeight = cylinders[4 - i].TotalWeight;

                        if (j - weight1 >= 0 && k - weight2 >= 0)
                        {
                            if (dpArray[i - 1, j, k] >= 0)
                            {
                                dpArray[i, j, k] = Math.Min(dpArray[i - 1, j, k], dpArray[i - 1, j - weight1, k - weight2] + totalWeight);
                            }
                            else
                            {
                                dpArray[i, j, k] = dpArray[i - 1, j - weight1, k - weight2] + totalWeight;
                            }
                        }

                        if (j - weight1 >= 0 && k - weight2 >= 0)
                        {
                            if (dpArray[i - 1, j, k] >= 0)
                            {
                                dpArray[i, j, k] = Math.Min(dpArray[i - 1, j, k], dpArray[i - 1, j - weight1, k - weight2] + totalWeight);
                            }
                            else
                            {
                                dpArray[i, j, k] = dpArray[i - 1, j - weight1, k - weight2] + totalWeight;
                            }
                        }
                        else
                        {
                            dpArray[i, j, k] = dpArray[i - 1, j, k];
                        }
                    }
                }
            }

            Console.WriteLine(dpArray[4, 5, 60]);

            return 0;
        }
    }
}