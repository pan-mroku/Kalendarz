using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.IO;

public class Aplikacja
{
    private Kalendarz kalendarz;
    private Data_dzien data;
    private bool dokonanoZmian;

    //konstruktor wczytujący kalendarz z pliku
    public Aplikacja()
    {
        kalendarz = new Kalendarz();
        data = new Data_dzien();
        while (data.DzienTygodnia() != DniTygodnia.poniedziałek) { data--; }
        dokonanoZmian=false;
    }
    
    public void Dodaj(Wpis nowy)
    {
        kalendarz.Dodaj(nowy);
        dokonanoZmian=true;
    }
    
    public void Usun(Data_dzien data, string tytul)
    {
        kalendarz.Usun(data,tytul);
        dokonanoZmian=true;
    }

    //metoda wywoływana przy zamykaniu programu. Musi zapytać o zapisanie zmian i ewentualnie je zapisać do wskazanego katalogu
    public void Zamknij()
    {
        if(dokonanoZmian)
        {
            var pytanie = MessageBox.Show("Czy chcesz zapisać zmiany przed zamknięciem?", "Zapis zmian?", MessageBoxButtons.YesNo);
            if (pytanie == DialogResult.Yes)
                Zapisz();
        }
    }
    public void Wczytaj()
    {
        OpenFileDialog plik = new OpenFileDialog();
        plik.InitialDirectory = ".";
        plik.FileName = "";
        plik.Filter = "pliki Kalendarza (*.kalen)|*.kalen|All files (*.*)|*.*";
        plik.FilterIndex = 1;
        plik.RestoreDirectory = true;

        if (plik.ShowDialog() == DialogResult.OK)
        {
            Stream plik_stream=plik.OpenFile();
            kalendarz.Wczytaj(plik_stream);
            plik_stream.Flush();
            plik_stream.Close();
        }
    }
    public void Zapisz()
    {
        SaveFileDialog plik=new SaveFileDialog();
        plik.InitialDirectory = ".";
        plik.FileName = "";
        plik.Filter = "pliki Kalendarza (*.kalen)|*.kalen|All files (*.*)|*.*";
        plik.FilterIndex = 1;
        plik.RestoreDirectory = true;
        
        if (plik.ShowDialog() == DialogResult.OK)
        {
            Stream plik_stream=plik.OpenFile();
            kalendarz.Zapisz(plik_stream);
            plik_stream.Flush();
            plik_stream.Close();
        }
    }
    
    public Data_dzien Data()
    {
        return data;
    }

    //przejście do poprzedniego miesiąca
    public void Wstecz()
    {
        data -= 7;
        while (data.Dzien() != 1) data--;
        while (data.DzienTygodnia() != DniTygodnia.poniedziałek) data--;
    }

    //przejście do następnego miesiąca
    public void Naprzod()
    {
        data += 7;
        while (data.Dzien() != 1) data++;
        while (data.DzienTygodnia() != DniTygodnia.poniedziałek) data--;
    }

    //Funkcja zwracająca sensowne kolory
    private Color kolorek(int index)
    {
        Color wynik=new Color();
        index%=10;
        //@FIXME Ktoś z gustem powinien lepiej podobierać te kolory. Ja się nie czuję w tym zbyt mocny
        switch(index)
        {
                case 0: wynik=Color.Violet;break;
                case 1: wynik=Color.Orange; break;
                case 2: wynik=Color.Magenta; break;
                case 3: wynik=Color.Salmon; break;
                case 4: wynik=Color.DarkRed; break;
                case 5: wynik=Color.DarkBlue; break;
                case 6: wynik=Color.YellowGreen; break;
                case 7: wynik=Color.DarkGreen; break;
                case 8: wynik=Color.Maroon; break;
                case 9: wynik=Color.LightYellow; break;
        }
        return wynik;
        
    }
    
    //metoda zwracająca bitmapę(być może w praniu zmienimy to na coś innego) wybranego dnia.
    public Bitmap Dzien(Data_dzien data, int szerokosc, int wysokosc)
    {
        List<Wpis> lista_wpisow = kalendarz.WpisyDnia(data);
        
        List<List<int> > lista_kolorow=new List<List<int>>(wysokosc);
        for(int y=0;y<wysokosc;y++)
            lista_kolorow.Add(new List<int>());
        
        //Tworzymy czystą bitmapę
        Bitmap bitmapa=new Bitmap(szerokosc,wysokosc);
        for(int x=0;x<szerokosc;x++)
            for(int y=0;y<wysokosc;y++)
                bitmapa.SetPixel(x,y,Color.White);
        
        if (lista_wpisow !=null)  //zapełnianie listy_kolorow
            for(int i=0; i<lista_wpisow.Count;i++)
        {
            var wpis=lista_wpisow[i];
            
            Data pocz =wpis.Poczatek(); //@Tu może być bez new, bo nic nie zmieniamy
            float pocz_w_minutach = pocz.Godzina() * 60 + pocz.Minuta();
            pocz_w_minutach/=1440; //tyle jest minut w dobie. otrzymujemy procent doby
            pocz_w_minutach*=wysokosc;
            
            Data kon = wpis.Koniec();
            float kon_w_minutach = kon.Godzina() * 60 + kon.Minuta();
            kon_w_minutach/=1440;
            kon_w_minutach*=wysokosc;
            
            for(int y=Convert.ToInt32(pocz_w_minutach);y<Convert.ToInt32(kon_w_minutach);y++)
                lista_kolorow[y].Add(i);
        }
        
        for(int y=0;y<lista_kolorow.Count;y++) //idziemy w dół obrazka
        {
            for (int index_wpisu=0;index_wpisu<lista_kolorow[y].Count;index_wpisu++) //Jeśli nie ma wpisów na tej wysokości, to nic nie robimy
            {
                for(int x=index_wpisu*szerokosc/lista_kolorow[y].Count;x<(index_wpisu+1)*szerokosc/lista_kolorow[y].Count;x++) //szerokość wpisu zależy od ilości wpisów w tym samym czasie
                    bitmapa.SetPixel(x,y,kolorek(lista_kolorow[y][index_wpisu]));
            }
        }
        return bitmapa;
    }

    //zapis okresu do pliku. Musi zapytać gdzie zapisać
    public void Eksport(Data_dzien poczatek, Data_dzien koniec)
    {
        SaveFileDialog plik=new SaveFileDialog();
        plik.InitialDirectory = ".";
        plik.FileName = "";
        plik.Filter = "pliki Kalendarza (*.kalen)|*.kalen|All files (*.*)|*.*";
        plik.FilterIndex = 1;
        plik.RestoreDirectory = true;
        
        if (plik.ShowDialog() == DialogResult.OK)
        {
            Stream plik_stream=plik.OpenFile();
            kalendarz.Zapisz(plik_stream);
            plik_stream.Flush();
            plik_stream.Close();
        }
    }
}