using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace WebAppSumm.Models
{       
        //--.
        public interface IOperator
        {
            double Add(double p1, double p2);
        }
       
        //--.
        public class Operation : IOperator
        {
            public double Add(double p1, double p2) => p1 + p2;

        }
        
        //--.
        public class Operation48 : IOperator
        {
            public double Add(double p1, double p2) => p1 + p2 + 48;

        }
}
