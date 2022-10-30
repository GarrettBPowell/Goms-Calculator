﻿using System;
using System.Linq;
/*
* Press a Key or button for an average non-skilled typist (K) = .28 seconds
Point with a mouse (excluding click) OR scrolling (P) = 1.1 seconds
Mouse Click (C) = .4 seconds
Move Hands to keyboard from mouse (or vice-versa) (H) = .4 seconds
Mentally prepare (M) = 1.35 seconds
*/
namespace Goms_Calc
{
    class Program
    {
        public static double calcWords(int num)
        {
            return num * .28;
        }
        public static string toNum(string c)
        {
            switch(c)
            {
                case "K":
                    return "0.28";
                case "P":
                    return "1.1";
                case "C":
                    return "0.4";
                case "H":
                    return "0.4";
                case "M":
                    return "1.35";
                default:
                    return "(0.28 * " + c.Split("*").Last() + ")";
            }
        }
        static void Main(string[] args)
        {
            string input = "";
            string gomCommands = "";
            while (input.ToLower() != "exit")
            {
                // get input, break if exit
                Console.WriteLine("Enter the string of Interactions (type exit to stop): ");
                input = Console.ReadLine();
                if (input.ToLower().Equals("exit"))
                    break;

                // vars
                double totalTime = 0.0;
                bool first = true;
                string[] individual = input.Split(" + ");

                // loop through input and calc values
                foreach (string c in individual)
                {
                    // don't add + on first run
                    if (first)
                    {
                        gomCommands += toNum(c);
                        first = false;
                    }
                    else
                        gomCommands += (" + " + toNum(c));

                    // calc nums for k with or without * num
                    if (c.ToLower().StartsWith("k"))
                    {
                        if (c.Length > 1)
                        {
                            int count = Int32.Parse(c.Split("*").Last());
                            totalTime += calcWords(count);
                        }
                        else
                            totalTime += 0.28;
                    }
                    // calc other letters
                    else
                    {
                        switch (c.ToLower())
                        {
                            case "p":
                                totalTime += 1.1;
                                break;
                            case "c":
                                totalTime += 0.4;
                                break;
                            case "h":
                                totalTime += 0.4;
                                break;
                            case "m":
                                totalTime += 1.35;
                                break;
                            default:
                                Console.WriteLine("Unrecognized command input");
                                break;
                        }
                    }
                }


                Console.WriteLine(gomCommands);
                Console.WriteLine("Total Time: {0}\n\n\n", totalTime);
            }
        }
    }
}