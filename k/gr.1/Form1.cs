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
    	
        public Form1()
        {
        	aplikacja=new Aplikacja();
            InitializeComponent();
            button_mieciac_tyl.BackgroundImage=gr._1.Properties.Resources.strzałka_lewo;
            button_miesiac_nap.BackgroundImage=gr._1.Properties.Resources.strzałka_prawo;
            GenerujMiesiac();
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
        	Odswierz();
        }
        
        
        private void Odswierz()
        {
        	//@TODO: zmiana obrazka/napisu w miesiac_obrazek (kto ma te obrazki zrobić?)
        	Data_dzien d=aplikacja.Data();
        	for(int i=0;i<35;i++,d++)
        	{
        		this.panel2.Controls[i].Text=d.Dzien.ToString()+"\n"+d.Miesiac.ToString();
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
        
        private void Form1_Load(object sender, EventArgs e)
        {
        	//for(int i=0;i<35;i++)
        		

        }

        
    }
}
