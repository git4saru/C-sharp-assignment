using System;
using System.IO;
using System.Text;

class FileProgram
{
    static void Main(string[] args)
    {
        // Get source path from console
        Console.WriteLine("Enter source directory path:");
        string sourcePath = Console.ReadLine();

        // Get destination path from console
        Console.WriteLine("Enter destination directory path:");
        string destinationRoot = Console.ReadLine();

        // Get list of all files from source directory
        string[] files = Directory.GetFiles(sourcePath);



        // Create a log file path
        string logFilePath = Path.Combine(sourcePath, "log.csv");

        // Create log file with header if not exists
        if (!File.Exists(logFilePath))
        {
            string header = "File Name,DateTime,From Location,To Location,Status\n";
            File.WriteAllText(logFilePath, header);
        }

        //Loop through all files in the array to perform the move
        foreach (string file in files)
        {
            // Split filename with underscore. Left will be folder name and right will be file name
            string fileName = Path.GetFileName(file);

            //Splitting happens here
            string[] parts = fileName.Split('_');


            //This check will validate if the filename in folder follows the <folder>_<file> format.
            if (parts.Length > 1)
            {
                string folderName = parts[0];
                string newFileName = parts[1];

                // Destination directory - combination of the user entered destination root directory + folder name from filename
                string destinationPath = Path.Combine(destinationRoot, folderName);

                // Check if  destination Path with destination root and folder exists
                if (!Directory.Exists(destinationPath))
                {
                    // Create new folder if not exists
                    Directory.CreateDirectory(destinationPath);
                }

                // Move the file to target
                string destinationFile = Path.Combine(destinationPath, newFileName);
                File.Move(file, destinationFile);

                // Put an entry in log file - We will write here only if the move is successful
                string logEntry = $"{fileName},{DateTime.Now},{sourcePath},{destinationPath},Moved\n";
                File.AppendAllText(logFilePath, logEntry);

                Console.WriteLine($"File '{fileName}' moved to '{destinationPath}'.");
            }
            else
            {
                //Write an error to the console if the file dows not follow the required format <folder>_<file>
                Console.WriteLine($"File '{fileName}' does not contain underscore.");
            }
        }
    }
}
