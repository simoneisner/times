﻿using System;
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


            ////expecting 9:30 - 10
            //ListA.Add(new DateRange("9:00", "10:00"));
            //ListB.Add(new DateRange("9:00", "9:30"));
            //BuildLists(ListA, ListB);
            //ListA.Clear();
            //ListB.Clear();


            ////expecting empty string
            //ListA.Add(new DateRange("9:00", "10:00"));
            //ListB.Add(new DateRange("9:00", "10:00"));
            //BuildLists(ListA, ListB);
            //ListA.Clear();
            //ListB.Clear();



            ////expecting 9:00 - 9:30
            //ListA.Add(new DateRange("9:00", "9:30"));
            //ListB.Add(new DateRange("9:30", "15:00"));
            //BuildLists(ListA, ListB);
            //ListA.Clear();
            //ListB.Clear();

            ////expecting 9:00-9:15, 10:15-10:30
            //ListA.Add(new DateRange("9:00", "9:30"));
            //ListA.Add(new DateRange("10:00", "10:30"));
            //ListB.Add(new DateRange("9:15", "10:15"));
            //BuildLists(ListA, ListB);
            //ListA.Clear();
            //ListB.Clear();

            //expecting 9:15-10:00, 10:15-11:00
            ListA.Add(new DateRange("9:00", "11:00"));
            ListA.Add(new DateRange("13:00", "15:00"));
            ListB.Add(new DateRange("9:00", "9:15"));
            ListB.Add(new DateRange("10:00", "10:15"));
            ListB.Add(new DateRange("12:30", "16:00"));
            BuildLists(ListA, ListB);
            ListA.Clear();
            ListB.Clear();

            Console.ReadLine();
        }

        private static void BuildLists(List<DateRange> ListA, List<DateRange> ListB)
        {
            List<DateRange> Difference = new List<DateRange>();
            DateTime diffStart = new DateTime();
            DateTime diffEnd = new DateTime();

            foreach (DateRange drA in ListA)
            {
                //diffStart = drB.Start;
                //diffEnd = drB.End;
                diffStart = drA.Start;
                diffEnd = drA.End;

                foreach (DateRange drB in ListB)
                {
                    //IF DEALING WITH TWO OF THE SAME DATES
                    if (drA.Start == drB.Start && drA.End == drB.End)
                    {
                        Difference.Add(new DateRange(new DateTime().ToString(), new DateTime().ToString()));
                        break;
                    }

                    if (drA.Start < drB.Start)
                    {
                        diffStart = drA.Start;
                    }

                    else if (drB.End < drA.End)
                    {
                        diffStart = drB.End;
                        diffEnd = drA.End;
                    }


                    if (drA.End > drB.End)
                    {
                        diffEnd = drA.End;
                    }

                    if (drA.Start < drB.Start && drB.Start <= diffEnd)
                    {
                        diffEnd = drB.Start;
                    }

                    Difference.Add(new DateRange(diffStart.ToString(), diffEnd.ToString()));
                }

            }


            foreach (DateRange dr in Difference)
            {
                StringBuilder sb = new StringBuilder();

                if (dr.Dates[0].ToString() == "1/1/0001 12:00:00 AM")
                {
                    sb.Append("()");
                }


                else if (dr.Start.ToString() != string.Empty && dr.End.ToString() != string.Empty)
                {
                    sb.Append("(");
                    sb.Append(dr.Start.TimeOfDay);
                    sb.Append(" - ");
                    sb.Append(dr.End.TimeOfDay);
                    sb.Append(")");
                }
                Console.WriteLine(sb);
                Console.WriteLine();
            }


        }
    }
}
