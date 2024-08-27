using System.IO.Pipes;
using System.Threading.Tasks;

namespace nyelvtanulas;

internal class Jatek
{
    private Szotar szotar;
    private Menu menu;
    public Jatek(Szotar sz, Menu m )
    {
        szotar = sz;
        menu = m;
    }

    public KeyValuePair<string,string> randomElem()
    {
        Random r = new Random();
        int i = r.Next(szotar.szavak.Count);
        foreach (var item in szotar.szavak)
        {
            if (i-- == 0)
            {
                return item;
            }
        }
        throw new Exception("A szótár üres");
    }

    public void compare()
    {
        KeyValuePair<string, string> random = randomElem();
        Console.WriteLine(random.Key+"=");
        string answer = Console.ReadLine();
        if (random.Value == answer)
        {
            Console.WriteLine("Helyes!");
            
        }
        else if (answer == "")
        {
            endGame();
        }
        else
        {
            Console.WriteLine("Sajnos a válasz helytelen. A helyes megfejtés: "+random.Value);
        }
    }

    public void endGame()
    {
        Console.WriteLine("Játék vége\nA menübe visszalépéshez nyomj egy entert");
        Console.ReadLine();
        menu.mainMenu();
    }
    

    public void loop()
    {
        compare();
        loop();
    }
}