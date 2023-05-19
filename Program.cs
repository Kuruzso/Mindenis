using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace farfga
{
    class Program
    {
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
        struct Foglalás
        {
            public int utasId;
            public int utId;
            public int eloleg;
        }

        static List<UtasStruct> utasok = new List<UtasStruct>();
        static List<UtStruct> utak = new List<UtStruct>();
        static List<Foglalás> foglalasok = new List<Foglalás>();

        static void filekezeles(string parancs)
        {
            if (parancs =="save")
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
                for (int i = 0; i < foglalasok.Count(); i++)
                {//beolvasom
                    Foglalás ujFoglalas = new Foglalás();
                    ujFoglalas.utasId = int.Parse(beolvasas[i].Split('\t')[0]);
                    ujFoglalas.utId = int.Parse(beolvasas[i].Split('\t')[1]);
                    ujFoglalas.eloleg = int.Parse(beolvasas[i].Split('\t')[2]);
                    foglalasok.Add(ujFoglalas);
                }

                string[] beolvasas2 = File.ReadAllLines("utasok.txt");
                for (int i = 0; i < utasok.Count(); i++)
                {
                    UtasStruct ujutasok = new UtasStruct();
                    ujutasok.id = int.Parse(beolvasas2[i].Split('\t')[0]);
                    ujutasok.name = beolvasas2[i].Split('\t')[1];
                    ujutasok.cim = beolvasas2[i].Split('\t')[2];
                    ujutasok.phoneNumber = beolvasas2[i].Split('\t')[3];
                    utasok.Add(ujutasok);
                }

                string[] beolvasas3 = File.ReadAllLines("utak.txt");
                for (int i = 0; i < utasok.Count(); i++)
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
            if (parancs.Contains("-name-"))
            {
                Console.WriteLine("adja meg az utas nevét");
                ut.uticel = Console.ReadLine();
            }
            if (parancs.Contains("-cim-"))
            {
                Console.WriteLine("adja meg az utas címét");
                ut.ar = int.Parse(Console.ReadLine());
            }
            if (parancs.Contains("-phonenumber-"))
            {
                Console.WriteLine("adja meg az utas telefonszámát");
                ut.maxLetszam = int.Parse(Console.ReadLine());
            }
            return ut;
        }
        static void ut_Delete(UtStruct ut_delete)
        {
            for (int i = 0; i < utasok.Count; i++)
            {
                if (!(ut_delete.uticel == "" && ut_delete.ar == 0 && ut_delete.id == 0 && ut_delete.maxLetszam == 0) &&
                    (ut_delete.uticel == "" ? true : utasok[i].name == ut_delete.uticel &&
                    ut_delete.ar == 0 ? true : utak[i].ar == ut_delete.ar &&
                    ut_delete.id == 0 ? true : utak[i].id == ut_delete.id &&
                    ut_delete.maxLetszam == 0 ? true : utak[i].maxLetszam == ut_delete.maxLetszam))
                {
                    utasok.RemoveAt(i);
                }
            }
            filekezeles("save");
        }
        static void utNew(UtStruct ut_new)
        {
            utak.Add(ut_new);
            filekezeles("save");
        }

        //parancs lehet "load" vagy "save"
        static void Main(string[] args)
        {
        
        }
    }
}
