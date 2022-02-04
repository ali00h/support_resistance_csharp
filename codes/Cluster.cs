using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace support_resistance_csharp
{
    class Cluster:List<PointList>
    {
        private bool isDown = false;

        public Cluster(bool isDown){
            this.isDown = isDown;            
        }

        public void Add(Point point){
            PointList list = new PointList(this.isDown);
            list.Add(point);
            this.Add(list);
        }
        
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            
            result.Append(Environment.NewLine);
            result.Append("--------------------Cluster--------------------");
            result.Append(Environment.NewLine);

            foreach(var pointlist in this){
                foreach(var point in pointlist){
                    result.Append(point.value);
                    result.Append(" ");
                }
                result.Append(" => ");
                result.Append(pointlist.Result);
                result.Append(Environment.NewLine);
            }

            result.Append("-----------------------------------------------");
            result.Append(Environment.NewLine);

            return result.ToString();
        }
        
        public void Clustering(Point point,double insignificantValue){
            bool isAdded = false;
            for(int i=0 ; i < this.Count ; i++){
                PointList item = this[i];
                isAdded = item.Clustering(point, insignificantValue);
            }
            if(!isAdded){
                this.Add(point);
            }            
        }    

        public List<double> getBest(){
            List<PointList> suggested = this.OrderByDescending(x=>x.Count).ToList();
            List<double> result = new List<double>();
            if(suggested.Count > 0)
                result.Add(suggested[0].Result);
            if(suggested.Count > 1 && suggested[0].Count-1 <= suggested[1].Count && suggested[1].Count > 1)
                result.Add(suggested[1].Result);

            if(this.isDown)    
                return result.OrderByDescending(x=>x).ToList();
            else
                return result.OrderBy(x=>x).ToList();
        }

 
    }
}
