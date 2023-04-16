using System;
using Terminal.Gui;

class Program{     // Principal class to contain the main method 


    static void Main(string[] args)    // The main method where everything shows in terminal
    {
        Application.Init();     // Initialize the terminal.gui application to show in terminal

        // Get terminal window size
        var cols = Console.WindowWidth;
        var rows = Console.WindowHeight;

        for (int i = 0; i < cols; i++){
            var waterDrop = new WaterDrop(Application.MainLoop);
            Application.Top.Add(waterDrop);  
            }


        Application.MainLoop.AddTimeout(    // Living time of programming
            TimeSpan.FromSeconds(100),      // there are 100 seconds of live time
            (MainLoop ml) =>
            {
                Application.RequestStop();
                return true;
            }
        );

        Application.Run();
        Application.Shutdown();

    }

}


class WaterDrop : Label           // Class to create an individual rain of letters, with special characters and random drop speed
{
    List<string> line = new List<string>();
    static int column = 0;       // inmutable variable to change the value in each call of the method
    Random rand = new Random();
    bool drop = false;
    int idx = 0;

    public WaterDrop(MainLoop mainLoop) : base("", TextDirection.TopBottom_LeftRight)
    {
        this.X = column;    // like self in python (this)
        column++;
        mainLoop.AddTimeout(
                TimeSpan.FromSeconds(0.3),   // random drop speed for each column in terminal
                updateLabel
            );
    }

    private string getRandomChar()
    {
        List<string> possibleChars = new List<string>();

        // possibleChars.Add($"{(char)('\u3041' + rand.Next(0, 3096 - 3041 + 1))}");
        for (int i = 0; i < 100; i++)
        {
            possibleChars.Add($"{(char)('a' + rand.Next(0, 26))}");  // latin alphabet
            // possibleChars.Add($"{rand.Next(0, 10)}");   // numbers
            //possibleChars.Add($"{(char)(0x3041 + rand.Next(0, 0x3096 - 0x3041 + 1))}");  // Hiragana characters
            //possibleChars.Add($"{(char)(0x30A1 + rand.Next(0, 0x30FA - 0x30A1 + 1))}");  // Katakana characters
        }

        return possibleChars[rand.Next(0, possibleChars.Count)];
    }
    
    private void updateLine()
    {
        line.Add(getRandomChar());

        for (int i = idx; i < line.Count; i++)
        {
            if (rand.NextDouble() < 0.4)
                line[i] = getRandomChar();
        }

        if (line.Count > Console.WindowHeight)
        {
            line[idx] = " ";  // Replace the character with a space
            idx++;
            if (idx == Console.WindowHeight)
            {
                idx = 0;
                line = new List<string>();
            }
            
        }
    }


    bool updateDrop()
    {
        if(rand.NextDouble() > 0.99)
        {
            drop = true;
        }

        return drop;
    }

    private bool updateLabel(MainLoop mainLoop)  // method to pass in the mainloop of each column
    {
        // updateLine();
        if (updateDrop())
        {
            updateLine();
            //if (line.Count > Console.WindowHeight)
            //{
            //    // line = new List<string>();
            //    // line[0] = " ";
            //    //line.Clear();
            //    // line.RemoveAt(0);
            //    drop = false;
            //}
            this.Text = string.Join("", line);
        }

        return true;
    }

}