// See https://aka.ms/new-console-template for more information

int height = 29;
// int height = ;
int width = Console.BufferWidth;
int tail = 7;
// int gencut = 10;
int amount = 10;
List<string> characters = ["1", "2", "3", "4",];
List<string> colors = ["G", "B", "R", "P", "Y",];
System.Console.WriteLine(width);

Dictionary<int, (int, int, char)> table = new Dictionary<int, (int, int, char)>{};

Random rnd = new Random();
string[] alt_c = colors.ToArray(); // colors to array for easy lenght


for (int i = 0; i < amount; i++) // the starting amount of snakes
{
    int y = rnd.Next(0,height-tail);
    int x = rnd.Next(0,width);
    int c = rnd.Next(0,alt_c.Length-1);
    char character = colors[c][0];
    table.Add(i,(x,y,character));
}

System.Console.CursorVisible = false;
System.Console.Clear();
for (int i = 0; i < 400000; i++)
{
    foreach (var ite in table.ToArray())
    {       
        int y = ite.Value.Item2;
        int x = ite.Value.Item1;
        char c = ite.Value.Item3;
        if (y >= tail && y <= height)
        {
            Console.SetCursorPosition(x, y-tail);
            System.Console.Write(" ");
            Console.SetCursorPosition(x, y);
            System.Console.Write(c);
            table.Remove(ite.Key);
            y++;
            table.Add(ite.Key,(x,y,c));
        }
        else if (y < tail)
        {
            Console.SetCursorPosition(x, y);
            System.Console.Write(c);
            table.Remove(ite.Key);
            y++;
            table.Add(ite.Key,(x,y,c));
        }
        else if (y > height && y < height + tail)
        {
            Console.SetCursorPosition(x, y-tail);
            System.Console.Write(" ");
            table.Remove(ite.Key);
            y++;
            table.Add(ite.Key,(x,y,c));
        }
        else if(y >= height + tail)
        {
            Console.SetCursorPosition(x, y-tail);
            System.Console.Write(" ");
            int yg = rnd.Next(0,height-tail);
            int xg = rnd.Next(0,width);
            int cg = rnd.Next(0,alt_c.Length-1);
            char character = colors[cg][0];
            table.Remove(ite.Key);
            table.Add(ite.Key,(xg,yg,character));
        }
    }
    System.Threading.Thread.Sleep(100);

}
System.Console.WriteLine("you done goofed");