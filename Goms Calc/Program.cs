using System;
using System.Linq;
/* Author: Garrett Powell
 * Email: gbp18a@acu.edu / garettbpowell@gmail.com
*/

/* Goms steps:
****************************************************************************
* Press a Key or button for an average non-skilled typist (K) = .28 seconds*
* Point with a mouse (excluding click) OR scrolling (P) = 1.1 seconds      *
* Mouse Click (C) = .4 seconds                                             *
* Move Hands to keyboard from mouse (or vice-versa) (H) = .4 seconds       *
* Mentally prepare (M) = 1.35 seconds                                      *
****************************************************************************
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
            int inputNum = 0;
            string input = "";
            string gomCommands = "";
            while (input.ToLower() != "exit")
            {
                inputNum++;
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
                    // calc nums for k with or without * num
                    if (c.ToLower().StartsWith("k")) {
                        if (c.Length > 1)
                        {
                            int count = Int32.Parse(c.Split("*").Last());
                            totalTime += calcWords(count);
                        }
                        else
                            totalTime += 0.28;

                        // don't add + on first run
                        if (first)
                        {
                            gomCommands += toNum(c);
                            first = false;
                        }
                        else
                        {
                            gomCommands += (" + " + toNum(c));
                        }
                    }
                    // calc other letters
                    else {
                        try {                      
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
                                    throw new Exception("Unrecognized command input");
                            }
                            // don't add + on first run
                            if (first) {
                                gomCommands += toNum(c);
                                first = false;
                            }
                            else {
                                gomCommands += (" + " + toNum(c));
                            }
                        }
                        // catch for unknown commands ex. a e i o u
                        catch (Exception e) {
                            Console.WriteLine("Unrecognized command input\nPlease only use K, K*<int> P, C, H, and M.\nSee Goms steps at top of program for more details");
                        }
                    }
                }

                // print results
                Console.WriteLine("[{0}]", inputNum);
                Console.WriteLine("      {0}",gomCommands);
                Console.WriteLine("      {0}: {1:F2}\n\n", "Total Time: ", totalTime);

                // reset
                if(input != "exit")
                    input = "";
                gomCommands = "";
            }
        }
    }
}
