using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace support_resistance_csharp
{
    public class SupportResistanceCalculator
    {
        public bool debug = false;
        private List<Double> line;
        private Cluster SupportList = new Cluster(true);
        private Cluster ResistanceList = new Cluster(false);

        public double support1 {get;set;}
        public double support2 {get;set;}

        public double resistance1 {get;set;}
        public double resistance2 {get;set;}

        public SupportResistanceCalculator(List<Double> line){
            this.line = line;
            if(this.line.Count > 2)
                this.Calculate();
        }

        private void Calculate(){
            double minValue = this.line.Min();
            double maxValue = this.line.Max();
            double insignificantValue = (maxValue-minValue)/50;
            double currentValue = this.line[this.line.Count -1];
            PointList TopList = new PointList();
            PointList BottomList = new PointList();            
            for(int i=this.line.Count-2 ; i > 0 ; i--){
                if(this.line[i] < this.line[i+1] && this.line[i] <= this.line[i-1] && this.line[i] < currentValue)
                    BottomList.Add(this.line[i]);

                if(this.line[i] > this.line[i+1] && this.line[i] >= this.line[i-1] && this.line[i] > currentValue)
                    TopList.Add(this.line[i]);                
            }

            ShowMessage(currentValue.ToString());
            ShowMessage(insignificantValue.ToString());
            ShowMessage(TopList.ToString());
            ShowMessage(BottomList.ToString());

            foreach(var item in TopList){
                this.ResistanceList.Clustering(item,insignificantValue);
            }

            foreach(var item in BottomList){
                this.SupportList.Clustering(item,insignificantValue);
            }            
            
            ShowMessage(this.ResistanceList.ToString());       
            ShowMessage(this.SupportList.ToString());      

            ShowMessage(this.ResistanceList.getBest().ToString(" "));  
            ShowMessage(this.SupportList.getBest().ToString(" "));
            
            List<double> ResistanceNumbers = this.ResistanceList.getBest();
            List<double> SupportNumbers = this.SupportList.getBest();

            if(ResistanceNumbers.Count > 0) this.resistance1 = ResistanceNumbers[0];
            if(ResistanceNumbers.Count > 1) this.resistance2 = ResistanceNumbers[1];

            if(SupportNumbers.Count > 0) this.support1 = SupportNumbers[0];
            if(SupportNumbers.Count > 1) this.support2 = SupportNumbers[1];

            if(this.support1 == 0) this.support1 = currentValue;
            if(this.resistance1 == 0) this.resistance1 = currentValue;
        }

        private void ShowMessage(string msg){
            if(debug){
                Console.WriteLine(msg);
            }
        }

    }
}
