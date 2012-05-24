using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace gr._1
{
	public partial class Form1 : Form
	{
		private Aplikacja aplikacja;
		private Data poczatek;
		private Data koniec;
		
		public Form1()
		{
			aplikacja=new Aplikacja();
			poczatek=new Data();
			koniec=new Data();
			InitializeComponent();
			GenerujMiesiac();
			button_mieciac_tyl.BackgroundImage=gr._1.Properties.Resources.strzałka_lewo;
			button_miesiac_nap.BackgroundImage=gr._1.Properties.Resources.strzałka_prawo;
			
			//nadaje pierwsze widoczne wartości

			/*ustawienia_miesiaca_koniec.Text = koniec.Miesiac().ToString();
			ustawienie_miesiaca_poczatek.Text = poczatek.Miesiac().ToString();
			ustawienia_rok_poczatek.Text = poczatek.Rok().ToString();
			ustawienia_roku_koniec.Text = koniec.Rok().ToString();
			ustawienie_godziny_koniec.Text = koniec.Godzina().ToString();
			ustawienie_godziny_poczatek.Text = poczatek.Godzina().ToString();
			ustawienie_minuty_koniec.Text = koniec.Minuta().ToString();
			ustawienie_minuty_poczatek.Text = poczatek.Minuta().ToString();
			ustawienia_dnia_koniec.Text = koniec.Dzien().ToString();
			ustawienia_dnia_poczatek.Text = poczatek.Dzien().ToString();*/
			
			panel_grafika.Controls.Add(numer_roku);
			
			for (var i = aplikacja.Data().Rok()-1; i < aplikacja.Data().Rok()+5; i++)
			{
				ustawienia_rok_poczatek.Items.Add(i);
				ustawienia_roku_koniec.Items.Add(i);
			}
			for (var i = 0; i < 24; i++)
			{
				ustawienie_godziny_koniec.Items.Add(i);
				ustawienie_godziny_poczatek.Items.Add(i);
			}
			for (var i = 0; i < 60; i++)
			{
				ustawienie_minuty_koniec.Items.Add(i);
				ustawienie_minuty_poczatek.Items.Add(i);
				
			}
			GenerujObraz();
			
			OdswierzDni();
			OdswierzPoczatek();
			OdswierzKoniec();

		}
		private void GenerujObraz()
		{
			Data_dzien d=aplikacja.Data();
			var licznik = d.Miesiac();
			switch (licznik)
			{
				case 1:
					panel_miesiac.BackgroundImage = gr._1.Properties.Resources.strzałka_prawo;
					break;
				case 2:
					panel_miesiac.BackgroundImage = gr._1.Properties.Resources.strzałka_prawo;
					break;
				case 3:
					panel_miesiac.BackgroundImage = gr._1.Properties.Resources.strzałka_prawo;
					break;
				case 4:
					panel_miesiac.BackgroundImage = gr._1.Properties.Resources.strzałka_prawo;
					break;
				case 5:
					panel_miesiac.BackgroundImage = gr._1.Properties.Resources.strzałka_prawo;
					break;
				case 6:
					panel_miesiac.BackgroundImage = gr._1.Properties.Resources.strzałka_prawo;
					break;
				case 7:
					panel_miesiac.BackgroundImage = gr._1.Properties.Resources.strzałka_prawo;
					break;
				case 8:
					panel_miesiac.BackgroundImage = gr._1.Properties.Resources.strzałka_prawo;
					break;
				case 9:
					panel_miesiac.BackgroundImage = gr._1.Properties.Resources.strzałka_prawo;
					break;
				case 10:
					panel_miesiac.BackgroundImage = gr._1.Properties.Resources.strzałka_prawo;
					break;
				case 11:
					panel_miesiac.BackgroundImage = gr._1.Properties.Resources.strzałka_prawo;
					break;
				case 12:
					panel_miesiac.BackgroundImage = gr._1.Properties.Resources.strzałka_prawo;
					break;
				default:
					break;
			}
			

		}
		//nie potrafię tego zaimplementować
		//@DONE
		private int ToIntRok(string obj)
		{
			return Convert.ToInt32(obj);
		}
		private int ToIntMiesiac(string obj)
		{
			return Convert.ToInt32(obj);
		}
		private void GenerujMiesiac()
		{
			int h=panel2.Height/5;
			int w=panel2.Width/7;
			
			for(int i=0;i<5;i++)
				for(int j=0;j<7;j++)
			{
				var przycisk=new System.Windows.Forms.Button();
				przycisk.Name="Button_"+i*7+j;
				przycisk.Location=new System.Drawing.Point(j*w,i*h);
				przycisk.Size=new System.Drawing.Size(w,h);
				panel2.Controls.Add(przycisk);
				
			}

			for (int i = 1; i < 13; i++)
			{
				ustawienia_miesiaca_koniec.Items.Add(i);
				ustawienie_miesiaca_poczatek.Items.Add(i);
			}
			
			Odswierz();
		}
		
		private void OdswierzDni()
		{
			ustawienia_dnia_poczatek.Items.Clear();
			ustawienia_dnia_koniec.Items.Clear();
			
			for (int i = 1; i <= Data_dzien.LiczbaDniWMiesiac( poczatek.Rok(),poczatek.Miesiac()); i++)
				ustawienia_dnia_poczatek.Items.Add(i);

			for (int i = 1; i <= Data_dzien.LiczbaDniWMiesiac(koniec.Rok(),koniec.Miesiac()); i++)
				ustawienia_dnia_koniec.Items.Add(i);
		}
		
		private void OdswierzPoczatek()
		{
			ustawienia_rok_poczatek.Text=poczatek.Rok().ToString();
			ustawienie_miesiaca_poczatek.Text=poczatek.Miesiac().ToString();
			ustawienia_dnia_poczatek.Text=poczatek.Dzien().ToString();
			ustawienie_godziny_poczatek.Text=poczatek.Godzina().ToString();
			ustawienie_minuty_poczatek.Text=poczatek.Minuta().ToString();
			ustawienie_tytul_wydarzenia.Text="";
		}
		
		private void OdswierzKoniec()
		{
			ustawienia_roku_koniec.Text=koniec.Rok().ToString();
			ustawienia_miesiaca_koniec.Text=koniec.Miesiac().ToString();
			ustawienia_dnia_koniec.Text=koniec.Dzien().ToString();
			ustawienie_godziny_koniec.Text=koniec.Godzina().ToString();
			ustawienie_minuty_koniec.Text=koniec.Minuta().ToString();
			
		}
		
		private void Odswierz()
		{
			//@TODO: zmiana obrazka/napisu w miesiac_obrazek (kto ma te obrazki zrobić?)
			var przycisk=this.panel2.Controls[0];
			List<Bitmap> lista=aplikacja.Miesiac(aplikacja.Data(),przycisk.Width,przycisk.Height);
			Data_dzien d=aplikacja.Data();
			numer_roku.Text = (d+7).Rok().ToString();
			
			for(int i=0;i<35;i++,d++)
			{
				przycisk=this.panel2.Controls[i];
				przycisk.Text=d.Dzien().ToString()+"\n"+d.Miesiac().ToString();
				((System.Windows.Forms.Button)przycisk).Image=lista[i];
				
			}
		}
		
		public void Wstecz()
		{
			aplikacja.Wstecz();
			Odswierz();
		}
		
		public void Naprzod()
		{
			aplikacja.Naprzod();
			Odswierz();
		}
		

		
	}
}
