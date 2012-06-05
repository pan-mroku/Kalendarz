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
        dokonanoZmian=false;
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
                case 4: wynik=Color.Maroon; break;
                case 5: wynik=Color.YellowGreen; break;
                case 6: wynik=Color.DarkBlue; break;
                case 7: wynik=Color.DarkGreen; break;
                case 8: wynik=Color.DarkRed; break;
                case 9: wynik=Color.LightYellow; break;
        }
        return wynik;
        
    }
    
    //metoda zwracająca bitmapę(być może w praniu zmienimy to na coś innego) wybranego dnia.
    public Bitmap Dzien(Data_dzien data, int szerokosc, int wysokosc)
    {
        List<Wpis> lista_wpisow = kalendarz.WpisyDnia(data);
        
        List<List<int> > lista_kolorow=new List<List<int>>(wysokosc); //Tu będziemy zapisywać jakich kolorów należy używać na danej wysokości obrazu
        for(int y=0;y<wysokosc;y++)
            lista_kolorow.Add(new List<int>());
        
        //Tworzymy czystą bitmapę
        Bitmap bitmapa=new Bitmap(szerokosc,wysokosc);
        for(int x=0;x<szerokosc;x++)
            for(int y=0;y<wysokosc;y++)
                bitmapa.SetPixel(x,y,Color.White);

        //zapełnianie listy_kolorow
        if (lista_wpisow !=null)
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
                lista_kolorow[y].Add(i); //do listy kolorów dodajemy numer wydarzenia w tym dniu
        }
        
        
        //kolorowanie wpisami
        for(int y=0;y<lista_kolorow.Count;y++) //idziemy w dół obrazka
        {
            for (int index_wpisu=0;index_wpisu<lista_kolorow[y].Count;index_wpisu++) //Jeśli nie ma wpisów na tej wysokości, to nic nie robimy
            {
                int szerokosc_koloru=szerokosc/lista_kolorow[y].Count; //szerokość wpisu zależy od ilości wpisów w tym samym czasie
                for(int x=index_wpisu*szerokosc_koloru;x<(index_wpisu+1)*szerokosc_koloru;x++)
                    bitmapa.SetPixel(x,y,kolorek(lista_kolorow[y][index_wpisu])); //wybrany kolor zależy od indeksu wpisu
            }
        }
        
        int rozmiar=wysokosc/50; //liczymy rozmiar czcionki
        //tworzymy napisy z godzinami
        Graphics g=Graphics.FromImage(bitmapa);
        for(int h=1;h<24;h++)
        {
            float y=h*60f*wysokosc/1440f-rozmiar/2;
            Point p=new Point(0,Convert.ToInt32(y));
            g.DrawString(h.ToString(), new Font("Tahoma",rozmiar), Brushes.Black,p);
            p.X=szerokosc-rozmiar*2;
            g.DrawString(h.ToString(), new Font("Tahoma",rozmiar), Brushes.Black,p);
        }
        
        //piszemy tytuły i godziny wpisów
        if(lista_wpisow!=null) //foreach jednak nie działa dla null :(
            foreach(var wpis in lista_wpisow)
        {
            rozmiar=Math.Min(wpis.Dlugosc()*wysokosc/1440/3,wysokosc/50-1); //ustalamy wysokość czcionki. Uwzględniając przypadek krrótkiego wpisu
            int yp=wpis.Poczatek().Godzina()*60+wpis.Poczatek().Minuta(); //y początku wpisu
            yp*=wysokosc;
            yp/=1440;
            
            int xp=wysokosc/50*2; //Jeśli nie będzie wiecej wpisów w tym samym czasie, to niech się wypisze z lewej strony, ale tak, by nie zasłaniać godzin
            
            for(int index=0;index<lista_kolorow[yp].Count;index++) //szukamy indeksu wpisu, który wypełniamy
                if(lista_wpisow[lista_kolorow[yp][index]]==wpis)
            {
                float szerokosc_wpisu=szerokosc/lista_kolorow[yp].Count;
                xp=Convert.ToInt32(index*szerokosc_wpisu);
                if(xp==0)xp=wysokosc/50*2; //tak jak wyżej, żeby nie zamalowało godzin
                break;
            }
            
            Point p_poczatek=new Point(xp,yp); //tworzymy sobie punkt
            
            //analogicznie jak wyżej
            int yk=wpis.Koniec().Godzina()*60+wpis.Koniec().Minuta(); //y końca wpisu
            yk*=wysokosc;
            yk/=1440;
            yk-=2*rozmiar; //koniec trzeba podciągnąć do góry, żeby nie wyjechał poza wpis
            
            int xk=wysokosc/50*2;
            
            for(int index=0;index<lista_kolorow[yk].Count;index++)
                if(lista_wpisow[lista_kolorow[yk][index]]==wpis)
            {
                float szerokosc_wpisu=szerokosc/lista_kolorow[yk].Count;
                xk=Convert.ToInt32(index*szerokosc_wpisu);
                if(xk==0)xk=wysokosc/50*2;
                break;
            }
            
            Point p_koniec=new Point(xk,yk);
            
            //godizna początku
            g.DrawString(wpis.Poczatek().Godzina()+":"+wpis.Poczatek().Minuta(),new Font("Tahoma", rozmiar),Brushes.White, p_poczatek);
            //poniżej tytuł
            p_poczatek.Y+=rozmiar+1;
            g.DrawString(wpis.Tytul(),new Font("Tahoma", rozmiar+1),Brushes.White, p_poczatek);
            //i na końcu zakończenie
            g.DrawString(wpis.Koniec().Godzina()+":"+wpis.Koniec().Minuta(),new Font("Tahoma", rozmiar), Brushes.White, p_koniec);
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