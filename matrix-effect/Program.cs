// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using System.Text;

static void chcol(bool yah, char c){
if (yah == false)
    {
        switch (c)
        {
            case 'R':
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case 'G':
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;
            case 'B':
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case 'M':
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            case 'Y':
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case 'C':
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case 'F':
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                break;
            case 'N':
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;

            default:
                break;
        }    
    }
else 
{

    Random rnd = new Random();
    int numo = rnd.Next(0,7);
    switch (numo)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case 3:
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            case 4:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case 5:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case 6:
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                break;
            case 7:
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                break;

            default:
                break;
        } 
}
}


bool rndcol = true;
Console.OutputEncoding = Encoding.UTF8;

int height = Console.WindowHeight-1;
int width = Console.WindowWidth;
int tail = 7;
int amount = 100;
// List<string> characters = ["1", "2", "3", "4","5","6","7"];
// List<string> characters = ["Bitch"];
List<string> characters = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M","N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];
// List<string> characters = ["ア", "イ", "ウ", "エ","オ","カ"];
List<string> colors = ["G", "B", "R", "M", "Y","C","F","N"];
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
            chcol(rndcol, c); 
            // rndchar(true, characters);
            string chara = characters[rnd.Next(0,characters.Count)];
            System.Console.Write(chara);
            table.Remove(ite.Key);
            y++;
            table.Add(ite.Key,(x,y,c));
        }
        else if (y < tail)
        {
            Console.SetCursorPosition(x, y);
            // Console.ForegroundColor = ConsoleColor.Red;
            chcol(rndcol, c); 
            // rndchar(true, characters);
            string chara = characters[rnd.Next(0,characters.Count)];
            System.Console.Write(chara);
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
    System.Threading.Thread.Sleep(20);

}
System.Console.WriteLine("you done goofed");