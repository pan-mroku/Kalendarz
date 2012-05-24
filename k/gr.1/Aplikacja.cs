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
		data = new Data_dzien();
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
		zapisz_plik = new SaveFileDialog();
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
		}
	}
    public void Wczytaj()
    {
        kalendarz = new Kalendarz();

        otwórz_plik = new OpenFileDialog();
        otwórz_plik.InitialDirectory = "c:\\";
        otwórz_plik.FileName = "";
        otwórz_plik.Filter = "pliki Kalendarza (*.kalen)|*.kalen|All files (*.*)|*.*";
        otwórz_plik.FilterIndex = 2;
        otwórz_plik.RestoreDirectory = true;

        if (otwórz_plik.ShowDialog() == DialogResult.OK)
        {
            Stream plik = otwórz_plik.OpenFile();
            kalendarz.Wczytaj(plik);
            plik.Flush();
            plik.Close();
        }


    }
    public void Zapisz()
    {
        var pytanie = MessageBox.Show("Czy chcesz zapisać zmiany?", "Zapis zmian?", MessageBoxButtons.YesNo);
        if (pytanie == DialogResult.Yes)
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
	public Data_dzien Data()
	{
		return data;
	}
	public void Wstecz()
	{
		data -= 7;
		while (data.Dzien() != 1) data--;
		while (data.DzienTygodnia() != DniTygodnia.poniedziałek) data--;
	}
	public void Naprzod()
	{
		data += 7;
		while (data.Dzien() != 1) data++;
		while (data.DzienTygodnia() != DniTygodnia.poniedziałek) data--;
	}


	//metoda zwracająca miesiąc (tyle ile będzie przycisków w gui) bitmap, które potem będą skalowane na przyciskach. Niech nie-zajęte godziny nie zajmują zbyt dużo miejsca. Godziny zajęte powinny zajmować przestrzeń proporcjonalną do czasu ich trwania. Wystarczą same kolory, bez tytułów.
	public List<Bitmap> Miesiac(Data_dzien pierwszy, int szerokosc, int wysokosc)
	{
		//@TODO:przerobić, żeby od razu generowało obrazki o podanej szerokości i wysokości
		List<Bitmap> lista_bitmap = new List<Bitmap> { };


		for (int i = 0; i < 35; i++)
		{
			List<Wpis> lista_tmp = kalendarz.WpisyDnia(pierwszy + i);
			if (lista_tmp != null)
			{
				Bitmap bitmapa = new Bitmap(1, 1440);
				foreach (var wpis in lista_tmp)
				{
					Data pocz = wpis.Poczatek();
					int pocz_w_minutach = pocz.Godzina() * 60 + pocz.Minuta();

					Data kon = wpis.Koniec();
					int kon_w_minutach = kon.Godzina() * 60 + kon.Minuta();

					int r = new Random().Next(0, 255);
					int g = new Random().Next(0, 255);
					int b = new Random().Next(0, 255);
					Color wypełnienie = Color.FromArgb(r, g, b);

						for (int y = pocz_w_minutach; y < kon_w_minutach + 1; y++)
							bitmapa.SetPixel(0, y, wypełnienie);
				}

				lista_bitmap.Add(bitmapa);
			}
			else
			{
				Bitmap bitmapa=new Bitmap(1,1440);
				Color bialy=Color.White;
					for(int j=0;j<1440;j++)
						bitmapa.SetPixel(0,j,bialy);
				lista_bitmap.Add(bitmapa);
			}
		}
		return lista_bitmap;
	}
	//metoda zwracająca bitmapę(być może w praniu zmienimy to na coś innego) wybranego dnia. Podobnie jak powyżej, ale z napisanymi godzinami i tytułami wpisów
	public Bitmap Dzien(Data_dzien data, int szerokosc, int wysokosc)
	{
		List<Wpis> listaWpisw = kalendarz.WpisyDnia(data);
		Bitmap dzien=new Bitmap(10,1440);
		for (int i = 0; i < listaWpisw.Count; i++) //@FIX:a co jeśli nie ma wpisów? Powinno rysować wtedy biały obrazek
		{
			Wpis wpis = listaWpisw[i];
			Data dat_pocz=wpis.Poczatek();
			int poczatek=dat_pocz.Godzina()*60+dat_pocz.Minuta();
			Data dat_kon=wpis.Koniec();
			int koniec=dat_kon.Godzina()*60+dat_kon.Minuta();
			string tytul = wpis.Tytul();
			
			int R = new Random().Next(1, 255);
			int G = new Random().Next(1, 255);
			int B = new Random().Next(1, 255);
			Color kolorDnia = Color.FromArgb(R, G, B);

			string napis = wpis.Tytul() + "/n" + wpis.Poczatek() + "-" + wpis.Koniec();
			Bitmap Tekst = new Bitmap(10,koniec-poczatek);
			Graphics grafikaTekst = Graphics.FromImage(Tekst);
			grafikaTekst.DrawString(napis, new Font("Arial", 10), Brushes.Black, new Point(0, 0));
			Tekst = new Bitmap(10, koniec - poczatek, grafikaTekst);

			for (int j = 0; j < Tekst.Height; j++)
			{
				for (int k = 0; k < Tekst.Width; k++)
				{
					if (Tekst.GetPixel(k, j) != Color.Black)
					{
						Tekst.SetPixel(k, j, kolorDnia);
					}
					for (int l = poczatek; l < koniec; l++)
					{
						for (int m = 0; m < 10; m++)
						{
							dzien.SetPixel(m, l, Tekst.GetPixel(k, j));
						}
					}
				}
			}
		}
		return dzien;
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