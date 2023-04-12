using Terminal.Gui;


class MatrixRain
{

    static void Main()
    {
        Application.Init();
        for (int i = 0; i < 2; i++)
        {
            var waterDrop = new WaterDrop(Application.MainLoop);
            Application.Top.Add(waterDrop);   // Top --> como screen en pygame
        }

        Application.MainLoop.AddTimeout(
            TimeSpan.FromSeconds(100),
            (MainLoop ml) => {
                Application.RequestStop();
                return true;
            }
        );

        Application.Run();
        Application.Shutdown();
    }
}

class WaterDrop : Label
{

    List<string> line = new List<string>();
    static int column = 0;
    static double v = 1;
    Random rand = new Random();
    public WaterDrop(MainLoop mainLoop) : base("", TextDirection.TopBottom_LeftRight)
    {
        this.X = column;
        mainLoop.AddTimeout(
            TimeSpan.FromSeconds(v),
            updateLabel

        );
        v = v + 0.1;
        column = column + 3;
    }

    private string getRandomChar()
    {
        List<string> possibleChars = new List<string>();

        possibleChars.Add($"{(char)('\u3041' + rand.Next(0, 3096 - 3041 + 1))}");
        possibleChars.Add($"{(char)('a' + rand.Next(0, 26))}");

        //possibleChars.Add($"{rand.Next(0, 10)}");

        return possibleChars[rand.Next(0, possibleChars.Count)];
    }
    private void updateLine()
    {
        line.Add(getRandomChar());

        for (int i = 0; i < line.Count; i++)
        {
            if (rand.NextDouble() < 0.2)
                line[i] = getRandomChar();
        }
    }

    private bool updateLabel(MainLoop mainLoop)
    {
        updateLine();
        this.Text = string.Join("", line);
        return true;
    }
}