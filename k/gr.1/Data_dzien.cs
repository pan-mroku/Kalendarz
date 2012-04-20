using System; using System.Collections.Generic;  public enum DniTygodnia { poniedziałek = 0, wtorek, środa, czwartek, piątek, sobota, niedziela };  public class Data_dzien {     private int rok;     private int miesiac;     private int dzien;      public Data_dzien(int _rok, int _miesiac, int _dzien)     {
        ZmienRok(_rok);
        ZmienMiesiac(_miesiac);
        ZmienDzien(_dzien);     }      public static bool operator >(Data_dzien x, Data_dzien y)     {         if (x.rok > y.rok)             return true;         else if (x.rok == y.rok)         {             if (x.miesiac > y.miesiac)                 return true;             else if (x.miesiac == y.miesiac)             {                 if (x.dzien > y.dzien)                     return true;                 else                     return false;             }             else                 return false;         }         else             return false;     }     public static bool operator <=(Data_dzien x, Data_dzien y)     {         return !(x > y);     }     public static bool operator <(Data_dzien x, Data_dzien y)     {         return y > x;     }     public static bool operator >=(Data_dzien x, Data_dzien y)     {         return !(x < y);     }     public static bool operator ==(Data_dzien x, Data_dzien y)     {         if (x.rok == y.rok)         {             if (x.miesiac == y.miesiac)             {                 if (x.dzien == y.dzien)                     return true;                 else                     return false;             }             else                 return false;         }         else             return false;     }     public static bool operator !=(Data_dzien x, Data_dzien y)     {         return !(x == y);     }      public static Data_dzien operator +(Data_dzien x, int n)     {
        while (n > 0)
        {
            x.DodajDzien();
            n -= 1;
        }
        return x;     }     public static Data_dzien operator -(Data_dzien x, int n)
    {
        while (n > 0)
        {
            x.OdejmijDzien();
            n -= 1;
        }
        return x;     }       private bool CzyPrzestepny(int _rok) //zwraca true jeśli podany rok jest przestępny, jeśli nie to zwraca false     /*Rok jest przestępny jeżeli jest podzielny przez 4, ale nie jest podzielny przez 100 lub jest podzielny przez 400*/     {         if (_rok % 4 == 0)         {             if (_rok % 100 == 0)             {                 if (_rok % 400 == 0)                     return true;                 else                     return false;             }             else                 return true;         }         else             return false;     }      private int LiczbaDniRoku() //zwraca liczbę dni roku     {         if (CzyPrzestepny(rok))         {             return 366;         }         else             return 365;     }

    public static int LiczbaDniWMiesiac(int _rok, int _miesiac)
    {
        try
        {
            return System.DateTime.DaysInMonth(_rok, _miesiac); //obsłużyć wyjątek gdy podano nieprawidłowy rok lub miesiąc
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new Exception("Podano złe wartości roku i miesiąc. Zakres przekroczony.");
        }
    }

    private void DodajDzien()
    {
        if (this.Dzien < LiczbaDniWMiesiac(this.Rok, this.Miesiac))
        {
            ZmienDzien(this.Dzien + 1);
        }
        else if (this.Miesiac < 12)
        {
            ZmienMiesiac(this.Miesiac + 1);
            ZmienDzien(1);
        }
        else
        {
            ZmienRok(this.Rok + 1);
            ZmienMiesiac(1);
            ZmienDzien(1);
        }
    }

    private void OdejmijDzien()
    {
        if (this.Dzien > 1)
        {
            ZmienDzien(this.Dzien - 1);
        }
        else if (this.Miesiac > 1)
        {
            ZmienMiesiac(this.Miesiac - 1);
            ZmienDzien(LiczbaDniWMiesiac(this.Rok, this.Miesiac));
        }
        else
        {
            ZmienRok(this.Rok - 1);
            ZmienMiesiac(12);
            ZmienDzien(31);
        }
    }      public void ZmienRok(int _rok) //zmienia rok na podany 2012-9999     {         if (_rok > 2011 && _rok <= 9999)         {             this.rok = _rok;         }         else             this.rok = 0;     }      public void ZmienMiesiac(int _miesiac) //zmienia miesiąc na podany 1-12     {         if (_miesiac > 0 && _miesiac < 13)             miesiac = _miesiac;         else             throw new Exception("Zła liczba opisująca miesiąc. (miesiąc to liczba z przedziału 1-12)");     }      public void ZmienDzien(int _dzien) //zmienia dzień na podany 1-31     /*Styczeń - 31, Luty - 28/29, Marzec - 31, Kwiecień - 30, Maj - 31, Czerwiec - 30, Lipiec - 31, Sierpień - 31,      *Wrzesień - 30, Październik - 31, Listopad - 30, Grudzień - 31*/     {         List<int> m30 = new List<int>() { 4, 6, 9, 11 };         List<int> m31 = new List<int>() { 1, 3, 5, 7, 8, 10, 12 };          if (_dzien > 0)         {             if (m30.Contains(miesiac))             {                 if (_dzien < 31)                     dzien = _dzien;                 else                     throw new Exception("Podany numer dnia jest zbyt wysoki, ten miesiąc ma tylko 30 dni.");             }             else if (m31.Contains(miesiac))             {                 if (_dzien < 32)                     dzien = _dzien;                 else                     throw new Exception("Podany numer dnia jest zbyt wysoki, ten miesiąc ma tylko 31 dni.");             }             else if (miesiac == 2)             {                 if (CzyPrzestepny(rok)) //Jeśli rok jest przestępny to luty może mieć 29 dni                 {                     if (_dzien < 30)                     {                         dzien = _dzien;                     }                     else                         throw new Exception("Luty w tym w podanym roku może mieć tylko 29 dni.");                 }                 else //Jeśli rok jest nie przestępny to luty może mieć 28 dni                 {                     if (_dzien < 29)                     {                         dzien = _dzien;                     }                     else                         throw new Exception("Luty w tym w podanym roku może mieć tylko 28 dni.");                 }             }             else             {                 throw new Exception("Niezainicjalizowane pole miesiąc, aby wprowadzić dzień, musisz najpierw podać miesiąc");             }         }     }      public int Rok     {         get { return rok; }     }      public int Miesiac     {         get { return miesiac; }     }      public int Dzien     {         get { return dzien; }     }      public DniTygodnia DzienTygodnia() /*W systemowej dacie dni zaczynają numerację od niedzieli*/     {         DateTime dt = new DateTime(rok, miesiac, dzien);         int liczbaDnia = (int)dt.DayOfWeek;         if (liczbaDnia == 0)         {             liczbaDnia = 6;         }         else             liczbaDnia -= 1;          return (DniTygodnia)liczbaDnia;     }      public override bool Equals(object obj)     {         if (obj == null || (this.GetType() != obj.GetType()))             return false;         else         {             if (this.rok == ((Data_dzien)obj).rok && this.miesiac == ((Data_dzien)obj).miesiac && this.dzien == ((Data_dzien)obj).dzien)             {                 return true;             }             else                 return false;         }     }      public override int GetHashCode()     {         return ((366 * rok) + (31 * miesiac) + dzien) * 24 * 60;     }      public override string ToString()     {         return rok + "-" + miesiac + "-" + dzien;     }  } 