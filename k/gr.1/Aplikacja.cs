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

	//private FileDialog plik;

	//konstruktor wczytujący kalendarz z pliku
	public Aplikacja()
	{
		kalendarz = new Kalendarz();
		data = new Data_dzien();
		while (data.DzienTygodnia() != DniTygodnia.poniedziałek) { data--; }
		dokonanoZmian=false;
		
		//inicjalizacja OpenFileDialog
		/*otwórz_plik = new OpenFileDialog();
		otwórz_plik.InitialDirectory = "c:\\";
		otwórz_plik.FileName = "";
		otwórz_plik.Filter = "pliki Kalendarza (*.kalen)|*.kalen|All files (*.*)|*.*";
		otwórz_plik.FilterIndex = 2;
		otwórz_plik.RestoreDirectory = true;*/
		//**************KONIEC INICJALIZACJI OpenFileDialog**************


		//inicjalizacja SaveFileDialog
		/*zapisz_plik = new SaveFileDialog();
		zapisz_plik.AddExtension = true;
		zapisz_plik.FileName = "";
		zapisz_plik.InitialDirectory = "c:\\";
		zapisz_plik.Filter = "pliki Kalendarza (*.kalen)|*.kalen|All files (*.*)|*.*";
		zapisz_plik.FilterIndex = 1;
		zapisz_plik.RestoreDirectory = true;*/
		//**************KONIEC INICJALIZACJI SaveFileDialog**************

		/*if (otwórz_plik.ShowDialog() == DialogResult.OK)
		{
			Stream plik = otwórz_plik.OpenFile();
			kalendarz.Wczytaj(plik);
			plik.Flush();
			plik.Close();
		}*/
	}
	
	public void Dodaj(Wpis nowy)
	{
		kalendarz.Dodaj(nowy);
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
		//kalendarz = new Kalendarz();

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
		/* var pytanie = MessageBox.Show("Czy chcesz zapisać zmiany?", "Zapis zmian?", MessageBoxButtons.YesNo);
        if (pytanie == DialogResult.Yes)
        {*/
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
		//}
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
		List<Bitmap> lista_bitmap = new List<Bitmap>(35);
		
		
		
		for (int dzien = 0; dzien < 35; dzien++)
		{
			List<Wpis> lista_wpisow = kalendarz.WpisyDnia(pierwszy + dzien);
			
			List<List<int> > lista_kolorow=new List<List<int>>(wysokosc);
			for(int y=0;y<wysokosc;y++)
				lista_kolorow.Add(new List<int>());
			
			//Tworzymy czystą bitmapę
			Bitmap bitmapa=new Bitmap(szerokosc,wysokosc);
			for(int x=0;x<szerokosc;x++)
				for(int y=0;y<wysokosc;y++)
					bitmapa.SetPixel(x,y,Color.White);
			
			if (lista_wpisow !=null)  //zapełnianie listy_kolorow
			{
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
			}
			
			for(int y=0;y<lista_kolorow.Count;y++)
			{
				if(lista_kolorow[y]!=null)
				{
					for (int index_wpisu=0;index_wpisu<lista_kolorow[y].Count;index_wpisu++)
					{
						for(int x=index_wpisu*szerokosc/lista_kolorow[y].Count;x<(index_wpisu+1)*szerokosc/lista_kolorow[y].Count;x++)
						{
							var kolor=Color.White.ToKnownColor()+y;
							bitmapa.SetPixel(x,y,Color.FromKnownColor(kolor));
							
						}
					}
				}
			}
			
//					int r = new Random().Next(0, 255);
//					int g = new Random().Next(0, 255);
//					int b = new Random().Next(0, 255);
//					Color wypełnienie = Color.FromArgb(r, g, b);
//
//					for(int x=0;x<szerokosc;x++)
//						for (int y = Convert.ToInt32(pocz_w_minutach); y < Convert.ToInt32(kon_w_minutach) + 1; y++)
//							bitmapa.SetPixel(x, y, wypełnienie);
			
			lista_bitmap.Add(bitmapa);
		}
		return lista_bitmap;
	}
	//metoda zwracająca bitmapę(być może w praniu zmienimy to na coś innego) wybranego dnia. Podobnie jak powyżej, ale z napisanymi godzinami i tytułami wpisów
	public Bitmap Dzien(Data_dzien data, int szerokosc, int wysokosc)
	{
		List<Wpis> listaWpisow = kalendarz.WpisyDnia(data);
		Bitmap dzien=new Bitmap(10,1440);
		for (int i = 0; i < listaWpisow.Count; i++) //@FIX:a co jeśli nie ma wpisów? Powinno rysować wtedy biały obrazek
		{
			Wpis wpis = listaWpisow[i];
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