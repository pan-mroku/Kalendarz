using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

public class Aplikacja
{
    private Kalendarz kalendarz;
    private Data_dzien data;

    private OpenFileDialog otwórz_plik;
    private SaveFileDialog zapisz_plik;

    //konstruktor wczytujący kalendarz z pliku
    public Aplikacja()
    {
        kalendarz = new Kalendarz();
        data = new Data_dzien(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
        while (data.DzienTygodnia() != DniTygodnia.poniedziałek) { data--; }
        
        //inicjalizacja OpenFileDialog
        otwórz_plik = new OpenFileDialog();
        otwórz_plik.InitialDirectory = "c:\\";
        otwórz_plik.FileName = "";
        otwórz_plik.Filter = "pliki Kalendarza (*.kalen)|*.kalen|All files (*.*)|*.*";
        otwórz_plik.FilterIndex = 2;
        otwórz_plik.RestoreDirectory = true;
        //**************KONIEC INICJALIZACJI OpenFileDialog**************


        //inicjalizacja SaveFileDialog
        SaveFileDialog zapisz_plik = new SaveFileDialog();
        zapisz_plik.AddExtension = true;
        zapisz_plik.FileName = "";
        zapisz_plik.InitialDirectory = "c:\\";
        zapisz_plik.Filter = "pliki Kalendarza (*.kalen)|*.kalen|All files (*.*)|*.*";
        zapisz_plik.FilterIndex = 1;
        zapisz_plik.RestoreDirectory = true;
        //**************KONIEC INICJALIZACJI SaveFileDialog**************

        if (otwórz_plik.ShowDialog() == DialogResult.OK)
        {
            Stream plik = otwórz_plik.OpenFile();
            kalendarz.Wczytaj(plik);
            plik.Flush();
            plik.Close();
        }
    }
    public void Dodaj(Wpis nowy)
    {
        kalendarz.Dodaj(nowy);
    }
    //metoda wywoływana przy zamykaniu programu. Musi zapytać o zapisanie zmian i ewentualnie je zapisać do wskazanego katalogu
    public void Zamknij()
    {
        var pytanie = MessageBox.Show("Czy chcesz zapisać zmiany przed zamknięciem?", "Zapis zmian?", MessageBoxButtons.YesNo);
        if (pytanie == DialogResult.Yes)
        {
            if (zapisz_plik.ShowDialog() == DialogResult.OK)
            {
                Stream plik = zapisz_plik.OpenFile();
                kalendarz.Zapisz(plik);
                plik.Flush();
                plik.Close();
            }
            MessageBox.Show("Zmiany zostały zapisane.", "Zapis zmian");
            Application.Exit();
        }
        else
        {
            Application.Exit();
        }
    }
    public Data_dzien Data()
    {
        return data;
    }
    public void Wstecz()
    {
        data -= 7;
        while (data.Dzien != 1) data--;
        while (data.DzienTygodnia() != DniTygodnia.poniedziałek) data--;
    }
    public void Naprzod()
    {
        data += 7;
        while (data.Dzien != 1) data++;
        while (data.DzienTygodnia() != DniTygodnia.poniedziałek) data--;
    }


    //metoda zwracająca miesiąc (tyle ile będzie przycisków w gui) bitmap, które potem będą skalowane na przyciskach. Niech nie-zajęte godziny nie zajmują zbyt dużo miejsca. Godziny zajęte powinny zajmować przestrzeń proporcjonalną do czasu ich trwania. Wystarczą same kolory, bez tytułów.
    public List<Bitmap> Miesiac(Data_dzien pierwszy)
    {
        List<Bitmap> lista_bitmap = new List<Bitmap> { };


        for (int i = 0; i < 35; i++)
        {
            List<Wpis> lista_tmp = kalendarz.WpisyDnia(pierwszy + i);
            if (lista_tmp != null)
            {
                Bitmap bitmapa = new Bitmap(1, 1440);
                foreach (var wpis in lista_tmp)
                {
                    Data pocz = wpis.Poczatek;
                    int pocz_w_minutach = pocz.Godzina() * 60 + pocz.Minuta();

                    Data kon = wpis.Koniec;
                    int kon_w_minutach = kon.Godzina() * 60 + kon.Minuta();

                    int r = new Random().Next(0, 255);
                    int g = new Random().Next(0, 255);
                    int b = new Random().Next(0, 255);
                    Color wypełnienie = Color.FromArgb(r, g, b);

                    for (int y = pocz_w_minutach; y < kon_w_minutach + 1; y++)
                    {
                        bitmapa.SetPixel(0, y, wypełnienie);
                    }
                }

                lista_bitmap.Add(bitmapa);
            }
        }
        return lista_bitmap;
    }
    //metoda zwracająca bitmapę(być może w praniu zmienimy to na coś innego)  wybranego dnia. Podobnie jak powyżej, ale z napisanymi godzinami i tytułami wpisów
    public Bitmap Dzien(Data_dzien data)
    {
        throw new System.Exception("Not implemented");
    }
    //zapis okresu do pliku. Musi zapytać gdzie zapisać
    public void Eksport(Data_dzien poczatek, Data_dzien koniec)
    {
        if (zapisz_plik.ShowDialog() == DialogResult.OK)
        {
            Stream plik = zapisz_plik.OpenFile();
            kalendarz.Zapisz(plik);
            plik.Flush();
            plik.Close();
        }
    }
}
