//using nyelvtanulas.Szotar;

using System.Net.Mime;

namespace nyelvtanulas;

public class Menu
{
    Szotar dict = new Szotar();

    public void header(string t)
    {
        string text = t;
        int result = (20 - text.Length) / 2;
        string textSide = new string('+', result);
        Console.WriteLine("++++++++++++++++++++");
        Console.WriteLine(textSide + text + textSide);
        Console.WriteLine("++++++++++++++++++++");
    }



    public void mainMenu()
    {

        Console.Clear();
        header("Szótanulás");
        Console.WriteLine("\n\n");
        Console.WriteLine("Válasszon az alábbi menüpontok közül");
        Console.WriteLine("1.Szavak feltöltése");
        Console.WriteLine("2.Játék a már feltöltött szókészlettel");
        Console.WriteLine("3.Adott szó törlése");
        Console.WriteLine("4.Komplett téma törlése");
        Console.WriteLine("5.Kilépés");
        int input = int.Parse(Console.ReadLine());
        if (input == 1)
        {
            feltoltMenu();
        }
        else if (input == 2)
        {
            Jatek j = new Jatek(dict, this);
            j.loop();
        }
        else if (input == 3)
        {
            Console.WriteLine("Add meg a törölni kívánt szót.");
            dict.szoTorles(Console.ReadLine());
            mainMenu();
        }
        else if (input == 4)
        {
            temaTorlesMenu();
        }
        else if (input == 5)
        {
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("valószínüleg rossz bemeneti adatot adtál meg\nNyomjon egy ENTER-t a visszalépéshez");
            Console.ReadLine();
            mainMenu();
        }


    }

    
    public void feltoltMenu()
    {
        Console.Clear();
        header("FELTÖLTÉS");

        Console.WriteLine("Milyen nyelv legyen az elsődleges nyelv, amelyiken kapod a kérdést?");
        Console.WriteLine("1.angol-magyar");
        Console.WriteLine("2.magyar-angol");
        Console.WriteLine("3.vegyes");
        Console.WriteLine("4.Vissza");
        int input = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("Add meg a betölteni kívánt fájlok nevét. (A fájlokat a 'nyelvtanulas/bin/Debug/net7.0' mappába kell tenned)");
        Console.WriteLine("Külön sorokba írd a fájl nevét, ha végeztél, akkor küldj egy üres sort az Enterrel");
        List<string> fajlok = new List<string>();
        string tmp = "";
        do
        {
            tmp = Console.ReadLine();
            if (tmp != "")
            {
                fajlok.Add(tmp);
            }
        } while (tmp != "");

        string[] files = fajlok.ToArray();
        if (input == 1)
        {
            dict.feltolt("angol", files);
            mainMenu();
        }
        else if (input == 2)
        {
            dict.feltolt("magyar", files);
            mainMenu();
        }
        else if (input == 3)
        {
            dict.feltolt("magyar", files);
            dict.feltolt("angol", files);
            mainMenu();
        }
        else if (input == 4)
        {
            mainMenu();
        }
        else if (input == 5)
        {
            Environment.Exit(0);
        }
        
    }

    public void temaTorlesMenu()
    {
        Console.WriteLine("Add meg a kulcsnyelvet\n1-magyar\n2-angol");
        string key = Console.ReadLine();

        Console.WriteLine(
            "Add meg a betölteni kívánt fájlok nevét. (A fájlokat a 'nyelvtanulas/bin/Debug/net7.0' mappába kell tenned)");
        Console.WriteLine("Külön sorokba írd a fájl nevét, ha végeztél, akkor küldj egy üres sort az Enterrel");
        List<string> fajlok = new List<string>();
        string tmp = "";
        do
        {
            tmp = Console.ReadLine();
            if (tmp != "")
            {
                fajlok.Add(tmp);
            }
        } while (tmp != "");

        string[] files = fajlok.ToArray();
        if (key == "1")
        { 
            dict.temaTorles("angol", files);   
        }
        else if (key == "2")
        { 
            dict.temaTorles("magyar", files);   
        }
        mainMenu();
    }





}