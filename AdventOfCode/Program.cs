using System.IO;

void day1()
{
    string currentDir = Directory.GetCurrentDirectory();
    Console.WriteLine(currentDir);
    StreamReader reader = new StreamReader(currentDir + "\\input.txt");

    int depth = 0;
    int increases = 0;
    int value = 0;

    // Part 2 of Problem 1
    Queue<int> queue = new Queue<int>();
    int sum = 0;
    int increases2 = 0;

    try
    {
        do
        {
            value = Convert.ToInt32(reader.ReadLine());

            if (queue.Count == 3)
            {
                int prev = queue.Dequeue();
                if (sum + value - prev > sum) ++increases2;
                sum -= prev;
            }

            sum += value;
            queue.Enqueue(value);

            if (depth == 0)
            {
                depth = value;
                continue;
            }

            if (value - depth > 0) ++increases;
            depth = value;
        }
        while (!reader.EndOfStream);
    }
    catch
    {
        Console.Error.WriteLine("Error happened with file");
    }
    finally
    {
        reader.Close();
        Console.WriteLine($"Measurement Increases: {increases}");
        Console.WriteLine($"Three-sum Measurement Increases: {increases2}");
    }
}

// Run function of current day
day1();