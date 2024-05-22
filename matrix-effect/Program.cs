// See https://aka.ms/new-console-template for more information

int height = 20;
// int height = ;
int width = Console.BufferWidth;
int tail = 7;
// int gencut = 10;
int amount = 5;
List<string> characters = ["1", "2", "3", "4",];
List<string> colors = ["G", "B", "R", "P", "Y",];
System.Console.WriteLine(width);

Dictionary<int, (int, int, char)> table = new Dictionary<int, (int, int, char)>{};
// myDictionary[1] = (currentValue.Item1 + 1, currentValue.Item2, currentValue.Item3);

// myDictionary.Add(1, (10, 20, 'A'));
Random rnd = new Random();
string[] alt_c = colors.ToArray(); // colors to array for easy lenght


for (int i = 0; i < amount; i++) // the starting amount of snakes
{
    int y = rnd.Next(0,height);
    int x = rnd.Next(0,width);
    int c = rnd.Next(0,alt_c.Length-1);
    char character = colors[c][0];
    table.Add(i,(x,y,character));
}

System.Console.CursorVisible = false;
System.Console.Clear();
for (int i = 0; i < 4000; i++)
{
    foreach (var ite in table.ToArray())
    {       
        int y = ite.Value.Item2;
        int x = ite.Value.Item1;
        char c = ite.Value.Item3;
        
        // // switch (ite.Value.Item2 > height-1 && ite.Value.Item3 != 'E')
        // // {
        // //     case true:
        // //         int yg = rnd.Next(0,height);
        // //         int xg = rnd.Next(0,width);
        // //         int cg = rnd.Next(0,alt_c.Length-1);
        // //         char character = colors[cg][0];
        // //         table.Remove(ite.Key);
        // //         table.Add(ite.Key,(xg,yg,character));
        // //         break;
        // //     default:
        // //         break;
        // }

        if(ite.Value.Item2 > height-1 && ite.Value.Item3 != 'E')
        {
            int yg = rnd.Next(0,height);
            int xg = rnd.Next(0,width);
            int cg = rnd.Next(0,alt_c.Length-1);
            char character = colors[cg][0];
            table.Remove(ite.Key);
            table.Add(ite.Key,(xg,yg,character));
        }
        switch (ite.Value.Item3 == 'E')
        {
            case true:
                Console.SetCursorPosition(x, y); // bugged for E becomes - idk why
                System.Console.Write(' ');
                if (y < height)
                {
                    table.Remove(ite.Key);
                    y++;
                    table.Add(ite.Key,(x,y,c));
                }
                break;
            case false:
                Console.SetCursorPosition(x, y);
                System.Console.Write(c);
                if (y < height)
                {
                    table.Remove(ite.Key);
                    y++;
                    table.Add(ite.Key,(x,y,c));
                }
                if (y > tail-1)
                {
                    Console.SetCursorPosition(x, y-tail);
                    System.Console.Write(" ");
                    
                }
                if (y > tail && table.ContainsKey(ite.Key+amount))
                {
                    table.Remove(ite.Key+amount);
                    y = y - tail;
                    table.Add(ite.Key+amount,(x,y,'E'));
                }
                break;
            // case true:
            //     Console.SetCursorPosition(x, y);
            //     System.Console.Write(' ');
            //     if (y < height)
            //     {
            //         table.Remove(ite.Key);
            //         y++;
            //         table.Add(ite.Key,(x,y,c));
            //     }
            //     break;
            // case 'E':
            //     Console.SetCursorPosition(x, y);
            //     System.Console.Write(' ');
            //     if (y < height)
            //     {
            //         table.Remove(ite.Key);
            //         y++;
            //         table.Add(ite.Key,(x,y,c));
            //     }
            //     break;
        }
        
    }

    System.Threading.Thread.Sleep(40);
}
System.Console.WriteLine("you done goofed");