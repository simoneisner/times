using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using times_compare.Helpers;

namespace times_compare
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DateRange> ListA = new List<DateRange>();
            List<DateRange> ListB = new List<DateRange>();
            List<DateRange> Difference = new List<DateRange>();

            ListA.Add(new DateRange("9:00", "10:00"));
            ListB.Add(new DateRange("9:00", "9:30"));

            
            foreach (DateRange drA in ListA)
            {

                foreach(DateRange drB in ListB)
                {
                    DateRange drDiff = new DateRange();
                    DateTime diffStart = new DateTime();
                    DateTime diffEnd = new DateTime();

                    diffStart = drB.Start;
                    if (drA.Start < drB.Start)
                    {
                        diffStart = drA.Start;
                    }

                    diffEnd = drB.End;
                    if(drA.End > drB.End)
                    {
                        diffEnd = drA.End;
                    }

                    Difference.Add(new DateRange(diffStart.ToString(), diffEnd.ToString()));
                }
                
            }


            foreach(DateRange dr in Difference)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(dr.Start.Hour);
                sb.Append(":");
                sb.Append(dr.Start.Minute);
                sb.Append(" - ");
                sb.Append(dr.End.Hour);
                sb.Append(":");
                sb.Append(dr.End.Minute);
                Console.WriteLine(sb.ToString());
            }

           

            Console.ReadLine();
            
            
        }
    }
}
