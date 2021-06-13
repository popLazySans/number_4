using System;

namespace Last4
{
    class Program
    {
        struct city
        {
            public int numBer;
            public string name;
            public int infected;
            public int[]link;
            public bool spread;
        }
      
        static void Main(string[] args)
        {
            
           int numberOfCity = int.Parse(Console.ReadLine());
           city[] cityList = new city[numberOfCity];
           for (int i = 0; i < numberOfCity; i++)
           {
                cityList[i].numBer = i;
                cityList[i].name = Console.ReadLine();
                cityList[i].infected = 0;
                cityList[i].link = new int[int.Parse(Console.ReadLine())];
                cityList[i].spread = false;
                for (int j = 0;j<cityList[i].link.Length;j++)
                {
                    cityList[i].link[j] = int.Parse(Console.ReadLine());
                    for(int k = 0; k < j; k++)
                    {
                        if(cityList[i].link[j] == cityList[i].link[k]|| cityList[i].link[j] == cityList[i].numBer|| cityList[i].link[j]>numberOfCity)
                        {
                            Console.WriteLine("Invalid ID");
                            j = j - 1;
                            break;
                        }
                    }
                }
                
           }
           for(int y = 0; y < numberOfCity; y++)
            {
                ReadCity(cityList[y]);
            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Outbreak")
                {
                    int target = int.Parse(Console.ReadLine());
                    cityList[target].infected += 2;
                    if (cityList[target].infected>3)
                    {
                        cityList[target].infected = 3;
                    }
                    for (int n = 0;n<cityList[target].link.Length;n++)
                    {
                        cityList[cityList[target].link[n]].infected += 1;
                        if(cityList[cityList[target].link[n]].infected > 3)
                        {
                            cityList[cityList[target].link[n]].infected = 3;
                        }
                    }
                    for (int y = 0; y < numberOfCity; y++)
                    {
                        ReadCity(cityList[y]);
                    }
                }
                else if (command == "Vaccinate")
                {
                    int target = int.Parse(Console.ReadLine());
                    cityList[target].infected = 0;
                    for (int y = 0; y < numberOfCity; y++)
                    {
                        ReadCity(cityList[y]);
                    }
                }
                else if (command == "Lock down")
                {
                    int target = int.Parse(Console.ReadLine());
                    cityList[target].infected -= 1;
                    if (cityList[target].infected < 0)
                    {
                        cityList[target].infected = 0;
                    }
                    for (int n = 0; n < cityList[target].link.Length; n++)
                    {
                        cityList[cityList[target].link[n]].infected -= 1;
                        if (cityList[cityList[target].link[n]].infected < 0)
                        {
                            cityList[cityList[target].link[n]].infected = 0;
                        }
                    }
                    for (int y = 0; y < numberOfCity; y++)
                    {
                        ReadCity(cityList[y]);
                    }
                }
                else if (command == "Spread")
                {
                   
                    for(int s = 0; s < numberOfCity; s++)
                    {
                        for(int p = 0;p<cityList[s].link.Length;p++)
                        if (cityList[s].infected<cityList[cityList[s].link[p]].infected)
                        {
                                cityList[s].spread = true;
                        }
                    }
                    for(int s = 0; s < numberOfCity; s++)
                    {
                        if(cityList[s].spread == true)
                        {
                            cityList[s].infected += 1;
                            if (cityList[s].infected >3)
                            {
                                cityList[s].infected = 3;
                            }
                        }
                    }
                    for (int y = 0; y < numberOfCity; y++)
                    {
                        ReadCity(cityList[y]);
                    }
                }
                else if (command == "Exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
        }
        static void ReadCity(city c)
        {
            Console.Write(c.numBer+" ");
            Console.Write(c.name+ " ");
            Console.WriteLine(c.infected+ " ");
            
            /*for(int i = 0; i < c.link.Length; i++)
            {
                Console.Write(c.link[i]+" ");
            }*/
        }
    }
}
