using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ingatlanok
{

    // ezen adatsructurák a program adatkezeléséhez szükségesek
    #region adatstrukturak 
    struct tablastruct
    {
        public int opcio;
        public ConsoleKey consoleKey;
    }
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
   
    class Adatkezeles //enez class alapot nyujt minden adatListának
    {
        public foglalasStruct foglalas;
        public UtasStruct utas;
        public UtStruct ut;

        public Adatkezeles(int id,string name,string cim, string phoneNumber)//utas adatai
        {
            utas.id = id;
            utas.name = name;
            utas.cim = cim;
            utas.phoneNumber = phoneNumber;
        }
        public Adatkezeles(int id,string uticel,int ar,int maxletszam)//ut adatai
        {
            ut.id = id;
            ut.uticel = uticel;
            ut.ar = ar;
            ut.maxLetszam = maxletszam;
        }
        public Adatkezeles(int utasId,int utId,int eloleg)//foglalás adatai
        {
            foglalas.utasId = utasId;
            foglalas.utId = utId;
            foglalas.eloleg = eloleg;
        }
    }
    class Tabla //ezen class a táblalistát és a hozzá tartozó segég fügvényt tartalmazza
    {
        //a hossz fügvény 3 adatból ami a szöveg hossza , egy kivonandó szöveg hossza , és a kitöltés adat. ezen adatokból állít elő egy karaktersorozatot
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

        //a Táblalista azt a célt szolgálja, hogy egy adott string Listát szépen "tipusnak" megfelelően kiírathasson és azon belül egy elem kerüljön kiválasztásra
        public static tablastruct Tablalista(List<string> adatok, ConsoleKey consoleKey, string tipus, List<int> cursorTops, int maxview, bool jelzes)
        {
            int pozitcio = 0;
            int pozitcio2 = 0;
            consoleKey = default;
            int kurzolpozicio = Console.CursorTop;
            int[] kozok = new int[adatok[0].Split(';').Length];
            for (int i = 0; i < kozok.Length; i++)//a leghosszabb adat hossza elemenként
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
                        cursorTops.Add(Console.CursorTop); Console.WriteLine($"( ) {adatok[i].Split(';')[0]}{hossz(kozok[0] + 1, adatok[i].Split(';')[0].Length, " ")}{adatok[i].Split(';')[1]}{hossz(kozok[1] + 1, adatok[i].Split(';')[1].Length, " ")}{adatok[i].Split(';')[2]}{hossz(kozok[2] + 1, adatok[i].Split(';')[2].Length, " ")}{adatok[i].Split(';')[3]}");
                    }
                    else if (tipus == "utak")
                    {
                        cursorTops.Add(Console.CursorTop); Console.WriteLine($"( ) {adatok[i].Split(';')[0]}{hossz(kozok[0] + 1, adatok[i].Split(';')[0].Length," ")}{adatok[i].Split(';')[1]}{hossz(kozok[1] + 1, adatok[i].Split(';')[1].Length," ")}{adatok[i].Split(';')[2]}{hossz(kozok[2] + 1, adatok[i].Split(';')[2].Length," ")}{adatok[i].Split(';')[3]}");
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

            tablastruct tablastruct = new tablastruct();
            tablastruct.opcio = pozitcio2 + pozitcio;
            tablastruct.consoleKey = consoleKey;
            return tablastruct;

        }
    }
    internal class Program
    {

        //ezek a programban folyó adatok listái
        #region program adatai
        static List<Adatkezeles> utasok = new List<Adatkezeles>();
        static List<Adatkezeles> utak = new List<Adatkezeles>();
        static List<Adatkezeles> foglalasok = new List<Adatkezeles>();
        #endregion

        //ezen változók a fügvények bemeneti és kimeneti értékei melyek befolyásolják a program döntéshozatalát
        #region modulvaltozok
        static List<int> cursorTops = new List<int>();//a kurzol ideiglenes pozitciojanak valtozoja
        static int maxview = 4;//a táblalista maximálisan egyszerre láthatő elemeinek száma
        static List<string> strings = new List<string>();//a tablalista számára befogadható adatlista melyet a táblabeviteli lista előtt adunk adatot illetve változtatjuk
        static int opcio = 0;//a táblalista által visszadott szám, mely annak az adatlisat elemindexet adja vissza amely adatlistából a "strings" lista készült. 
        static tablastruct tablastruct;//a TablaLista visszatérő speciális értéke
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
            while (consoleKey != ConsoleKey.Escape)//fő menü
            {
                Console.Clear();
                cursorTops.Clear();
                Console.WriteLine("Fő Menü (Kilépés: Esc)  (Kiválasztás: Enter)");
                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Utasok Kezelése");
                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Útazások Kezelése");
                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Útvonalfoglalás");
                consoleKey = mozgas(consoleKey);
                if (consoleKey == ConsoleKey.Enter && cursorTops[0] == Console.CursorTop) //utaskezelési menü
                {
                    while (consoleKey != ConsoleKey.Escape)
                    {
                        consoleKey = default;
                        Console.Clear();
                        cursorTops.Clear();
                        Console.WriteLine("Utasok kezelése menü");
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Utas hozzáadása");
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Utas módosítása");
                        cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Utas ----------");//a törlés menüpont nem áll randelkezésre!
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
                                strings.Add($"{utasok[i].utas.id};{utasok[i].utas.name};{utasok[i].utas.cim};{utasok[i].utas.phoneNumber}");
                            }

                            tablastruct = Tabla.Tablalista(strings,consoleKey,"utas",cursorTops,maxview,true);
                            opcio = tablastruct.opcio;
                            consoleKey = tablastruct.consoleKey;
                            
                            string name = "";
                            string cim = "";
                            string phoneNumber = "";
                            while (consoleKey != ConsoleKey.Escape)
                            {
                                Console.Clear();
                                cursorTops.Clear();
                                Console.WriteLine($"{utasok[opcio].utas.name} utas módosítása (ha nem módosít akkor hadja üresen)");
                                Console.WriteLine("Adja meg a felhasználó nevét vagy telefonszámát!");
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Eredeti név: {0} új: {1} |: ", utasok[opcio].utas.name, name);
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Eredeti cím: {0} új: {1} |: ", utasok[opcio].utas.cim, cim);
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Eredeti telefonszám: {0} új: {1} |: ", utasok[opcio].utas.phoneNumber, phoneNumber);
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Modosítás");
                                consoleKey = mozgas(consoleKey);
                                if (consoleKey == ConsoleKey.Enter && cursorTops[0] == Console.CursorTop)
                                {
                                    Console.SetCursorPosition("( ) Eredeti név: {0} új: {1} |: ".Length + name.Length + utasok[opcio].utas.name.Length, cursorTops[0]);
                                    name = Console.ReadLine();
                                }
                                else if (consoleKey == ConsoleKey.Enter && cursorTops[1] == Console.CursorTop)
                                {
                                    Console.SetCursorPosition("( ) Eredeti cím: {0} új: {1} |: ".Length + cim.Length + utasok[opcio].utas.cim.Length, cursorTops[1]);
                                    cim = Console.ReadLine();
                                }
                                else if (consoleKey == ConsoleKey.Enter && cursorTops[2] == Console.CursorTop)
                                {
                                    Console.SetCursorPosition("( ) Eredeti telefonszám: {0} új: {1} |: ".Length + phoneNumber.Length + utasok[opcio].utas.phoneNumber.Length, cursorTops[2]);
                                    phoneNumber = Console.ReadLine();
                                }
                                else if (consoleKey == ConsoleKey.Enter && cursorTops[3] == Console.CursorTop)
                                {
                                    UtasStruct ideiglenesUtas = new UtasStruct();
                                    ideiglenesUtas.id = utasok[opcio].utas.id;
                                    if (name == "")
                                    {
                                        ideiglenesUtas.name = utasok[opcio].utas.name;
                                    }
                                    else
                                    {
                                        ideiglenesUtas.name = name;
                                    }
                                    if (cim == "")
                                    {
                                        ideiglenesUtas.cim = utasok[opcio].utas.cim;
                                    }
                                    else
                                    {
                                        ideiglenesUtas.cim = cim;
                                    }
                                    if (phoneNumber == "")
                                    {
                                        ideiglenesUtas.phoneNumber = utasok[opcio].utas.phoneNumber;
                                    }
                                    else
                                    {
                                        ideiglenesUtas.phoneNumber = phoneNumber;
                                    }
                                    Adatkezeles Utas = new Adatkezeles(ideiglenesUtas.id,ideiglenesUtas.name,ideiglenesUtas.cim,ideiglenesUtas.phoneNumber);
                                    utasok[opcio] = Utas;
                                    filekezeles("save");
                                    consoleKey = ConsoleKey.Escape;
                                }
                            }
                            consoleKey = default;

                        }
                    }
                    consoleKey = default;


                }
                else if (consoleKey == ConsoleKey.Enter && cursorTops[1] == Console.CursorTop)//útkezelési menü
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
                                strings.Add($"{utak[i].ut.id};{utak[i].ut.uticel};{utak[i].ut.ar};{utak[i].ut.maxLetszam}");
                            }

                            tablastruct = Tabla.Tablalista(strings, consoleKey, "utak", cursorTops, maxview,true);
                            opcio = tablastruct.opcio;
                            consoleKey = tablastruct.consoleKey;

                            string uticel = "";
                            int ar = 0;
                            int maxletszam = 0;
                            while (consoleKey != ConsoleKey.Escape)//ut modositasa!
                            {
                                Console.Clear();
                                cursorTops.Clear();
                                Console.WriteLine($"út módosítása (ha nem módosít akkor hadja üresen)");
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Eredeti uticel: {0} új: {1} |: ", utak[opcio].ut.uticel, uticel);
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Eredeti ar: {0} új: {1} |: ", utak[opcio].ut.ar, ar);
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Eredeti maximális létszám: {0} új: {1} |: ", utak[opcio].ut.maxLetszam, maxletszam);
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
                                    ideiglenesUt.id = utak[opcio].ut.id;
                                    if (uticel == "")
                                    {
                                        ideiglenesUt.uticel = utak[opcio].ut.uticel;
                                    }
                                    else
                                    {
                                        ideiglenesUt.uticel = uticel;
                                    }
                                    if (ar == 0)
                                    {
                                        ideiglenesUt.ar = utak[opcio].ut.ar;
                                    }
                                    else
                                    {
                                        ideiglenesUt.ar = ar;
                                    }
                                    if (maxletszam == 0)
                                    {
                                        ideiglenesUt.maxLetszam = utak[opcio].ut.maxLetszam;
                                    }
                                    else
                                    {
                                        ideiglenesUt.maxLetszam = maxletszam;
                                    }
                                    Adatkezeles ut = new Adatkezeles(ideiglenesUt.id, ideiglenesUt.uticel, ideiglenesUt.ar, ideiglenesUt.maxLetszam);
                                    utak[opcio] = ut;
                                    filekezeles("save");
                                    consoleKey = ConsoleKey.Escape;
                                }
                            }
                            consoleKey = default;

                        }
                    }
                    consoleKey = default;



                }
                else if (consoleKey == ConsoleKey.Enter && cursorTops[2] == Console.CursorTop)//foglalások menü
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
                            strings.Add($"{utasok[i].utas.id};{utasok[i].utas.name};{utasok[i].utas.cim};{utasok[i].utas.phoneNumber}");
                        }
                        Console.WriteLine("Válassza ki a felhasználót");//felhasználó kiválasztás menü
                        tablastruct = Tabla.Tablalista(strings, consoleKey, "utas",cursorTops,maxview,true);
                        utasElemszam = tablastruct.opcio;
                        if (tablastruct.consoleKey == ConsoleKey.Escape)
                        {
                            break;
                        }
                        Console.Clear();
                        cursorTops.Clear();
                        strings.Clear();
                        for (int i = 0; i < utasok.Count; i++)
                        {
                            strings.Add($"{utak[i].ut.id};{utak[i].ut.uticel};{utak[i].ut.ar};{utak[i].ut.maxLetszam}");
                        }
                        Console.WriteLine("Válassza ki az útvonalat");//útvonal kiválasztás menü
                        tablastruct = Tabla.Tablalista(strings, consoleKey, "utak",cursorTops,maxview,true);
                        utElemszam = tablastruct.opcio;
                        if (tablastruct.consoleKey == ConsoleKey.Escape)
                        {
                            break;
                        }
                        Console.Clear();
                        cursorTops.Clear();
                        int van = -1;
                        int betoltottHelyek = 0;
                        for (int i = 0; i < foglalasok.Count; i++)
                        {
                            if (foglalasok[i].foglalas.utasId == utasok[utasElemszam].utas.id && foglalasok[i].foglalas.utId == utak[utElemszam].ut.id)
                            {
                                van = i;
                            }
                            if (foglalasok[i].foglalas.utId == utak[utElemszam].ut.id)
                            {
                                betoltottHelyek++;
                            }
                        }
                        if (van > -1)//már egy felhasználó által regisztrált útvonala
                        {
                            int eloleg = 0;
                            while (consoleKey != ConsoleKey.Escape)//előleg menü
                            {
                                Console.Clear();
                                cursorTops.Clear();
                                Console.WriteLine($"{utasok[utasElemszam].utas.name} felhasználó már regisztrálva van az útvonalra");
                                Console.WriteLine($"útvonal: {utak[utElemszam].ut.uticel}");
                                Console.WriteLine($"út teljes ára: {utak[utElemszam].ut.ar}");
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Eddigi előleg: {0} további fizetés: {1} |: ", foglalasok[van].foglalas.eloleg, eloleg);
                                Console.WriteLine($"összesen: {foglalasok[van].foglalas.eloleg + eloleg}");
                                cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Elfogadás");
                                consoleKey = mozgas(consoleKey);
                                if (consoleKey == ConsoleKey.Enter && cursorTops[0] == Console.CursorTop)
                                {
                                    Console.SetCursorPosition("( ) Eddigi előleg: {0} további fizetés: {1} |: ".Length + foglalasok[van].foglalas.eloleg.ToString().Length + eloleg.ToString().Length, cursorTops[0]);
                                    eloleg = int.Parse(Console.ReadLine());
                                }
                                else if (consoleKey == ConsoleKey.Enter && cursorTops[1] == Console.CursorTop)
                                {
                                    if (utak[utElemszam].ut.ar < (foglalasok[van].foglalas.eloleg + eloleg))
                                    {
                                        Console.WriteLine("Az összeg túl nagy!");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        Adatkezeles foglalas = new Adatkezeles(utak[utElemszam].ut.id, utasok[utasElemszam].utas.id, eloleg + foglalasok[van].foglalas.eloleg);
                                        foglalasok[van] = foglalas;
                                        filekezeles("save");
                                    }
                                }
                            }


                        }
                        else// egy felhasználó új útvonala
                        {
                            if (utak[utElemszam].ut.maxLetszam <= betoltottHelyek)
                            {
                                Console.WriteLine("Az útvonal elérte a maximális létszámát");
                                Console.ReadLine();
                            }
                            else
                            {

                                Adatkezeles foglalas = new Adatkezeles(utasok[utasElemszam].utas.id, utak[utElemszam].ut.id,0);
                                foglalasok.Add(foglalas);
                                for (int i = 0; i < foglalasok.Count; i++)
                                {
                                    if (foglalasok[i].foglalas.utasId == utasok[utasElemszam].utas.id && foglalasok[i].foglalas.utId == utak[utElemszam].ut.id)
                                    {
                                        van = i;
                                    }
                                }
                                int eloleg = 0;
                                while (consoleKey != ConsoleKey.Escape)//előleg!
                                {
                                    Console.Clear();
                                    cursorTops.Clear();
                                    Console.WriteLine($"{utasok[utasElemszam].utas.name} felhasználó regisztrálva lett az útvonalra");
                                    Console.WriteLine($"útvonal: {utak[utElemszam].ut.uticel}");
                                    Console.WriteLine($"út teljes ára: {utak[utElemszam].ut.ar}");
                                    cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Eddigi előleg: {0} további fizetés: {1} |: ", foglalasok[van].foglalas.eloleg, eloleg);
                                    Console.WriteLine($"összesen: {foglalasok[van].foglalas.eloleg + eloleg}");
                                    cursorTops.Add(Console.CursorTop); Console.WriteLine("( ) Elfogadás");
                                    consoleKey = mozgas(consoleKey);
                                    if (consoleKey == ConsoleKey.Enter && cursorTops[0] == Console.CursorTop)
                                    {
                                        Console.SetCursorPosition("( ) Eddigi előleg: {0} további fizetés: {1} |: ".Length + foglalasok[van].foglalas.eloleg.ToString().Length + eloleg.ToString().Length, cursorTops[0]);
                                        eloleg = int.Parse(Console.ReadLine());
                                    }
                                    else if (consoleKey == ConsoleKey.Enter && cursorTops[1] == Console.CursorTop)
                                    {
                                        if (utak[utElemszam].ut.ar < (foglalasok[van].foglalas.eloleg + eloleg))
                                        {
                                            Console.WriteLine("Az összeg túl nagy!");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            foglalas = new Adatkezeles(utak[utElemszam].ut.id,utasok[utasElemszam].utas.id,eloleg + foglalasok[van].foglalas.eloleg);
                                            foglalasok[van] = foglalas;
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
                        if (utak[i].ut.id == index)
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
                    (ut_delete.uticel == "" ? true : utak[i].ut.uticel == ut_delete.uticel &&
                    ut_delete.ar == 0 ? true : utak[i].ut.ar == ut_delete.ar &&
                    ut_delete.id == 0 ? true : utak[i].ut.id == ut_delete.id &&
                    ut_delete.maxLetszam == 0 ? true : utak[i].ut.maxLetszam == ut_delete.maxLetszam))
                {
                    utak.RemoveAt(i);
                }
            }
            filekezeles("save");
        }
        static void utNew(UtStruct ut_new)
        {
            Adatkezeles ut = new Adatkezeles(ut_new.id,ut_new.uticel,ut_new.ar,ut_new.maxLetszam);
            utak.Add(ut);
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
                        if (utasok[i].utas.id == index)
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
                    (utas_delete.name == "" ? true : utasok[i].utas.name == utas_delete.name &&
                    utas_delete.cim == "" ? true : utasok[i].utas.cim == utas_delete.cim &&
                    utas_delete.id == 0 ? true : utasok[i].utas.id == utas_delete.id &&
                    utas_delete.phoneNumber == "" ? true : utasok[i].utas.phoneNumber == utas_delete.phoneNumber))
                {
                    utasok.RemoveAt(i);
                }
            }
            filekezeles("save");
        }
        static void utasNew(UtasStruct utas_new)
        {
            Adatkezeles utas = new Adatkezeles(utas_new.id,utas_new.name,utas_new.cim,utas_new.phoneNumber);
            utasok.Add(utas);
            filekezeles("save");
        }

        static void filekezeles(string parancs)
        {
            if (parancs == "save")
            {//beiratom
                StreamWriter mentes = new StreamWriter("utasok.txt");
                for (int i = 0; i < utasok.Count(); i++)
                {
                    mentes.WriteLine($"{utasok[i].utas.id}\t{utasok[i].utas.name}\t{utasok[i].utas.cim}\t{utasok[i].utas.phoneNumber}");
                }
                mentes.Close();

                StreamWriter mentes2 = new StreamWriter("utak.txt");
                for (int i = 0; i < utak.Count(); i++)
                {
                    mentes2.WriteLine($"{utak[i].ut.id}\t{utak[i].ut.uticel}\t{utak[i].ut.ar}\t{utak[i].ut.maxLetszam}");
                }
                mentes2.Close();

                StreamWriter mentes3 = new StreamWriter("MAIN.txt");
                for (int i = 0; i < foglalasok.Count(); i++)
                {
                    mentes3.WriteLine($"{foglalasok[i].foglalas.utasId}\t{foglalasok[i].foglalas.utId}\t{foglalasok[i].foglalas.eloleg}");
                }
                mentes3.Close();


            }
            else if (parancs == "load")
            {
                string[] beolvasas = File.ReadAllLines("MAIN.txt");
                for (int i = 0; i < beolvasas.Length; i++)
                {//beolvasom
                    Adatkezeles foglalas = new Adatkezeles(int.Parse(beolvasas[i].Split('\t')[0]), int.Parse(beolvasas[i].Split('\t')[1]), int.Parse(beolvasas[i].Split('\t')[2]));
                    foglalasok.Add(foglalas);
                }

                string[] beolvasas2 = File.ReadAllLines("utasok.txt");
                for (int i = 0; i < beolvasas2.Length; i++)
                {
                    Adatkezeles utas = new Adatkezeles(int.Parse(beolvasas2[i].Split('\t')[0]), beolvasas2[i].Split('\t')[1], beolvasas2[i].Split('\t')[2], beolvasas2[i].Split('\t')[3]);
                    utasok.Add(utas);
                }

                string[] beolvasas3 = File.ReadAllLines("utak.txt");
                for (int i = 0; i < beolvasas3.Length; i++)
                {
                    Adatkezeles ut = new Adatkezeles(int.Parse(beolvasas3[i].Split('\t')[0]), beolvasas3[i].Split('\t')[1], int.Parse(beolvasas3[i].Split('\t')[2]), int.Parse(beolvasas3[i].Split('\t')[3]));
                    utak.Add(ut);
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