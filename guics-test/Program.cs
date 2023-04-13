using System.Security.Principal;
using Terminal.Gui;

class Program{     // Principal class to contain the main method 


    static void Main(string[] args)    // The main method where everything shows in terminal
    {
        Application.Init();     // Initialize the terminal.gui application to show in terminal7

        for (int i = 0; i < 100; i++){
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

    public WaterDrop(MainLoop mainLoop) : base("", TextDirection.TopBottom_LeftRight)
    {
        this.X = column;    // like self in python (this)
        column++;
        mainLoop.AddTimeout(
                TimeSpan.FromSeconds(1),   // random drop speed for each column in terminal
                updateLabel
            );
    }

    private string getRandomChar()
    {
        List<string> possibleChars = new List<string>();

        // possibleChars.Add($"{(char)('\u3041' + rand.Next(0, 3096 - 3041 + 1))}");
        for (int i = 0; i < 10; i++)
        {
            possibleChars.Add($"{(char)('a' + rand.Next(0, 26))}");  // latin alphabet
            possibleChars.Add($"{rand.Next(0, 10)}");   // numbers
        }

        return possibleChars[rand.Next(0, possibleChars.Count)];
    }

    private void updateLine()
    {

        
        line.Add(getRandomChar());

        //for (int i = 0; i < line.Count; i++)
        //{
        //    if (rand.NextDouble() < 0.2)
        //        line[i] = getRandomChar();
        //}
    }

    bool updateDrop()
    {
        if(rand.NextDouble() > 0.8)
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
            line.Add(getRandomChar());
            this.Text = string.Join("", line);
        }
        return true;
    }

}