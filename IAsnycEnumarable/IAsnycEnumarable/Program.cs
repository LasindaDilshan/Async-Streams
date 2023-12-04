// See https://aka.ms/new-console-template for more information


string destinationFilePath = @"C:\Users\lasindad\Desktop\a\sdf.txt";

string filePath = @"C:\Users\lasindad\Desktop\a\sendids.txt"; // Replace with your file path
try
{
    using (StreamWriter writer = new StreamWriter(destinationFilePath))
    {
        await foreach (string line in ReadLinesAsync(filePath))
        {
            if (!string.IsNullOrWhiteSpace(line))

            {

                Console.WriteLine(line); // Process each line here

                await writer.WriteLineAsync($"'{line}',"); // Write modified line to the new file

            }

        }
    }
}
catch (Exception e)
{
    Console.WriteLine("Error reading the file: " + e.Message);
}

static async IAsyncEnumerable<string> ReadLinesAsync(string filePath)
{
    using (StreamReader reader = new StreamReader(filePath))
    {
        string line;
        while ((line = await reader.ReadLineAsync()) != null )
        {
            yield return line;
        }
    }
}