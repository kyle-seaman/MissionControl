using System;
using System.Text.RegularExpressions;
using System.IO;

class ModelNumberDigest {
    public static void Main()
    {
        String line;
        try
        {
            //Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader("C:\\Users\\Admin\\Downloads\\Filter - Master Unit List.htm");
            StreamWriter swr = new StreamWriter("Amogus");
            string hrefPattern = @"href\s*=\s*(?:[""'](?<1>[^""']*)[""']|(?<1>[^>\s]+))";
            string pattern2 = @"^[a-z]{3,3}\-";
            //Read the first line of text
            line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the line to console window
                Console.WriteLine(line);
                if(Regex.IsMatch(line, hrefPattern))
                {
                    if (Regex.IsMatch(line, pattern2)) 
                    {
                        Console.WriteLine(Regex.Count(line, pattern2));
                    }

                }
                //Read the next line
                line = sr.ReadLine();
            }
            //close the file
            sr.Close();
            swr.Close();
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception: " + e.Message);
        }
        finally
        {
            Console.WriteLine("Executing finally block.");
        }
      //  File.OpenRead("");
      //string pattern = "(Mr\\.? |Mrs\\.? |Miss |Ms\\.? )";
      //  string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels",
      //                   "Abraham Adams", "Ms. Nicole Norris" };
      //  foreach (string name in names)
      //      Console.WriteLine(Regex.Replace(name, pattern, String.Empty));
    }
}