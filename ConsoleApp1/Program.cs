using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Reflection;

class ModelNumberDigest {
    public static void Main()
    {
        ListGenerator();
    }
    public static void ListGenerator()
    {
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            string folder = Path.GetDirectoryName(Environment.ProcessPath).Split("ConsoleApp1")[0];
            //Console.WriteLine(folder); //Confirm folder path

            StreamReader sr = new StreamReader(folder + "\\Filter - Master Unit List.htm");
            StreamWriter swr = new StreamWriter(folder + "\\Amogus");

            string hrefPattern = @"href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>[^>\s]+))";
            string pattern2 = @"^[a-zA-Z]{3,3}\-.+[a-zA-Z0-9]";
            //Read the first line of text
            String line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the line to console window
                //Console.WriteLine(line);
                if (Regex.IsMatch(line, hrefPattern))
                {
                    //write the line to console window
                    //Console.WriteLine(line);

                    //Looking for data-name matches
                    if (line.Contains("data-name="))
                    {
                        //Splits line into digestible array
                        line = line.Split("data-name=")[1];
                        Array subStrings = line.Split('"', ' ');
                        //prints array
                        foreach (string token in subStrings)
                        {
                            //Console.WriteLine(token);
                            if (Regex.IsMatch(token, pattern2))
                            {
                                //debug to console
                                Console.WriteLine(token);
                                //Write number of matching patterns
                                swr.WriteLine(token);
                            }
                        }
                    }



                }
                //Read the next line
                #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                line = sr.ReadLine();
                #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            }
            //close the file
            sr.Close();
            swr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
            //Console.ReadLine();
        }
    }
}