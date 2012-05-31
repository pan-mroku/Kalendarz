using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

[Serializable]
public class Kalendarz
{
    private Dictionary<Data_dzien, List<Wpis>> kalendarz;
    private bool wyswietlajMiesiacSlownie;

    public Kalendarz()
    {
        kalendarz = new Dictionary<Data_dzien, List<Wpis>>();
        wyswietlajMiesiacSlownie = true;
    }

    public void Wczytaj(Stream plik)
    {
        BinaryFormatter bf = new BinaryFormatter();
        Kalendarz tmp = (Kalendarz)bf.Deserialize(plik);
        kalendarz = tmp.kalendarz;
        wyswietlajMiesiacSlownie = tmp.wyswietlajMiesiacSlownie;


        /*StreamReader sr = new StreamReader(plik);

        string linia;
        while ((linia = sr.ReadLine()) != null)
        {
            //wczytywanie daty
            int rok = Convert.ToInt32(linia);
            int miesiac = Convert.ToInt32(sr.ReadLine());
            int dzien = Convert.ToInt32(sr.ReadLine());
            Data_dzien tmp_dzien = new Data_dzien(rok, miesiac, dzien); //tworzenie daty

            //wczytywanie listy zdażeń
            List<Wpis> tmp_list = new List<Wpis>() { };
            while ((linia = sr.ReadLine()) != "-=NASTĘPNY WPIS=-")
            {
                string tytuł = linia;
                int godz_p = Convert.ToInt32(sr.ReadLine()); //godzina - początek zdażenia
                int min_p = Convert.ToInt32(sr.ReadLine()); //minuty - początek zdażenia
                Data data_pocz = new Data(rok, miesiac, dzien, godz_p, min_p);

                int godz_k = Convert.ToInt32(sr.ReadLine()); //godzina - koniec zdażenia
                int min_k = Convert.ToInt32(sr.ReadLine()); //minuty - koniec zdażenia
                Data data_kon = new Data(rok, miesiac, dzien, godz_k, min_k);
                tmp_list.Add(new Wpis(data_pocz, data_kon, tytuł));
            }

            kalendarz.Add(tmp_dzien, tmp_list);
        }
         */
    }
    public void Zapisz(Stream plik)
    {
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(plik, this);

        /*
         StreamWriter sw = new StreamWriter(plik);

        var nast = kalendarz.Keys.GetEnumerator();
        while (nast.MoveNext())
        {
            Data_dzien tmp = nast.Current;
            //zapisywanie daty
            sw.WriteLine(tmp.Rok);
            sw.WriteLine(tmp.Miesiac);
            sw.WriteLine(tmp.Dzien);
            //----------------------------

            List<Wpis> tmp_list = kalendarz[nast.Current];
            int ilość_wpisów = tmp_list.Count;
            //zapisywanie listy wpisów do pliku
            for (int i = 0; i < ilość_wpisów; i++)
            {
                sw.WriteLine(tmp_list[i].Tytul);
                sw.WriteLine(tmp_list[i].Poczatek.Godzina());
                sw.WriteLine(tmp_list[i].Poczatek.Minuta());
                sw.WriteLine(tmp_list[i].Koniec.Godzina());
                sw.WriteLine(tmp_list[i].Koniec.Minuta());
            }

            sw.WriteLine("-=NASTĘPNY WPIS=-"); //separator
        }
         */
    }
    public Data_dzien Dodaj(Wpis wpis)
    {
        Data_dzien poczatek = new Data_dzien(wpis.Poczatek()); //@!! C# lubi referencje, więc bez użycia new poczatek był typu Data!
        if (kalendarz.ContainsKey(poczatek)) //jeżeli wpis danego dnia już istnieje
        {
            List<Wpis> wpisy_dnia = kalendarz[poczatek];

            foreach (var tmp_wpis in wpisy_dnia) //sprawdź czy taki wpis już istnieje
            {
                if (tmp_wpis.Poczatek() == wpis.Poczatek() && tmp_wpis.Koniec() == wpis.Koniec()) //jeżeli istnieje to
                {
                    tmp_wpis.Tytul(wpis.Tytul()); //zmień nazwę
                    return poczatek;
                }
            }


            //***********SORTOWANIE WPISÓW***********
            Wpis tmp_wpis2 = wpisy_dnia[0];
            int i = 0;
            /*while(wpis > tmp_wpis2) //@CO TO JEST?!
            {
                i++;
            }*/
            for(;i<wpisy_dnia.Count;i++)
                if(wpis<wpisy_dnia[i])
                    break;

            kalendarz[poczatek].Insert(i, wpis);
            //***********KONIEC SORTOWANIA***********
        }
        else
        {
            kalendarz.Add(poczatek, new List<Wpis>() {wpis}); //jeżeli danego dnia nie ma jeszcze wpisów to stwórz nową liste wpisów i dodaj wpis
        }
        return poczatek;
    }
    public List<Wpis> WpisyDnia(Data_dzien dzien)
    {
        if (kalendarz.ContainsKey(dzien))
        {
            return kalendarz[dzien];
        }

        return null;
    }
    public Wpis SzukajWpis(string tytul)
    {
        foreach (var listy in kalendarz.Values)
        {
            foreach (var wpis in listy)
            {
                if (wpis.Tytul() == tytul)
                {
                    return wpis;
                }
            }
        }

        return null; //jeżeli pętla nie zakończyła się wcześniej to znaczy, że takiego wpisu nie ma w kalendarzu
    }
}
