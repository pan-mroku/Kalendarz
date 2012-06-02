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
        private Data_dzien wyswietlanyDzien;
        
        public Form1()
        {
            aplikacja=new Aplikacja();
            poczatek=new Data();
            koniec=new Data();
            wyswietlanyDzien=new Data_dzien();
            InitializeComponent();
            GenerujMiesiac();
            button_mieciac_tyl.BackgroundImage=gr._1.Properties.Resources.strzałka_lewo;
            button_miesiac_nap.BackgroundImage=gr._1.Properties.Resources.strzałka_prawo;
            
            WyswietlWpisy();
            
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
            
            OdswiezDni();
            OdswiezPoczatek();
            OdswiezKoniec();

        }
        private void GenerujObraz()
        {
            Data_dzien d=aplikacja.Data()+7;
            var licznik = d.Miesiac();
            switch (licznik)
            {
                case 1:
                    panel_miesiac_image.BackgroundImage = gr._1.Properties.Resources.styczen;
                    break;
                case 2:
                    panel_miesiac_image.BackgroundImage = gr._1.Properties.Resources.luty;
                    break;
                case 3:
                    panel_miesiac_image.BackgroundImage = gr._1.Properties.Resources.marzec;
                    break;
                case 4:
                    panel_miesiac_image.BackgroundImage = gr._1.Properties.Resources.kwiecien;
                    break;
                case 5:
                    panel_miesiac_image.BackgroundImage = gr._1.Properties.Resources.mai;
                    break;
                case 6:
                    panel_miesiac_image.BackgroundImage = gr._1.Properties.Resources.czerwiec;
                    break;
                case 7:
                    panel_miesiac_image.BackgroundImage = gr._1.Properties.Resources.lipiec;
                    break;
                case 8:
                    panel_miesiac_image.BackgroundImage = gr._1.Properties.Resources.sierpien;
                    break;
                case 9:
                    panel_miesiac_image.BackgroundImage = gr._1.Properties.Resources.wrzesien;
                    break;
                case 10:
                    panel_miesiac_image.BackgroundImage = gr._1.Properties.Resources.pazdziernik;
                    break;
                case 11:
                    panel_miesiac_image.BackgroundImage = gr._1.Properties.Resources.listopad;
                    break;
                case 12:
                    panel_miesiac_image.BackgroundImage = gr._1.Properties.Resources.grudzien;
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
                przycisk.Name=(i*7+j).ToString();
                przycisk.Location=new System.Drawing.Point(j*w,i*h);
                przycisk.Size=new System.Drawing.Size(w,h);
                przycisk.Click += new EventHandler(przycisk_Click);
                panel2.Controls.Add(przycisk);
                
            }

            for (int i = 1; i < 13; i++)
            {
                ustawienia_miesiaca_koniec.Items.Add(i);
                ustawienie_miesiaca_poczatek.Items.Add(i);
            }
            
            
            Odswiez();
        }
        public void przycisk_Click(object sender, EventArgs e)
        {
            Button przycisk=(Button)sender;
            int numer=Convert.ToInt32(przycisk.Name);
            wyswietlanyDzien=aplikacja.Data()+numer;
            poczatek=new Data(wyswietlanyDzien.Rok(), wyswietlanyDzien.Miesiac(), wyswietlanyDzien.Dzien(),7,0);
            koniec=new Data(poczatek);
            OdswiezPoczatek();
            OdswiezKoniec();
            WyswietlWpisy();
        }
        private void OdswiezDni()
        {
            ustawienia_dnia_poczatek.Items.Clear();
            ustawienia_dnia_koniec.Items.Clear();
            
            for (int i = 1; i <= Data_dzien.LiczbaDniWMiesiac( poczatek.Rok(),poczatek.Miesiac()); i++)
                ustawienia_dnia_poczatek.Items.Add(i);

            for (int i = 1; i <= Data_dzien.LiczbaDniWMiesiac(koniec.Rok(),koniec.Miesiac()); i++)
                ustawienia_dnia_koniec.Items.Add(i);
        }
        
        private void OdswiezPoczatek()
        {
            ustawienia_rok_poczatek.Text=poczatek.Rok().ToString();
            ustawienie_miesiaca_poczatek.Text=poczatek.Miesiac().ToString();
            ustawienia_dnia_poczatek.Text=poczatek.Dzien().ToString();
            ustawienie_godziny_poczatek.Text=poczatek.Godzina().ToString();
            ustawienie_minuty_poczatek.Text=poczatek.Minuta().ToString();
            ustawienie_tytul_wydarzenia.Text="";
        }
        
        private void OdswiezKoniec()
        {
            ustawienia_roku_koniec.Text=koniec.Rok().ToString();
            ustawienia_miesiaca_koniec.Text=koniec.Miesiac().ToString();
            ustawienia_dnia_koniec.Text=koniec.Dzien().ToString();
            ustawienie_godziny_koniec.Text=koniec.Godzina().ToString();
            ustawienie_minuty_koniec.Text=koniec.Minuta().ToString();
            
        }
        
        private void Odswiez()
        {
            Data_dzien d=aplikacja.Data();
            numer_roku.Text = (d+7).Rok().ToString();
            
            for(int i=0;i<35;i++,d++)
            {
                var przycisk=this.panel2.Controls[i];
                przycisk.Text=d.Dzien().ToString()+"\n"+d.Miesiac().ToString();
                var obrazek=aplikacja.Dzien(aplikacja.Data()+i,przycisk.Width,przycisk.Height);
                ((System.Windows.Forms.Button)przycisk).Image=obrazek;;
            }
            
            GenerujObraz();
            WyswietlWpisy();
        }

        public void Wstecz()
        {
            aplikacja.Wstecz();
            Odswiez();
        }
        
        public void Naprzod()
        {
            aplikacja.Naprzod();
            Odswiez();
        }

        public void WyswietlWpisy()
        {
            picturebox_wpisy_dnia.Image=aplikacja.Dzien(wyswietlanyDzien,picturebox_wpisy_dnia.Width,picturebox_wpisy_dnia.Height);
        }

        private void zapisz_button_Click_1(object sender, EventArgs e)
        {
            aplikacja.Zapisz();
        }

        private void wczytywanie_button_Click_1(object sender, EventArgs e)
        {
            aplikacja.Wczytaj();
            Odswiez();
            WyswietlWpisy();
        }

        
        
        void Panel2SizeChanged(object sender, EventArgs e)
        {
            int w=panel2.Width/7;
            int h=panel2.Height/5;
            
            for(int x=0;x<7;x++)
                for(int y=0;y<5;y++)
            {
                var przycisk=panel2.Controls[x+y*7];
                przycisk.Location=new System.Drawing.Point(x*w,y*h);
                przycisk.Size=new System.Drawing.Size(w,h);
            }
            Odswiez();
        }
        
        void Button_mieciac_tylClick(object sender, System.EventArgs e)
        {
            Wstecz();
        }
        
        void Button_miesiac_napClick(object sender, System.EventArgs e)
        {
            Naprzod();
        }

        void Ustawienia_rok_poczatekSelectedIndexChanged(object sender, System.EventArgs e)
        {
            poczatek.Rok(ToIntRok(ustawienia_rok_poczatek.Text));
            if(koniec<poczatek)
                koniec.Rok(poczatek.Rok());
            
            OdswiezKoniec();
            OdswiezDni();
        }
        
        void Ustawienia_roku_koniecSelectedIndexChanged(object sender, System.EventArgs e)
        {
            koniec.Rok(ToIntRok(ustawienia_roku_koniec.Text));
            if(koniec<poczatek)
                koniec.Rok(poczatek.Rok());
            
            OdswiezKoniec();
            OdswiezDni();
        }
        
        void Ustawienie_miesiaca_poczatekSelectedIndexChanged(object sender, System.EventArgs e)
        {
            poczatek.Miesiac(ToIntMiesiac(ustawienie_miesiaca_poczatek.Text));
            if(koniec<poczatek)
                koniec.Miesiac(poczatek.Miesiac());
            
            OdswiezKoniec();
            OdswiezDni();
        }
        
        void Ustawienia_miesiaca_koniecSelectedIndexChanged(object sender, System.EventArgs e)
        {
            koniec.Miesiac(ToIntMiesiac(ustawienia_miesiaca_koniec.Text));
            if(koniec<poczatek)
                koniec.Miesiac(poczatek.Miesiac());
            
            OdswiezKoniec();
            OdswiezDni();
        }
        
        void Ustawienia_dnia_poczatekSelectedIndexChanged(object sender, System.EventArgs e)
        {
            poczatek.Dzien(Convert.ToInt32(ustawienia_dnia_poczatek.Text));
            if(koniec<poczatek)
                koniec.Dzien(poczatek.Dzien());
            
            OdswiezKoniec();
        }
        
        void Ustawienia_dnia_koniecSelectedIndexChanged(object sender, System.EventArgs e)
        {
            koniec.Dzien(Convert.ToInt32(ustawienia_dnia_koniec.Text));
            if(koniec<poczatek)
                koniec.Dzien(poczatek.Dzien());
            
            OdswiezKoniec();
        }
        
        void Ustawienie_godziny_poczatekSelectedIndexChanged(object sender, System.EventArgs e)
        {
            poczatek.Godzina(Convert.ToInt32(ustawienie_godziny_poczatek.Text));
            if(koniec<poczatek)
                koniec.Godzina(poczatek.Godzina());
            
            OdswiezKoniec();
        }
        
        void Ustawienie_godziny_koniecSelectedIndexChanged(object sender, System.EventArgs e)
        {
            koniec.Godzina(Convert.ToInt32(ustawienie_godziny_koniec.Text));
            if(koniec<poczatek)
                koniec.Godzina(poczatek.Godzina());
            
            OdswiezKoniec();
        }

        void Ustawienie_minuty_poczatekSelectedIndexChanged(object sender, System.EventArgs e)
        {
            poczatek.Minuta(Convert.ToInt32(ustawienie_minuty_poczatek.Text));
            if(koniec<poczatek)
                koniec.Minuta(poczatek.Minuta());
            
            OdswiezKoniec();
        }
        
        void Ustawienie_minuty_koniecSelectedIndexChanged(object sender, System.EventArgs e)
        {
            koniec.Minuta(Convert.ToInt32(ustawienie_minuty_koniec.Text));
            if(koniec<poczatek)
                koniec.Minuta(poczatek.Minuta());
            
            OdswiezKoniec();
        }
        

        
        void Ustaw_wpisClick(object sender, EventArgs e)
        {
            Data_dzien poczatek_dzien = (Data_dzien)poczatek;
            Data_dzien koniec_dzien = (Data_dzien)koniec;

            if (poczatek_dzien + 1 <= koniec_dzien)
            {
                Data i = new Data(poczatek);
                Data j = new Data(poczatek);
                j.Godzina(23);
                j.Minuta(59);
                aplikacja.Dodaj(new Wpis(i, j, ustawienie_tytul_wydarzenia.Text));
                j++;
                i++;
                i.Godzina(0);
                i.Minuta(0);
                while (j < koniec)
                {
                    Wpis nowy = new Wpis(i, j, ustawienie_tytul_wydarzenia.Text);
                    aplikacja.Dodaj(nowy);
                    i++; j++;
                }
                aplikacja.Dodaj(new Wpis(i, koniec, ustawienie_tytul_wydarzenia.Text));
            }
            else
            {
                aplikacja.Dodaj(new Wpis(poczatek, koniec, ustawienie_tytul_wydarzenia.Text));
            }
            poczatek = new Data();
            koniec = new Data();
            OdswiezDni();
            OdswiezPoczatek();
            OdswiezKoniec();
            Odswiez();
        }
        
        void Form1FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            aplikacja.Zamknij();
        }
        private System.Windows.Forms.PictureBox panel_miesiac_image;
        
        void Usun_wpisClick(object sender, EventArgs e)
        {
            int rok=ToIntRok(ustawienia_rok_poczatek.Text);
            int miesiac=ToIntMiesiac(ustawienie_miesiaca_poczatek.Text);
            int dzien=Convert.ToInt32(ustawienia_dnia_poczatek.Text);
            Data_dzien data=new Data_dzien(rok,miesiac,dzien);
            aplikacja.Usun(data, ustawienie_tytul_wydarzenia.Text);
            poczatek=new Data();
            OdswiezDni();
            OdswiezPoczatek();
            OdswiezKoniec();
            Odswiez();
        }
    }
}
