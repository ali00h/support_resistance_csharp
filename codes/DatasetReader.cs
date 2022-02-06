using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace support_resistance_csharp
{
    public class DatasetReader
    {
        private string directoryPath;
        private string fileName;
        public DatasetReader(string directoryPath,string fileName){
            this.directoryPath = directoryPath;
            this.fileName = fileName;
        }

        public List<double> Read(){
            List<double> result = new List<double>();
            int counter = 0;  
  
            // Read the file and display it line by line.  
            foreach (string line in File.ReadLines(directoryPath + @"\" + fileName))
            {  
                if(line.All(char.IsDigit)){
                    result.Add(Convert.ToDouble(line));
                }
                counter++;  
            }  
            return result;
        }

    }
}
