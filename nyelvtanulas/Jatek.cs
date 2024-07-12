using System.IO.Pipes;

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
    internal int pont = 0;

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
            pont++;
        }
        else if (answer == " ")
        {
            menu.mainMenu();
        }
        else
        {
            Console.WriteLine("Sajnos a válasz helytelen. A helyes megfejtés: "+random.Value);
        }
    }
    

    public void loop()
    {
        compare();
        loop();
    }
}