// See https://aka.ms/new-console-template for more information

// int height = Console.BufferHeight;
int height = 40;
int width = Console.BufferWidth;
// int tail = 7;
// int gencut = 10;
int amount = 10;
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
    table.Add(i,(y,x,character));
}
System.Console.WriteLine(table[1]);

Console.CursorVisible = false;
Console.Clear();
for (int i = 0; i < 400; i++)
{
    foreach (var ite in table.ToArray())
    {       
        int y = ite.Value.Item1;
        int x = ite.Value.Item2;
        char c = ite.Value.Item3;
        switch (ite.Value.Item3)
        {
            case not 'E':
                Console.SetCursorPosition(x, y);
                System.Console.Write(c);
                if (y < height-1)
                {
                    table.Remove(ite.Key);
                    y++;
                    table.Add(ite.Key,(y,x,c));
                }
                break;
            default:
                break;
        }
    }
    System.Threading.Thread.Sleep(50);
}