using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

public class Aplikacja
{
    private Kalendarz kalendarz;
    private Data_dzien data;

    //konstruktor wczytujący kalendarz z pliku
    public Aplikacja()
    {
        kalendarz = new Kalendarz();
        data=new Data_dzien(DateTime.Today.Year,DateTime.Today.Month,DateTime.Today.Day);
        while(data.DzienTygodnia()!=DniTygodnia.poniedziałek)data--;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        openFileDialog1.InitialDirectory = "c:\\";
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        openFileDialog1.FilterIndex = 2;
        openFileDialog1.RestoreDirectory = true;

        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            StreamReader sciezka = new StreamReader(openFileDialog1.FileName);
            kalendarz.Wczytaj(Convert.ToString(sciezka));
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
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sciezka = new StreamReader(openFileDialog1.FileName);
                kalendarz.Zapisz(Convert.ToString(sciezka));
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
    	data-=7;
       	while(data.Dzien!=1)data--;
       	while(data.DzienTygodnia()!=DniTygodnia.poniedziałek)data--;
    }
    public void Naprzod()
    {
    	data+=7;
    	while(data.Dzien!=1)data++;
    	while(data.DzienTygodnia()!=DniTygodnia.poniedziałek)data--;
    }
    
    
    //metoda zwracająca miesiąc (tyle ile będzie przycisków w gui) bitmap, które potem będą skalowane na przyciskach. Niech nie-zajęte godziny nie zajmują zbyt dużo miejsca. Godziny zajęte powinny zajmować przestrzeń proporcjonalną do czasu ich trwania. Wystarczą same kolory, bez tytułów.
    public List<Bitmap> Miesiac()
    {
        throw new System.Exception("Not implemented");
    }
    //metoda zwracająca bitmapę(być może w praniu zmienimy to na coś innego)  wybranego dnia. Podobnie jak powyżej, ale z napisanymi godzinami i tytułami wpisów
    public Bitmap Dzien(Data_dzien data)
    {
        throw new System.Exception("Not implemented");
    }
    //zapis okresu do pliku. Musi zapytać gdzie zapisać
    public void Eksport(Data_dzien poczatek, Data_dzien koniec)
    {
        throw new System.Exception("Not implemented");
    }


}
