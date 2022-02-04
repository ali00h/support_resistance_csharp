using System;
using System.Collections.Generic;

namespace support_resistance_csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            if(args.Length > 0){
                DatasetReader fileReader = new DatasetReader("dataset",args[0]);
                List<double> line_data = fileReader.Read();

                SupportResistanceCalculator src = new SupportResistanceCalculator(line_data);
                Console.WriteLine("support1: " + src.support1);
                Console.WriteLine("support2: " + src.support2);
                Console.WriteLine("resistance1: " + src.resistance1);
                Console.WriteLine("resistance2: " + src.resistance2);
            }else{
                Console.WriteLine("Error: args not valid. please enter like: dotnet run sample1.txt");
            }
        }
    }
}
