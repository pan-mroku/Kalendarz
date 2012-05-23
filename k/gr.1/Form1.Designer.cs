using System;

namespace gr._1
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel_menu = new System.Windows.Forms.Panel();
			this.zapisz_button = new System.Windows.Forms.Button();
			this.wczytywanie_button = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel_grafika = new System.Windows.Forms.Panel();
			this.numer_roku = new System.Windows.Forms.Label();
			this.panel_miesiac = new System.Windows.Forms.Panel();
			this.button_mieciac_tyl = new System.Windows.Forms.Button();
			this.button_miesiac_nap = new System.Windows.Forms.Button();
			this.wpisy_panel = new System.Windows.Forms.Panel();
			this.ustawienia_dnia_poczatek = new System.Windows.Forms.ComboBox();
			this.ustawienie_miesiaca_poczatek = new System.Windows.Forms.ComboBox();
			this.ustawienia_rok_poczatek = new System.Windows.Forms.ComboBox();
			this.ustawienie_godziny_poczatek = new System.Windows.Forms.ComboBox();
			this.ustawienie_minuty_poczatek = new System.Windows.Forms.ComboBox();
			this.ustawienia_dnia_koniec = new System.Windows.Forms.ComboBox();
			this.ustawienia_miesiaca_koniec = new System.Windows.Forms.ComboBox();
			this.ustawienia_roku_koniec = new System.Windows.Forms.ComboBox();
			this.ustawienie_godziny_koniec = new System.Windows.Forms.ComboBox();
			this.ustawienie_minuty_koniec = new System.Windows.Forms.ComboBox();
			this.wpis_tekst3 = new System.Windows.Forms.Label();
			this.wpis_tekst2 = new System.Windows.Forms.Label();
			this.wpis_tekst1 = new System.Windows.Forms.Label();
			this.czy_trwa_kilka_dni = new System.Windows.Forms.CheckBox();
			this.ustawienie_tytul_wydarzenia = new System.Windows.Forms.TextBox();
			this.zatwierdz_ustaw = new System.Windows.Forms.Button();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel_nagluwek_miesiac = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel_menu.SuspendLayout();
			this.panel_grafika.SuspendLayout();
			this.panel_miesiac.SuspendLayout();
			this.wpisy_panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel_nagluwek_miesiac.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel_menu
			// 
			this.panel_menu.BackColor = System.Drawing.SystemColors.Highlight;
			this.panel_menu.Controls.Add(this.zapisz_button);
			this.panel_menu.Controls.Add(this.wczytywanie_button);
			this.panel_menu.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel_menu.Location = new System.Drawing.Point(0, 0);
			this.panel_menu.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
			this.panel_menu.Name = "panel_menu";
			this.panel_menu.Size = new System.Drawing.Size(923, 32);
			this.panel_menu.TabIndex = 0;
			// 
			// zapisz_button
			// 
			this.zapisz_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.zapisz_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.zapisz_button.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.zapisz_button.Location = new System.Drawing.Point(91, 0);
			this.zapisz_button.Margin = new System.Windows.Forms.Padding(4);
			this.zapisz_button.Name = "zapisz_button";
			this.zapisz_button.Size = new System.Drawing.Size(75, 32);
			this.zapisz_button.TabIndex = 1;
			this.zapisz_button.Text = "Zapisz";
			this.zapisz_button.UseVisualStyleBackColor = false;
			// 
			// wczytywanie_button
			// 
			this.wczytywanie_button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.wczytywanie_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.wczytywanie_button.Font = new System.Drawing.Font("Times New Roman", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.wczytywanie_button.Location = new System.Drawing.Point(4, 0);
			this.wczytywanie_button.Margin = new System.Windows.Forms.Padding(4);
			this.wczytywanie_button.Name = "wczytywanie_button";
			this.wczytywanie_button.Size = new System.Drawing.Size(79, 32);
			this.wczytywanie_button.TabIndex = 0;
			this.wczytywanie_button.Text = "Wczytaj";
			this.wczytywanie_button.UseVisualStyleBackColor = false;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 115);
			this.panel2.Margin = new System.Windows.Forms.Padding(0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(558, 550);
			this.panel2.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 249);
			this.panel3.Margin = new System.Windows.Forms.Padding(4);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(360, 416);
			this.panel3.TabIndex = 2;
			// 
			// panel_grafika
			// 
			this.panel_grafika.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.panel_grafika.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.panel_grafika.Controls.Add(this.numer_roku);
			this.panel_grafika.Location = new System.Drawing.Point(0, 6);
			this.panel_grafika.Margin = new System.Windows.Forms.Padding(4);
			this.panel_grafika.Name = "panel_grafika";
			this.panel_grafika.Size = new System.Drawing.Size(558, 36);
			this.panel_grafika.TabIndex = 2;
			// 
			// numer_roku
			// 
			this.numer_roku.AutoEllipsis = true;
			this.numer_roku.AutoSize = true;
			this.numer_roku.Enabled = false;
			this.numer_roku.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numer_roku.Location = new System.Drawing.Point(240, 0);
			this.numer_roku.Name = "numer_roku";
			this.numer_roku.Size = new System.Drawing.Size(108, 44);
			this.numer_roku.TabIndex = 0;
			this.numer_roku.Text = "2012";
			this.numer_roku.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel_miesiac
			// 
			this.panel_miesiac.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.panel_miesiac.Controls.Add(this.button_mieciac_tyl);
			this.panel_miesiac.Controls.Add(this.button_miesiac_nap);
			this.panel_miesiac.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel_miesiac.Location = new System.Drawing.Point(0, 48);
			this.panel_miesiac.Margin = new System.Windows.Forms.Padding(4);
			this.panel_miesiac.Name = "panel_miesiac";
			this.panel_miesiac.Size = new System.Drawing.Size(558, 62);
			this.panel_miesiac.TabIndex = 2;
			// 
			// button_mieciac_tyl
			// 
			this.button_mieciac_tyl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button_mieciac_tyl.Dock = System.Windows.Forms.DockStyle.Left;
			this.button_mieciac_tyl.Location = new System.Drawing.Point(0, 0);
			this.button_mieciac_tyl.Margin = new System.Windows.Forms.Padding(4);
			this.button_mieciac_tyl.Name = "button_mieciac_tyl";
			this.button_mieciac_tyl.Size = new System.Drawing.Size(72, 62);
			this.button_mieciac_tyl.TabIndex = 4;
			this.button_mieciac_tyl.UseVisualStyleBackColor = true;
			this.button_mieciac_tyl.Click += new System.EventHandler(this.Button_mieciac_tylClick);
			// 
			// button_miesiac_nap
			// 
			this.button_miesiac_nap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button_miesiac_nap.Dock = System.Windows.Forms.DockStyle.Right;
			this.button_miesiac_nap.ForeColor = System.Drawing.Color.Black;
			this.button_miesiac_nap.Location = new System.Drawing.Point(486, 0);
			this.button_miesiac_nap.Margin = new System.Windows.Forms.Padding(4);
			this.button_miesiac_nap.Name = "button_miesiac_nap";
			this.button_miesiac_nap.Size = new System.Drawing.Size(72, 62);
			this.button_miesiac_nap.TabIndex = 3;
			this.button_miesiac_nap.UseVisualStyleBackColor = true;
			this.button_miesiac_nap.Click += new System.EventHandler(this.Button_miesiac_napClick);
			// 
			// wpisy_panel
			// 
			this.wpisy_panel.AutoScroll = true;
			this.wpisy_panel.AutoScrollMargin = new System.Drawing.Size(3, 3);
			this.wpisy_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.wpisy_panel.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.wpisy_panel.Controls.Add(this.ustawienia_dnia_poczatek);
			this.wpisy_panel.Controls.Add(this.ustawienie_miesiaca_poczatek);
			this.wpisy_panel.Controls.Add(this.ustawienia_rok_poczatek);
			this.wpisy_panel.Controls.Add(this.ustawienie_godziny_poczatek);
			this.wpisy_panel.Controls.Add(this.ustawienie_minuty_poczatek);
			this.wpisy_panel.Controls.Add(this.ustawienia_dnia_koniec);
			this.wpisy_panel.Controls.Add(this.ustawienia_miesiaca_koniec);
			this.wpisy_panel.Controls.Add(this.ustawienia_roku_koniec);
			this.wpisy_panel.Controls.Add(this.ustawienie_godziny_koniec);			
			this.wpisy_panel.Controls.Add(this.ustawienie_minuty_koniec);
			this.wpisy_panel.Controls.Add(this.wpis_tekst3);
			this.wpisy_panel.Controls.Add(this.wpis_tekst2);
			this.wpisy_panel.Controls.Add(this.wpis_tekst1);
			this.wpisy_panel.Controls.Add(this.czy_trwa_kilka_dni);
			this.wpisy_panel.Controls.Add(this.ustawienie_tytul_wydarzenia);
			this.wpisy_panel.Controls.Add(this.zatwierdz_ustaw);
			this.wpisy_panel.Dock = System.Windows.Forms.DockStyle.Top;
			this.wpisy_panel.Location = new System.Drawing.Point(0, 0);
			this.wpisy_panel.Margin = new System.Windows.Forms.Padding(4);
			this.wpisy_panel.Name = "wpisy_panel";
			this.wpisy_panel.Size = new System.Drawing.Size(360, 249);
			this.wpisy_panel.TabIndex = 3;
			// 
			// ustawienia_roku_koniec
			// 
			this.ustawienia_roku_koniec.FormattingEnabled = true;
			this.ustawienia_roku_koniec.Location = new System.Drawing.Point(136, 159);
			this.ustawienia_roku_koniec.Margin = new System.Windows.Forms.Padding(4);
			this.ustawienia_roku_koniec.Name = "ustawienia_roku_koniec";
			this.ustawienia_roku_koniec.Size = new System.Drawing.Size(79, 24);
			this.ustawienia_roku_koniec.TabIndex = 20;
			this.ustawienia_roku_koniec.SelectedIndexChanged += new System.EventHandler(this.Ustawienia_roku_koniecSelectedIndexChanged);
			this.ustawienia_roku_koniec.Leave += new System.EventHandler(this.Ustawienia_roku_koniecSelectedIndexChanged);
			// 
			// ustawienia_miesiaca_koniec
			// 
			this.ustawienia_miesiaca_koniec.FormattingEnabled = true;
			this.ustawienia_miesiaca_koniec.Location = new System.Drawing.Point(77, 159);
			this.ustawienia_miesiaca_koniec.Margin = new System.Windows.Forms.Padding(4);
			this.ustawienia_miesiaca_koniec.Name = "ustawienia_miesiaca_koniec";
			this.ustawienia_miesiaca_koniec.Size = new System.Drawing.Size(49, 24);
			this.ustawienia_miesiaca_koniec.TabIndex = 19;
			this.ustawienia_miesiaca_koniec.SelectedIndexChanged += new System.EventHandler(this.Ustawienia_miesiaca_koniecSelectedIndexChanged);
			this.ustawienia_miesiaca_koniec.Leave += new System.EventHandler(this.Ustawienia_miesiaca_koniecSelectedIndexChanged);
			// 
			// ustawienia_dnia_koniec
			// 
			this.ustawienia_dnia_koniec.FormattingEnabled = true;
			this.ustawienia_dnia_koniec.Location = new System.Drawing.Point(16, 159);
			this.ustawienia_dnia_koniec.Margin = new System.Windows.Forms.Padding(4);
			this.ustawienia_dnia_koniec.Name = "ustawienia_dnia_koniec";
			this.ustawienia_dnia_koniec.Size = new System.Drawing.Size(52, 24);
			this.ustawienia_dnia_koniec.TabIndex = 17;
			this.ustawienia_dnia_koniec.SelectedIndexChanged += new System.EventHandler(this.Ustawienia_dnia_koniecSelectedIndexChanged);
			this.ustawienia_dnia_koniec.Leave += new System.EventHandler(this.Ustawienia_dnia_koniecSelectedIndexChanged);
			// 
			// ustawienie_minuty_koniec
			// 
			this.ustawienie_minuty_koniec.FormattingEnabled = true;
			this.ustawienie_minuty_koniec.Location = new System.Drawing.Point(301, 158);
			this.ustawienie_minuty_koniec.Margin = new System.Windows.Forms.Padding(4);
			this.ustawienie_minuty_koniec.Name = "ustawienie_minuty_koniec";
			this.ustawienie_minuty_koniec.Size = new System.Drawing.Size(52, 24);
			this.ustawienie_minuty_koniec.TabIndex = 20;
			this.ustawienie_minuty_koniec.SelectedIndexChanged += new System.EventHandler(this.Ustawienie_minuty_koniecSelectedIndexChanged);
			this.ustawienie_minuty_koniec.Leave += new System.EventHandler(this.Ustawienie_minuty_koniecSelectedIndexChanged);
			// 
			// ustawienie_godziny_koniec
			// 
			this.ustawienie_godziny_koniec.FormattingEnabled = true;
			this.ustawienie_godziny_koniec.Location = new System.Drawing.Point(243, 158);
			this.ustawienie_godziny_koniec.Margin = new System.Windows.Forms.Padding(4);
			this.ustawienie_godziny_koniec.Name = "ustawienie_godziny_koniec";
			this.ustawienie_godziny_koniec.Size = new System.Drawing.Size(56, 24);
			this.ustawienie_godziny_koniec.TabIndex = 19;
			this.ustawienie_godziny_koniec.SelectedIndexChanged += new System.EventHandler(this.Ustawienie_godziny_koniecSelectedIndexChanged);
			this.ustawienie_godziny_koniec.Leave += new System.EventHandler(this.Ustawienie_godziny_koniecSelectedIndexChanged);
			// 
			// ustawienie_minuty_poczatek
			// 
			this.ustawienie_minuty_poczatek.FormattingEnabled = true;
			this.ustawienie_minuty_poczatek.Location = new System.Drawing.Point(301, 36);
			this.ustawienie_minuty_poczatek.Margin = new System.Windows.Forms.Padding(4);
			this.ustawienie_minuty_poczatek.Name = "ustawienie_minuty_poczatek";
			this.ustawienie_minuty_poczatek.Size = new System.Drawing.Size(52, 24);
			this.ustawienie_minuty_poczatek.TabIndex = 18;
			this.ustawienie_minuty_poczatek.SelectedIndexChanged += new System.EventHandler(this.Ustawienie_minuty_poczatekSelectedIndexChanged);
			this.ustawienie_minuty_poczatek.Leave += new System.EventHandler(this.Ustawienie_minuty_poczatekSelectedIndexChanged);
			// 
			// ustawienie_godziny_poczatek
			// 
			this.ustawienie_godziny_poczatek.FormattingEnabled = true;
			this.ustawienie_godziny_poczatek.Location = new System.Drawing.Point(243, 36);
			this.ustawienie_godziny_poczatek.Margin = new System.Windows.Forms.Padding(4);
			this.ustawienie_godziny_poczatek.Name = "ustawienie_godziny_poczatek";
			this.ustawienie_godziny_poczatek.Size = new System.Drawing.Size(56, 24);
			this.ustawienie_godziny_poczatek.TabIndex = 17;
			this.ustawienie_godziny_poczatek.SelectedIndexChanged += new System.EventHandler(this.Ustawienie_godziny_poczatekSelectedIndexChanged);
			this.ustawienie_godziny_poczatek.Leave += new System.EventHandler(this.Ustawienie_godziny_poczatekSelectedIndexChanged);
			// 
			// ustawienia_rok_poczatek
			// 
			this.ustawienia_rok_poczatek.FormattingEnabled = true;
			this.ustawienia_rok_poczatek.Location = new System.Drawing.Point(136, 36);
			this.ustawienia_rok_poczatek.Margin = new System.Windows.Forms.Padding(4);
			this.ustawienia_rok_poczatek.Name = "ustawienia_rok_poczatek";
			this.ustawienia_rok_poczatek.Size = new System.Drawing.Size(79, 24);
			this.ustawienia_rok_poczatek.TabIndex = 16;
			this.ustawienia_rok_poczatek.SelectedIndexChanged += new System.EventHandler(this.Ustawienia_rok_poczatekSelectedIndexChanged);
			this.ustawienia_rok_poczatek.Leave += new System.EventHandler(this.Ustawienia_rok_poczatekSelectedIndexChanged);
			// 
			// ustawienie_miesiaca_poczatek
			// 
			this.ustawienie_miesiaca_poczatek.FormattingEnabled = true;
			this.ustawienie_miesiaca_poczatek.Location = new System.Drawing.Point(77, 36);
			this.ustawienie_miesiaca_poczatek.Margin = new System.Windows.Forms.Padding(4);
			this.ustawienie_miesiaca_poczatek.Name = "ustawienie_miesiaca_poczatek";
			this.ustawienie_miesiaca_poczatek.Size = new System.Drawing.Size(49, 24);
			this.ustawienie_miesiaca_poczatek.TabIndex = 15;
			this.ustawienie_miesiaca_poczatek.SelectedIndexChanged += new System.EventHandler(this.Ustawienie_miesiaca_poczatekSelectedIndexChanged);
			this.ustawienie_miesiaca_poczatek.Leave += new System.EventHandler(this.Ustawienie_miesiaca_poczatekSelectedIndexChanged);
			// 
			// ustawienia_dnia_poczatek
			// 
			this.ustawienia_dnia_poczatek.FormattingEnabled = true;
			this.ustawienia_dnia_poczatek.Location = new System.Drawing.Point(16, 36);
			this.ustawienia_dnia_poczatek.Margin = new System.Windows.Forms.Padding(4);
			this.ustawienia_dnia_poczatek.Name = "ustawienia_dnia_poczatek";
			this.ustawienia_dnia_poczatek.Size = new System.Drawing.Size(52, 24);
			this.ustawienia_dnia_poczatek.TabIndex = 0;
			this.ustawienia_dnia_poczatek.SelectedIndexChanged += new System.EventHandler(this.Ustawienia_dnia_poczatekSelectedIndexChanged);
			this.ustawienia_dnia_poczatek.Leave += new System.EventHandler(this.Ustawienia_dnia_poczatekSelectedIndexChanged);
			// 
			// wpis_tekst3
			// 
			this.wpis_tekst3.AutoSize = true;
			this.wpis_tekst3.Location = new System.Drawing.Point(12, 139);
			this.wpis_tekst3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.wpis_tekst3.Name = "wpis_tekst3";
			this.wpis_tekst3.Size = new System.Drawing.Size(310, 17);
			this.wpis_tekst3.TabIndex = 14;
			this.wpis_tekst3.Text = "Wybierz datę i godzinę zakończenia wydarzenia";
			// 
			// wpis_tekst2
			// 
			this.wpis_tekst2.AutoSize = true;
			this.wpis_tekst2.Location = new System.Drawing.Point(45, 65);
			this.wpis_tekst2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.wpis_tekst2.Name = "wpis_tekst2";
			this.wpis_tekst2.Size = new System.Drawing.Size(39, 17);
			this.wpis_tekst2.TabIndex = 13;
			this.wpis_tekst2.Text = "Tytuł";
			// 
			// wpis_tekst1
			// 
			this.wpis_tekst1.AutoSize = true;
			this.wpis_tekst1.Location = new System.Drawing.Point(45, 6);
			this.wpis_tekst1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.wpis_tekst1.Name = "wpis_tekst1";
			this.wpis_tekst1.Size = new System.Drawing.Size(252, 17);
			this.wpis_tekst1.TabIndex = 12;
			this.wpis_tekst1.Text = "Wybierz datę i godzinę początku wpisu";
			// 
			// czy_trwa_kilka_dni
			// 
			this.czy_trwa_kilka_dni.AutoSize = true;
			this.czy_trwa_kilka_dni.Location = new System.Drawing.Point(77, 114);
			this.czy_trwa_kilka_dni.Margin = new System.Windows.Forms.Padding(4);
			this.czy_trwa_kilka_dni.Name = "czy_trwa_kilka_dni";
			this.czy_trwa_kilka_dni.Size = new System.Drawing.Size(221, 21);
			this.czy_trwa_kilka_dni.TabIndex = 11;
			this.czy_trwa_kilka_dni.Text = "Czy wydarzenie trwa kilka dni?";
			this.czy_trwa_kilka_dni.UseVisualStyleBackColor = true;
			// 
			// ustawienie_tytul_wydarzenia
			// 
			this.ustawienie_tytul_wydarzenia.Location = new System.Drawing.Point(16, 85);
			this.ustawienie_tytul_wydarzenia.Margin = new System.Windows.Forms.Padding(4);
			this.ustawienie_tytul_wydarzenia.Name = "ustawienie_tytul_wydarzenia";
			this.ustawienie_tytul_wydarzenia.Size = new System.Drawing.Size(325, 22);
			this.ustawienie_tytul_wydarzenia.TabIndex = 4;
			// 
			// zatwierdz_ustaw
			// 
			this.zatwierdz_ustaw.BackColor = System.Drawing.SystemColors.HighlightText;
			this.zatwierdz_ustaw.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.zatwierdz_ustaw.Location = new System.Drawing.Point(0, 221);
			this.zatwierdz_ustaw.Margin = new System.Windows.Forms.Padding(4);
			this.zatwierdz_ustaw.Name = "zatwierdz_ustaw";
			this.zatwierdz_ustaw.Size = new System.Drawing.Size(360, 28);
			this.zatwierdz_ustaw.TabIndex = 3;
			this.zatwierdz_ustaw.Text = "Wpisz";
			this.zatwierdz_ustaw.UseVisualStyleBackColor = false;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 32);
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel_nagluwek_miesiac);
			this.splitContainer1.Panel1.Controls.Add(this.panel2);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.panel3);
			this.splitContainer1.Panel2.Controls.Add(this.wpisy_panel);
			this.splitContainer1.Size = new System.Drawing.Size(923, 665);
			this.splitContainer1.SplitterDistance = 558;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 4;
			// 
			// panel_nagluwek_miesiac
			// 
			this.panel_nagluwek_miesiac.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.panel_nagluwek_miesiac.Controls.Add(this.panel_miesiac);
			this.panel_nagluwek_miesiac.Controls.Add(this.panel_grafika);
			this.panel_nagluwek_miesiac.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel_nagluwek_miesiac.Location = new System.Drawing.Point(0, 0);
			this.panel_nagluwek_miesiac.Margin = new System.Windows.Forms.Padding(4);
			this.panel_nagluwek_miesiac.Name = "panel_nagluwek_miesiac";
			this.panel_nagluwek_miesiac.Size = new System.Drawing.Size(558, 110);
			this.panel_nagluwek_miesiac.TabIndex = 3;
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(419, 0);
			this.panel1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.ClientSize = new System.Drawing.Size(923, 697);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.panel_menu);
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MaximumSize = new System.Drawing.Size(1194, 974);
			this.MinimumSize = new System.Drawing.Size(394, 236);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Kalendarz";
			this.panel_menu.ResumeLayout(false);
			this.panel_grafika.ResumeLayout(false);
			this.panel_grafika.PerformLayout();
			this.panel_miesiac.ResumeLayout(false);
			this.wpisy_panel.ResumeLayout(false);
			this.wpisy_panel.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel_nagluwek_miesiac.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		private System.Windows.Forms.Panel panel1;

		#endregion
		private System.Windows.Forms.Panel panel_menu;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel_grafika;
		private System.Windows.Forms.Panel panel_miesiac;
		private System.Windows.Forms.Panel wpisy_panel;
		private System.Windows.Forms.TextBox ustawienie_tytul_wydarzenia;
		private System.Windows.Forms.Button zatwierdz_ustaw;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.CheckBox czy_trwa_kilka_dni;
		private System.Windows.Forms.Label wpis_tekst1;
		private System.Windows.Forms.Label wpis_tekst3;
		private System.Windows.Forms.Label wpis_tekst2;
		private System.Windows.Forms.Button wczytywanie_button;
		private System.Windows.Forms.Button zapisz_button;
		private System.Windows.Forms.ComboBox ustawienia_dnia_poczatek;
		private System.Windows.Forms.ComboBox ustawienia_rok_poczatek;
		private System.Windows.Forms.ComboBox ustawienie_miesiaca_poczatek;
		//private System.Windows.Forms.Button impurtuj_button;
		private System.Windows.Forms.ComboBox ustawienie_minuty_koniec;
		private System.Windows.Forms.ComboBox ustawienie_godziny_koniec;
		private System.Windows.Forms.ComboBox ustawienie_minuty_poczatek;
		private System.Windows.Forms.ComboBox ustawienie_godziny_poczatek;
		private System.Windows.Forms.Button button_mieciac_tyl;
		private System.Windows.Forms.Button button_miesiac_nap;
		private System.Windows.Forms.Panel panel_nagluwek_miesiac;
		private System.Windows.Forms.ComboBox ustawienia_roku_koniec;
		private System.Windows.Forms.ComboBox ustawienia_miesiaca_koniec;
		private System.Windows.Forms.ComboBox ustawienia_dnia_koniec;
		
		
		void Button_mieciac_tylClick(object sender, System.EventArgs e)
		{
			Wstecz();
		}
		
		void Button_miesiac_napClick(object sender, System.EventArgs e)
		{
			Naprzod();
		}

		private System.Windows.Forms.Label numer_roku;
		
		void Ustawienia_rok_poczatekSelectedIndexChanged(object sender, System.EventArgs e)
		{
			poczatek.Rok(ToIntRok(ustawienia_rok_poczatek.Text));
			if(koniec<poczatek)
				koniec.Rok(poczatek.Rok());
			
			OdswierzKoniec();
			OdswierzDni();
		}
		
		void Ustawienia_roku_koniecSelectedIndexChanged(object sender, System.EventArgs e)
		{
			koniec.Rok(ToIntRok(ustawienia_roku_koniec.Text));
			if(koniec<poczatek)
				koniec.Rok(poczatek.Rok());
			
			OdswierzKoniec();
			OdswierzDni();
		}
		
		void Ustawienie_miesiaca_poczatekSelectedIndexChanged(object sender, System.EventArgs e)
		{
			poczatek.Miesiac(ToIntMiesiac(ustawienie_miesiaca_poczatek.Text));
			if(koniec<poczatek)
				koniec.Miesiac(poczatek.Miesiac());
			
			OdswierzKoniec();
			OdswierzDni();
		}
		
		void Ustawienia_miesiaca_koniecSelectedIndexChanged(object sender, System.EventArgs e)
		{
			koniec.Miesiac(ToIntMiesiac(ustawienia_miesiaca_koniec.Text));
			if(koniec<poczatek)
				koniec.Miesiac(poczatek.Miesiac());
			
			OdswierzKoniec();
			OdswierzDni();
		}
		
		void Ustawienia_dnia_poczatekSelectedIndexChanged(object sender, System.EventArgs e)
		{
			poczatek.Dzien(Convert.ToInt32(ustawienia_dnia_poczatek.Text));
			if(koniec<poczatek)
				koniec.Dzien(poczatek.Dzien());
			
			OdswierzKoniec();
		}
		
		void Ustawienia_dnia_koniecSelectedIndexChanged(object sender, System.EventArgs e)
		{
			koniec.Dzien(Convert.ToInt32(ustawienia_dnia_koniec.Text));
			if(koniec<poczatek)
				koniec.Dzien(poczatek.Dzien());
			
			OdswierzKoniec();
		}
		
		void Ustawienie_godziny_poczatekSelectedIndexChanged(object sender, System.EventArgs e)
		{
			poczatek.Godzina(Convert.ToInt32(ustawienie_godziny_poczatek.Text));
			if(koniec<poczatek)
				koniec.Godzina(poczatek.Godzina());
			
			OdswierzKoniec();
		}
		
		void Ustawienie_godziny_koniecSelectedIndexChanged(object sender, System.EventArgs e)
		{
			koniec.Godzina(Convert.ToInt32(ustawienie_godziny_koniec.Text));
			if(koniec<poczatek)
				koniec.Godzina(poczatek.Godzina());
			
			OdswierzKoniec();
		}

		void Ustawienie_minuty_poczatekSelectedIndexChanged(object sender, System.EventArgs e)
		{
			poczatek.Minuta(Convert.ToInt32(ustawienie_minuty_poczatek.Text));
			if(koniec<poczatek)
				koniec.Minuta(poczatek.Minuta());
			
			OdswierzKoniec();
		}
		
		void Ustawienie_minuty_koniecSelectedIndexChanged(object sender, System.EventArgs e)
		{
			koniec.Minuta(Convert.ToInt32(ustawienie_minuty_koniec.Text));
			if(koniec<poczatek)
				koniec.Minuta(poczatek.Minuta());
			
			OdswierzKoniec();
		}
		

	}
}

