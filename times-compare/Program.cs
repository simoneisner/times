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


            //expecting 9:00 - 9:30
            //ListA.Add(new DateRange("9:00", "9:30"));
            //ListB.Add(new DateRange("9:30", "15:00"));

            //expecting empty string
            //ListA.Add(new DateRange("9:00", "10:00"));
            //ListB.Add(new DateRange("9:00", "10:00"));

            //expecting 9:30 - 10
            ListA.Add(new DateRange("9:00", "10:00"));
            ListB.Add(new DateRange("9:00", "9:30"));
            

            foreach (DateRange drA in ListA)
            {

                foreach(DateRange drB in ListB)
                {
                    DateTime diffStart = new DateTime();
                    DateTime diffEnd = new DateTime();

                    //diffStart = drB.Start;
                    //diffEnd = drB.End;
                    diffStart = drA.Start;
                    diffEnd = drA.End;

                    //IF DEALING WITH TWO OF THE SAME DATES
                    if(drA.Start == drB.Start && drA.End == drB.End){
                        Difference.Add(new DateRange(new DateTime().ToString(), new DateTime().ToString()));
                        break;
                    }

                    if (drA.Start < drB.Start)
                    {
                        diffStart = drA.Start;
                    }

                    else if(drB.End < drA.End)
                    {
                        diffStart = drB.End;
                        diffEnd = drA.End;
                        //break;
                    }


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

                if(dr.Dates[0].ToString() == "0001-01-01 12:00:00 AM"){
                    sb.Append(string.Empty);
                }


                else if (dr.Start.ToString() != string.Empty && dr.End.ToString() != string.Empty)
                {
                    sb.Append(dr.Start.TimeOfDay);
                    sb.Append(" - ");
                    sb.Append(dr.End.TimeOfDay);
                }
                Console.WriteLine(sb);
            }

           

            Console.ReadLine();
            
            
        }
    }
}
