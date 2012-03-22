using System;
using System.Collections.Generic;
using System.IO;


public class Kalendarz
{
    private Dictionary<Data_dzien, List<Wpis>> kalendarz;
    private bool wyswietlajMiesiacSlownie;

    public Kalendarz()
    {
        //Wczytaj("init.dat");
    }

    public void Wczytaj(string plik)
    {
        StreamReader sr = new StreamReader(plik);

        string linia;
        while ((linia = sr.ReadLine()) != null)
        {
            //wczytywanie daty
            int rok = Convert.ToInt32(linia);
            int miesiac = Convert.ToInt32(sr.ReadLine());
            int dzien = Convert.ToInt32(sr.ReadLine());
            Data_dzien tmp_dzien = new Data_dzien(rok, miesiac, dzien); //tworzenie daty

            //wczytywanie listy
            List<Wpis> tmp_list = new List<Wpis>() { };
            while ((linia = sr.ReadLine()) != "-=NASTÊPNY WPIS=-")
            {
                string tytu³ = linia;
                int godz_p = Convert.ToInt32(sr.ReadLine());
                int min_p = Convert.ToInt32(sr.ReadLine());
                Data data_pocz = new Data(rok, miesiac, dzien, godz_p, min_p);

                int godz_k = Convert.ToInt32(sr.ReadLine());
                int min_k = Convert.ToInt32(sr.ReadLine());
                Data data_kon = new Data(rok, miesiac, dzien, godz_k, min_k);
                tmp_list.Add(new Wpis(data_pocz, data_kon, tytu³));
            }

            kalendarz.Add(tmp_dzien, tmp_list);
        }
    }
    public void Zapisz(string plik)
    {
        StreamWriter sw = new StreamWriter(plik);

        var nast = kalendarz.Keys.GetEnumerator();
        while (nast.MoveNext())
        {
            Data_dzien tmp = nast.Current;
            //zapisywanie daty
            sw.WriteLine(tmp.Rok());
            sw.WriteLine(tmp.Miesiac());
            sw.WriteLine(tmp.Dzien());
            //----------------------------

            List<Wpis> tmp_list = kalendarz[nast.Current];
            int iloœæ_wpisów = tmp_list.Count;
            //zapisywanie listy wpisów do pliku
            for (int i = 0; i < iloœæ_wpisów; i++)
            {
                sw.WriteLine(tmp_list[i].Tytul());
                sw.WriteLine(tmp_list[i].Poczatek().Godzina());
                sw.WriteLine(tmp_list[i].Poczatek().Minuta());
                sw.WriteLine(tmp_list[i].Koniec().Godzina());
                sw.WriteLine(tmp_list[i].Koniec()  .Minuta());
            }

            sw.WriteLine("-=NASTÊPNY WPIS=-"); //separator
        }
    }
    public Data_dzien Dodaj(Wpis wpis)
    {
        throw new System.Exception("Not implemented");
    }
    public List<Wpis> WpisyDnia(Data_dzien dzien)
    {
        throw new System.Exception("Not implemented");
    }
    public Wpis SzukajWpis(string tytul)
    {
        throw new System.Exception("Not implemented");
    }
}
