using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ingatlanok
{
    class TablalistaClass// a táblalista adjon vissza consolkey erteket ha kerek ehez pedig class-t kellene hasznalni
    {
        TablalistaStruct tablalista;

        int opcio;

        static string hossz(int hosz, int kivonando, string kitoltes)
        {
            string vege = "";
            int kulombseg = 0;
            if (hosz > kivonando)
            {
                kulombseg = hosz - kivonando;
            }
            else
            {
                kulombseg = kivonando - hosz;
            }
            for (int i = 0; i < kulombseg; i++)
            {
                vege += kitoltes;
            }
            return vege;
        }
        struct TablalistaStruct
        {
            public int opcio;
            public ConsoleKey consoleKey;
        }

        public void TablaLista(List<string> adatok, ConsoleKey consoleKey, string tipus, List<int> cursorTops, int maxview)//táblalista(egy string lista amely a kiíratandó adatokat tartalmazza  ,  tartalmazza a consolekey-t  ,  egy tipust amely azt határozza meg , hogy mien adatokkal dolgozik és azon tipus alapján zajlódjanak a műveletek)
        {
            int pozitcio = 0;
            int pozitcio2 = 0;
            consoleKey = default;
            int kurzolpozicio = Console.CursorTop;
            int[] kozok = new int[adatok[0].Split(';').Length];
            for (int i = 0; i < kozok.Length; i++)
            {
                for (int j = 0; j < adatok.Count; j++)
                {
                    if (kozok[i] < adatok[j].Split(';')[i].Length)
                    {
                        kozok[i] = adatok[j].Split(';')[i].Length;
                    }
                }
            }
            while (consoleKey != ConsoleKey.Enter && consoleKey != ConsoleKey.Escape)
            {
                cursorTops.Clear();
                Console.SetCursorPosition(0, kurzolpozicio);
                Console.WriteLine("---");
                for (int i = pozitcio2; i < adatok.Count && i < pozitcio2 + maxview; i++)
                {
                    Console.WriteLine(hossz(80, 0, " "));
                }
                Console.SetCursorPosition(0, kurzolpozicio);

                Console.WriteLine("---");
                for (int i = pozitcio2; i < adatok.Count && i < pozitcio2 + maxview; i++)
                {
                    if (cursorTops.Count == pozitcio)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (tipus == "utas")
                    {
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) " + adatok[i]);
                    }
                    else if (tipus == "ut")
                    {
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) " + adatok[i]);
                    }
                    else
                    {
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) " + adatok[i]);
                    }
                    if (cursorTops.Count - 1 == pozitcio)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                Console.WriteLine("---");

                Console.SetCursorPosition(1, cursorTops[pozitcio]);
                consoleKey = Console.ReadKey().Key;

                switch (consoleKey)
                {
                    case ConsoleKey.UpArrow:
                        if (Console.CursorTop != cursorTops[0])
                        {
                            pozitcio--;
                        }
                        else if (pozitcio2 > 0)
                        {
                            pozitcio2--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Console.CursorTop != cursorTops[cursorTops.Count - 1])
                        {
                            pozitcio++;
                        }
                        else if (pozitcio2 < adatok.Count - maxview)
                        {
                            pozitcio2++;
                        }
                        break;
                    default:
                        break;
                }
            }
            TablalistaStruct tablalistaStruct = new TablalistaStruct();
            tablalistaStruct.opcio = pozitcio2 + pozitcio;
            tablalistaStruct.consoleKey = consoleKey;
            tablalista = tablalistaStruct;
        }
        public void TablaLista(List<string> adatok, ConsoleKey consoleKey, string tipus, List<int> cursorTops, int maxview, bool igaz)//táblalista(egy string lista amely a kiíratandó adatokat tartalmazza  ,  tartalmazza a consolekey-t  ,  egy tipust amely azt határozza meg , hogy mien adatokkal dolgozik és azon tipus alapján zajlódjanak a műveletek)
        {
            int pozitcio = 0;
            int pozitcio2 = 0;
            consoleKey = default;
            int kurzolpozicio = Console.CursorTop;
            int[] kozok = new int[adatok[0].Split(';').Length];
            for (int i = 0; i < kozok.Length; i++)
            {
                for (int j = 0; j < adatok.Count; j++)
                {
                    if (kozok[i] < adatok[j].Split(';')[i].Length)
                    {
                        kozok[i] = adatok[j].Split(';')[i].Length;
                    }
                }
            }
            while (consoleKey != ConsoleKey.Enter && consoleKey != ConsoleKey.Escape)
            {
                cursorTops.Clear();
                Console.SetCursorPosition(0, kurzolpozicio);
                Console.WriteLine("---");
                for (int i = pozitcio2; i < adatok.Count && i < pozitcio2 + maxview; i++)
                {
                    Console.WriteLine(hossz(80, 0, " "));
                }
                Console.SetCursorPosition(0, kurzolpozicio);

                Console.WriteLine("---");
                for (int i = pozitcio2; i < adatok.Count && i < pozitcio2 + maxview; i++)
                {
                    if (cursorTops.Count == pozitcio)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (tipus == "utas")
                    {
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) " + adatok[i]);
                    }
                    else if (tipus == "ut")
                    {
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) " + adatok[i]);
                    }
                    else
                    {
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) " + adatok[i]);
                    }
                    if (cursorTops.Count - 1 == pozitcio)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                Console.WriteLine("---");

                Console.SetCursorPosition(1, cursorTops[pozitcio]);
                consoleKey = Console.ReadKey().Key;

                switch (consoleKey)
                {
                    case ConsoleKey.UpArrow:
                        if (Console.CursorTop != cursorTops[0])
                        {
                            pozitcio--;
                        }
                        else if (pozitcio2 > 0)
                        {
                            pozitcio2--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Console.CursorTop != cursorTops[cursorTops.Count - 1])
                        {
                            pozitcio++;
                        }
                        else if (pozitcio2 < adatok.Count - maxview)
                        {
                            pozitcio2++;
                        }
                        break;
                    default:
                        break;
                }
            }
            TablalistaStruct tablalistaStruct = new TablalistaStruct();
            tablalistaStruct.opcio = pozitcio2 + pozitcio;
            tablalistaStruct.consoleKey = consoleKey;
            tablalista = tablalistaStruct;
        }
    }
    internal class Program
    {
        #region adatstrukturak
        struct UtasStruct
        {
            public int id;
            public string name;
            public string cim;
            public string phoneNumber;
        }
        struct UtStruct
        {
            public int id;
            public string uticel;
            public int ar;
            public int maxLetszam;
        }
        struct foglalasStruct
        {
            public int utasId;
            public int utId;
            public int eloleg;
        }
        #endregion
        static List<UtasStruct> utasok = new List<UtasStruct>();
        static List<UtStruct> utak = new List<UtStruct>();
        static List<foglalasStruct> foglalasok = new List<foglalasStruct>();
        #region program adatai

        #endregion

        #region modulvaltozok
        static List<int> cursorTops = new List<int>();//a kurzol ideiglenes pozitciojanak valtozoja
        static int maxview = 4;//a táblalista maximálisan egyszerre láthatő elemeinek száma
        static List<string> strings = new List<string>();//a tablalista számára befogadható adatlista melyet a táblabeviteli lista előtt adunk adatot illetve változtatjuk
        static int opcio = 0;//a táblalista által visszadott szám, mely annak az adatlisat elemindexet adja vissza amely adatlistából a "strings" lista készült. 
        #endregion

        static void Main(string[] args)//fő program
        {
            filekezeles("");
            filekezeles("load");
            menu();
        }


        static void menu()//menu
        {
            ConsoleKey consoleKey = default;
            while (consoleKey != ConsoleKey.Escape)
            {
                Console.Clear();
                cursorTops.Clear();
                Console.WriteLine("Fő Menü (Kilépés: Esc)  (Kiválasztás: Enter)");
                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Utasok Kezelése");
                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Útazások Kezelése");
                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Útvonalfoglalás");
                consoleKey = mozgas(consoleKey);
                if (consoleKey == ConsoleKey.Enter && cursorTops[0] == Console.CursorTop)
                {
                    while (consoleKey != ConsoleKey.Escape)
                    {
                        consoleKey = default;
                        Console.Clear();
                        cursorTops.Clear();
                        Console.WriteLine("Utasok kezelése menü");
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Utas hozzáadása");
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Utas módosítása");
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Utas ----------");
                        consoleKey = mozgas(consoleKey);
                        if (consoleKey == ConsoleKey.Enter && cursorTops[0] == Console.CursorTop)//Utas hozzáadása
                        {
                            Console.Clear();
                            cursorTops.Clear();
                            utasNew(utas_adatbekeres("-name-cim-phonenumber-"));
                            filekezeles("save");
                        }
                        else if (consoleKey == ConsoleKey.Enter && cursorTops[1] == Console.CursorTop)//Utas módosítása
                        {
                            Console.Clear();
                            cursorTops.Clear();
                            strings.Clear();
                            for (int i = 0; i < utasok.Count; i++)
                            {
                                strings.Add($"{utasok[i].id};{utasok[i].name};{utasok[i].cim};{utasok[i].phoneNumber}");
                            }
                            opcio = TablaLista(strings, consoleKey, "utas");

                            string name = "";
                            string cim = "";
                            string phoneNumber = "";
                            while (consoleKey != ConsoleKey.Escape)//felhasználó menü KÉSZ!
                            {
                                Console.Clear();
                                cursorTops.Clear();
                                Console.WriteLine($"{utasok[opcio].name} utas módosítása (ha nem módosít akkor hadja üresen)");
                                Console.WriteLine("Adja meg a felhasználó nevét vagy telefonszámát!");
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Eredeti név: {0} új: {1} |: ", utasok[opcio].name, name);
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Eredeti cím: {0} új: {1} |: ", utasok[opcio].cim, cim);
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Eredeti telefonszám: {0} új: {1} |: ", utasok[opcio].phoneNumber, phoneNumber);
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Modosítás");
                                consoleKey = mozgas(consoleKey);
                                if (consoleKey == ConsoleKey.Enter && cursorTops[0] == Console.CursorTop)
                                {
                                    Console.SetCursorPosition("( ) Eredeti név: {0} új: {1} |: ".Length + name.Length + utasok[opcio].name.Length, cursorTops[0]);
                                    name = Console.ReadLine();
                                }
                                else if (consoleKey == ConsoleKey.Enter && cursorTops[1] == Console.CursorTop)
                                {
                                    Console.SetCursorPosition("( ) Eredeti cím: {0} új: {1} |: ".Length + cim.Length + utasok[opcio].cim.Length, cursorTops[1]);
                                    cim = Console.ReadLine();
                                }
                                else if (consoleKey == ConsoleKey.Enter && cursorTops[2] == Console.CursorTop)
                                {
                                    Console.SetCursorPosition("( ) Eredeti telefonszám: {0} új: {1} |: ".Length + phoneNumber.Length + utasok[opcio].phoneNumber.Length, cursorTops[2]);
                                    phoneNumber = Console.ReadLine();
                                }
                                else if (consoleKey == ConsoleKey.Enter && cursorTops[3] == Console.CursorTop)
                                {
                                    UtasStruct ideiglenesUtas = new UtasStruct();
                                    ideiglenesUtas.id = utasok[opcio].id;
                                    if (name == "")
                                    {
                                        ideiglenesUtas.name = utasok[opcio].name;
                                    }
                                    else
                                    {
                                        ideiglenesUtas.name = name;
                                    }
                                    if (cim == "")
                                    {
                                        ideiglenesUtas.cim = utasok[opcio].cim;
                                    }
                                    else
                                    {
                                        ideiglenesUtas.cim = cim;
                                    }
                                    if (phoneNumber == "")
                                    {
                                        ideiglenesUtas.phoneNumber = utasok[opcio].phoneNumber;
                                    }
                                    else
                                    {
                                        ideiglenesUtas.phoneNumber = phoneNumber;
                                    }
                                    utasok[opcio] = ideiglenesUtas;
                                    filekezeles("save");
                                    consoleKey = ConsoleKey.Escape;
                                }
                            }
                            consoleKey = default;

                        }
                    }
                    consoleKey = default;


                }
                else if (consoleKey == ConsoleKey.Enter && cursorTops[1] == Console.CursorTop)
                {
                    while (consoleKey != ConsoleKey.Escape)
                    {
                        consoleKey = default;
                        Console.Clear();
                        cursorTops.Clear();
                        Console.WriteLine("Útvonalak kezelése menü");
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Út hozzáadása");
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Út módosítása");
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Út ----------");
                        consoleKey = mozgas(consoleKey);
                        if (consoleKey == ConsoleKey.Enter && cursorTops[0] == Console.CursorTop)//Út hozzáadása
                        {
                            Console.Clear();
                            cursorTops.Clear();
                            utNew(utak_adatbekeres("-uticel-ar-maxletszam-"));
                            filekezeles("save");
                        }
                        else if (consoleKey == ConsoleKey.Enter && cursorTops[1] == Console.CursorTop)//Ut módosítása
                        {
                            Console.Clear();
                            cursorTops.Clear();
                            strings.Clear();
                            for (int i = 0; i < utasok.Count; i++)
                            {
                                strings.Add($"{utak[i].id};{utak[i].uticel};{utak[i].ar};{utak[i].maxLetszam}");
                            }

                            opcio = TablaLista(strings, consoleKey, "utak");

                            string uticel = "";
                            int ar = 0;
                            int maxletszam = 0;
                            while (consoleKey != ConsoleKey.Escape)//ut modositasa!
                            {
                                Console.Clear();
                                cursorTops.Clear();
                                Console.WriteLine($"út módosítása (ha nem módosít akkor hadja üresen)");
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Eredeti uticel: {0} új: {1} |: ", utak[opcio].uticel, uticel);
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Eredeti ar: {0} új: {1} |: ", utak[opcio].ar, ar);
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Eredeti maximális létszám: {0} új: {1} |: ", utak[opcio].maxLetszam, maxletszam);
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Modosítás");
                                consoleKey = mozgas(consoleKey);
                                if (consoleKey == ConsoleKey.Enter && cursorTops[0] == Console.CursorTop)
                                {
                                    Console.SetCursorPosition("( ) Eredeti uticel: {0} új: {1} |: ".Length + uticel.Length, cursorTops[0]);
                                    uticel = Console.ReadLine();
                                }
                                else if (consoleKey == ConsoleKey.Enter && cursorTops[1] == Console.CursorTop)
                                {
                                    Console.SetCursorPosition("( ) Eredeti ar: {0} új: {1} |: ".Length + ar.ToString().Length, cursorTops[1]);
                                    ar = int.Parse(Console.ReadLine());
                                }
                                else if (consoleKey == ConsoleKey.Enter && cursorTops[2] == Console.CursorTop)
                                {
                                    Console.SetCursorPosition("( ) Eredeti maximális létszám: {0} új: {1} |: ".Length + maxletszam.ToString().Length, cursorTops[2]);
                                    maxletszam = int.Parse(Console.ReadLine());
                                }
                                else if (consoleKey == ConsoleKey.Enter && cursorTops[3] == Console.CursorTop)
                                {
                                    UtStruct ideiglenesUt = new UtStruct();
                                    ideiglenesUt.id = utak[opcio].id;
                                    if (uticel == "")
                                    {
                                        ideiglenesUt.uticel = utak[opcio].uticel;
                                    }
                                    else
                                    {
                                        ideiglenesUt.uticel = uticel;
                                    }
                                    if (ar == 0)
                                    {
                                        ideiglenesUt.ar = utak[opcio].ar;
                                    }
                                    else
                                    {
                                        ideiglenesUt.ar = ar;
                                    }
                                    if (maxletszam == 0)
                                    {
                                        ideiglenesUt.maxLetszam = utak[opcio].maxLetszam;
                                    }
                                    else
                                    {
                                        ideiglenesUt.maxLetszam = maxletszam;
                                    }
                                    utak[opcio] = ideiglenesUt;
                                    filekezeles("save");
                                    consoleKey = ConsoleKey.Escape;
                                }
                            }
                            consoleKey = default;

                        }
                    }
                    consoleKey = default;



                }
                else if (consoleKey == ConsoleKey.Enter && cursorTops[2] == Console.CursorTop)
                {
                    int utasElemszam;
                    int utElemszam;
                    while (consoleKey != ConsoleKey.Escape)
                    {
                        Console.Clear();
                        cursorTops.Clear();
                        strings.Clear();
                        for (int i = 0; i < utasok.Count; i++)
                        {
                            strings.Add($"{utasok[i].id};{utasok[i].name};{utasok[i].cim};{utasok[i].phoneNumber}");
                        }
                        Console.WriteLine("Válassza ki a felhasználót");
                        opcio = TablaLista(strings, consoleKey, "utas");
                        utasElemszam = opcio;
                        Console.Clear();
                        cursorTops.Clear();
                        strings.Clear();
                        for (int i = 0; i < utasok.Count; i++)
                        {
                            strings.Add($"{utak[i].id};{utak[i].uticel};{utak[i].ar};{utak[i].maxLetszam}");
                        }
                        Console.WriteLine("Válassza ki az útvonalat");
                        opcio = TablaLista(strings, consoleKey, "utak");
                        utElemszam = opcio;
                        Console.Clear();
                        cursorTops.Clear();
                        int van = -1;
                        int betoltottHelyek = 0;
                        for (int i = 0; i < foglalasok.Count; i++)
                        {
                            if (foglalasok[i].utasId == utasok[utasElemszam].id && foglalasok[i].utId == utak[utElemszam].id)
                            {
                                van = i;
                            }
                            if (foglalasok[i].utId == utak[utElemszam].id)
                            {
                                betoltottHelyek++;
                            }
                        }
                        if (van > -1)
                        {
                            int eloleg = 0;
                            while (consoleKey != ConsoleKey.Escape)//előleg!
                            {
                                Console.Clear();
                                cursorTops.Clear();
                                Console.WriteLine($"{utasok[utasElemszam].name} felhasználó már regisztrálva van az útvonalra");
                                Console.WriteLine($"útvonal: {utak[utElemszam].uticel}");
                                Console.WriteLine($"út teljes ára: {utak[utElemszam].ar}");
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Eddigi előleg: {0} további fizetés: {1} |: ", foglalasok[van].eloleg, eloleg);
                                Console.WriteLine($"összesen: {foglalasok[van].eloleg + eloleg}");
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Elfogadás");
                                consoleKey = mozgas(consoleKey);
                                if (consoleKey == ConsoleKey.Enter && cursorTops[0] == Console.CursorTop)
                                {
                                    Console.SetCursorPosition("( ) Eddigi előleg: {0} további fizetés: {1} |: ".Length + foglalasok[van].eloleg.ToString().Length + eloleg.ToString().Length, cursorTops[0]);
                                    eloleg = int.Parse(Console.ReadLine());
                                }
                                else if (consoleKey == ConsoleKey.Enter && cursorTops[1] == Console.CursorTop)
                                {
                                    if (utak[utElemszam].ar < (foglalasok[van].eloleg + eloleg))
                                    {
                                        Console.WriteLine("Az összeg túl nagy!");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        foglalasStruct ideiglenesFoglalas = new foglalasStruct();
                                        ideiglenesFoglalas.utId = utak[utElemszam].id;
                                        ideiglenesFoglalas.utasId = utasok[utasElemszam].id;
                                        ideiglenesFoglalas.eloleg = (eloleg + foglalasok[van].eloleg);
                                        foglalasok[van] = ideiglenesFoglalas;
                                        filekezeles("save");
                                    }
                                }
                            }


                        }
                        else
                        {
                            if (utak[utElemszam].maxLetszam <= betoltottHelyek)
                            {
                                Console.WriteLine("Az útvonal elérte a maximális létszámát");
                                Console.ReadLine();
                            }
                            else
                            {
                                foglalasStruct ideiglenesFoglalas = new foglalasStruct();
                                ideiglenesFoglalas.utId = utak[utElemszam].id;
                                ideiglenesFoglalas.utasId = utasok[utasElemszam].id;
                                ideiglenesFoglalas.eloleg = 0;
                                foglalasok.Add(ideiglenesFoglalas);
                                for (int i = 0; i < foglalasok.Count; i++)
                                {
                                    if (foglalasok[i].utasId == utasok[utasElemszam].id && foglalasok[i].utId == utak[utElemszam].id)
                                    {
                                        van = i;
                                    }
                                }
                                int eloleg = 0;
                                while (consoleKey != ConsoleKey.Escape)//előleg!
                                {
                                    Console.Clear();
                                    cursorTops.Clear();
                                    Console.WriteLine($"{utasok[utasElemszam].name} felhasználó regisztrálva lett az útvonalra");
                                    Console.WriteLine($"útvonal: {utak[utElemszam].uticel}");
                                    Console.WriteLine($"út teljes ára: {utak[utElemszam].ar}");
                                    cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Eddigi előleg: {0} további fizetés: {1} |: ", foglalasok[van].eloleg, eloleg);
                                    Console.WriteLine($"összesen: {foglalasok[van].eloleg + eloleg}");
                                    cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Elfogadás");
                                    consoleKey = mozgas(consoleKey);
                                    if (consoleKey == ConsoleKey.Enter && cursorTops[0] == Console.CursorTop)
                                    {
                                        Console.SetCursorPosition("( ) Eddigi előleg: {0} további fizetés: {1} |: ".Length + foglalasok[van].eloleg.ToString().Length + eloleg.ToString().Length, cursorTops[0]);
                                        eloleg = int.Parse(Console.ReadLine());
                                    }
                                    else if (consoleKey == ConsoleKey.Enter && cursorTops[1] == Console.CursorTop)
                                    {
                                        if (utak[utElemszam].ar < (foglalasok[van].eloleg + eloleg))
                                        {
                                            Console.WriteLine("Az összeg túl nagy!");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            ideiglenesFoglalas.utId = utak[utElemszam].id;//hiba lehet mert nem hozok létre uj példányt
                                            ideiglenesFoglalas.utasId = utasok[utasElemszam].id;
                                            ideiglenesFoglalas.eloleg = (eloleg + foglalasok[van].eloleg);
                                            foglalasok[van] = ideiglenesFoglalas;
                                            filekezeles("save");
                                        }
                                    }
                                }

                            }

                        }


                    }
                    consoleKey = default;



                }


            }
            consoleKey = default;
        }
        static int TablaLista(List<string> adatok, ConsoleKey consoleKey, string tipus)//táblalista(egy string lista amely a kiíratandó adatokat tartalmazza  ,  tartalmazza a consolekey-t  ,  egy tipust amely azt határozza meg , hogy mien adatokkal dolgozik és azon tipus alapján zajlódjanak a műveletek)
        {
            int pozitcio = 0;
            int pozitcio2 = 0;
            consoleKey = default;
            int kurzolpozicio = Console.CursorTop;
            int[] kozok = new int[adatok[0].Split(';').Length];
            for (int i = 0; i < kozok.Length; i++)
            {
                for (int j = 0; j < adatok.Count; j++)
                {
                    if (kozok[i] < adatok[j].Split(';')[i].Length)
                    {
                        kozok[i] = adatok[j].Split(';')[i].Length;
                    }
                }
            }
            while (consoleKey != ConsoleKey.Enter && consoleKey != ConsoleKey.Escape)
            {
                cursorTops.Clear();
                Console.SetCursorPosition(0, kurzolpozicio);
                Console.WriteLine("---");
                for (int i = pozitcio2; i < adatok.Count && i < pozitcio2 + maxview; i++)
                {
                    Console.WriteLine(hossz(80, 0, " "));
                }
                Console.SetCursorPosition(0, kurzolpozicio);

                Console.WriteLine("---");
                for (int i = pozitcio2; i < adatok.Count && i < pozitcio2 + maxview; i++)
                {
                    if (cursorTops.Count == pozitcio)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (tipus == "utas")
                    {
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) " + adatok[i]);
                    }
                    else if (tipus == "ut")
                    {
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) " + adatok[i]);
                    }
                    else
                    {
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) " + adatok[i]);
                    }
                    if (cursorTops.Count - 1 == pozitcio)
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
                Console.WriteLine("---");

                Console.SetCursorPosition(1, cursorTops[pozitcio]);
                consoleKey = Console.ReadKey().Key;

                switch (consoleKey)
                {
                    case ConsoleKey.UpArrow:
                        if (Console.CursorTop != cursorTops[0])
                        {
                            pozitcio--;
                        }
                        else if (pozitcio2 > 0)
                        {
                            pozitcio2--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Console.CursorTop != cursorTops[cursorTops.Count - 1])
                        {
                            pozitcio++;
                        }
                        else if (pozitcio2 < adatok.Count - maxview)
                        {
                            pozitcio2++;
                        }
                        break;
                    default:
                        break;
                }
            }
            return pozitcio2 + pozitcio;
        }

        static ConsoleKey mozgas(ConsoleKey consoleKey)
        {
            consoleKey = default;
            Console.SetCursorPosition(1, cursorTops[0]);
            while (consoleKey != ConsoleKey.Enter && consoleKey != ConsoleKey.Escape)
            {
                consoleKey = Console.ReadKey().Key;
                switch (consoleKey)
                {
                    case ConsoleKey.UpArrow:
                        if (Console.CursorTop != cursorTops[0])
                        {
                            Console.SetCursorPosition(1, cursorTops[cursorTops.IndexOf(Console.CursorTop) - 1]);
                        }
                        else
                        {
                            Console.SetCursorPosition(1, Console.CursorTop);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (Console.CursorTop != cursorTops[cursorTops.Count - 1])
                        {
                            Console.SetCursorPosition(1, cursorTops[cursorTops.IndexOf(Console.CursorTop) + 1]);
                        }
                        else
                        {
                            Console.SetCursorPosition(1, Console.CursorTop);
                        }
                        break;

                    case ConsoleKey.W:
                        if (Console.CursorTop != cursorTops[0])
                        {
                            Console.SetCursorPosition(1, cursorTops[cursorTops.IndexOf(Console.CursorTop) - 1]);
                        }
                        else
                        {
                            Console.SetCursorPosition(1, Console.CursorTop);
                        }
                        break;
                    case ConsoleKey.S:
                        if (Console.CursorTop != cursorTops[cursorTops.Count - 1])
                        {
                            Console.SetCursorPosition(1, cursorTops[cursorTops.IndexOf(Console.CursorTop) + 1]);
                        }
                        else
                        {
                            Console.SetCursorPosition(1, Console.CursorTop);
                        }
                        break;
                    default:
                        break;
                }
            }
            return consoleKey;
        }
        static string hossz(int hosz, int kivonando, string kitoltes)
        {
            string vege = "";
            int kulombseg = 0;
            if (hosz > kivonando)
            {
                kulombseg = hosz - kivonando;
            }
            else
            {
                kulombseg = kivonando - hosz;
            }
            for (int i = 0; i < kulombseg; i++)
            {
                vege += kitoltes;
            }
            return vege;
        }

        static UtStruct utak_adatbekeres(string parancs)
        {
            UtStruct ut = new UtStruct();
            if (parancs.Contains("-id-"))
            {
                Console.WriteLine("adja meg az azonosítót");
                ut.id = int.Parse(Console.ReadLine());
            }
            else
            {
                int index = 0;
                bool van = true;
                int szam = 0;
                while (van)
                {
                    index++;
                    szam = 0;
                    for (int i = 0; i < utak.Count; i++)
                    {
                        if (utak[i].id == index)
                        {
                            szam++;
                        }
                    }
                    if (szam == 0)
                    {
                        van = false;
                    }
                }
                ut.id = index;
            }
            if (parancs.Contains("-uticel-"))
            {
                Console.WriteLine("adja meg az uticélt");
                ut.uticel = Console.ReadLine();
            }
            if (parancs.Contains("-ar-"))
            {
                Console.WriteLine("adja meg az árát");
                ut.ar = int.Parse(Console.ReadLine());
            }
            if (parancs.Contains("-maxletszam-"))
            {
                Console.WriteLine("adja meg a maximális létszámát");
                ut.maxLetszam = int.Parse(Console.ReadLine());
            }
            return ut;
        }
        static void ut_Delete(UtStruct ut_delete)
        {
            for (int i = 0; i < utasok.Count; i++)
            {
                if (!(ut_delete.uticel == "" && ut_delete.ar == 0 && ut_delete.id == 0 && ut_delete.maxLetszam == 0) &&
                    (ut_delete.uticel == "" ? true : utak[i].uticel == ut_delete.uticel &&
                    ut_delete.ar == 0 ? true : utak[i].ar == ut_delete.ar &&
                    ut_delete.id == 0 ? true : utak[i].id == ut_delete.id &&
                    ut_delete.maxLetszam == 0 ? true : utak[i].maxLetszam == ut_delete.maxLetszam))
                {
                    utak.RemoveAt(i);
                }
            }
            filekezeles("save");
        }
        static void utNew(UtStruct ut_new)
        {
            utak.Add(ut_new);
            filekezeles("save");
        }

        static UtasStruct utas_adatbekeres(string parancs)
        {
            UtasStruct utas = new UtasStruct();
            if (parancs.Contains("-id-"))
            {
                Console.WriteLine("adja meg az azonosítót");
                utas.id = int.Parse(Console.ReadLine());
            }
            else
            {
                int index = 0;
                bool van = true;
                int szam = 0;
                while (van)
                {
                    index++;
                    szam = 0;
                    for (int i = 0; i < utasok.Count; i++)
                    {
                        if (utasok[i].id == index)
                        {
                            szam++;
                        }
                    }
                    if (szam == 0)
                    {
                        van = false;
                    }
                }
                utas.id = index;
            }
            if (parancs.Contains("-name-"))
            {
                Console.WriteLine("adja meg az utas nevét");
                utas.name = Console.ReadLine();
            }
            if (parancs.Contains("-cim-"))
            {
                Console.WriteLine("adja meg az utas címét");
                utas.cim = Console.ReadLine();
            }
            if (parancs.Contains("-phonenumber-"))
            {
                Console.WriteLine("adja meg az utas telefonszámát");
                utas.phoneNumber = Console.ReadLine();
            }
            return utas;
        }
        static void utas_Delete(UtasStruct utas_delete)
        {
            for (int i = 0; i < utasok.Count; i++)
            {
                if (!(utas_delete.name == "" && utas_delete.cim == "" && utas_delete.id == 0 && utas_delete.phoneNumber == "") &&
                    (utas_delete.name == "" ? true : utasok[i].name == utas_delete.name &&
                    utas_delete.cim == "" ? true : utasok[i].cim == utas_delete.cim &&
                    utas_delete.id == 0 ? true : utasok[i].id == utas_delete.id &&
                    utas_delete.phoneNumber == "" ? true : utasok[i].phoneNumber == utas_delete.phoneNumber))
                {
                    utasok.RemoveAt(i);
                }
            }
            filekezeles("save");
        }
        static void utasNew(UtasStruct utas_new)
        {
            utasok.Add(utas_new);
            filekezeles("save");
        }

        static void filekezeles(string parancs)
        {
            if (parancs == "save")
            {//beiratom
                StreamWriter mentes = new StreamWriter("utasok.txt");
                for (int i = 0; i < utasok.Count(); i++)
                {
                    mentes.WriteLine($"{utasok[i].id}\t{utasok[i].name}\t{utasok[i].cim}\t{utasok[i].phoneNumber}");
                }
                mentes.Close();

                StreamWriter mentes2 = new StreamWriter("utak.txt");
                for (int i = 0; i < utak.Count(); i++)
                {
                    mentes2.WriteLine($"{utak[i].id}\t{utak[i].uticel}\t{utak[i].ar}\t{utak[i].maxLetszam}");
                }
                mentes2.Close();

                StreamWriter mentes3 = new StreamWriter("MAIN.txt");
                for (int i = 0; i < foglalasok.Count(); i++)
                {
                    mentes3.WriteLine($"{foglalasok[i].utasId}\t{foglalasok[i].utId}\t{foglalasok[i].eloleg}");
                }
                mentes3.Close();


            }
            else if (parancs == "load")
            {
                string[] beolvasas = File.ReadAllLines("MAIN.txt");
                for (int i = 0; i < beolvasas.Length; i++)
                {//beolvasom
                    foglalasStruct ujFoglalas = new foglalasStruct();
                    ujFoglalas.utasId = int.Parse(beolvasas[i].Split('\t')[0]);
                    ujFoglalas.utId = int.Parse(beolvasas[i].Split('\t')[1]);
                    ujFoglalas.eloleg = int.Parse(beolvasas[i].Split('\t')[2]);
                    foglalasok.Add(ujFoglalas);
                }

                string[] beolvasas2 = File.ReadAllLines("utasok.txt");
                for (int i = 0; i < beolvasas2.Length; i++)
                {
                    UtasStruct ujutasok = new UtasStruct();
                    ujutasok.id = int.Parse(beolvasas2[i].Split('\t')[0]);
                    ujutasok.name = beolvasas2[i].Split('\t')[1];
                    ujutasok.cim = beolvasas2[i].Split('\t')[2];
                    ujutasok.phoneNumber = beolvasas2[i].Split('\t')[3];
                    utasok.Add(ujutasok);
                }

                string[] beolvasas3 = File.ReadAllLines("utak.txt");
                for (int i = 0; i < beolvasas3.Length; i++)
                {
                    UtStruct ujutak = new UtStruct();
                    ujutak.id = int.Parse(beolvasas3[i].Split('\t')[0]);
                    ujutak.uticel = beolvasas3[i].Split('\t')[1];
                    ujutak.ar = int.Parse(beolvasas3[i].Split('\t')[2]);
                    ujutak.maxLetszam = int.Parse(beolvasas3[i].Split('\t')[3]);
                    utak.Add(ujutak);
                }

            }
            else
            {//létrehozom
                if (!File.Exists("utasok.txt"))
                {
                    StreamWriter utasok = new StreamWriter("utasok.txt");
                    utasok.Close();

                }
                if (!File.Exists("utak.txt"))
                {
                    StreamWriter utak = new StreamWriter("utak.txt");
                    utak.Close();

                }
                if (!File.Exists("MAIN.txt"))
                {
                    StreamWriter main = new StreamWriter("MAIN.txt");
                    main.Close();

                }
            }
        }
    }
}