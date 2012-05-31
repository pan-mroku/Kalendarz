using System;
using System.Collections.Generic;
public enum DniTygodnia { poniedziałek = 0, wtorek, środa, czwartek, piątek, sobota, niedziela };

[Serializable]
public class Data_dzien
{
    protected int rok;
    protected int miesiac;
    protected int dzien;

    public Data_dzien()
    {
        Rok(DateTime.Today.Year);
        Miesiac(DateTime.Today.Month);
        Dzien(DateTime.Today.Day);
    }

    public Data_dzien(Data_dzien kopia)
    {
        rok = kopia.rok;
        miesiac = kopia.miesiac;
        dzien = kopia.dzien;
    }
    
    public Data_dzien(int _rok, int _miesiac, int _dzien)
    {
        Rok(_rok);
        Miesiac(_miesiac);
        Dzien(_dzien);
    }

    public static bool operator >(Data_dzien x, Data_dzien y)
    {
        if (x.rok > y.rok)
            return true;
        else if (x.rok == y.rok)
        {
            if (x.miesiac > y.miesiac)
                return true;
            else if (x.miesiac == y.miesiac)
            {
                if (x.dzien > y.dzien)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        else
            return false;
    }
    public static bool operator <=(Data_dzien x, Data_dzien y)
    {
        return !(x > y);
    }
    public static bool operator <(Data_dzien x, Data_dzien y)
    {
        return y > x;
    }
    public static bool operator >=(Data_dzien x, Data_dzien y)
    {
        return !(x < y);
    }
    public static bool operator ==(Data_dzien x, Data_dzien y)
    {
        if (x.rok == y.rok)
        {
            if (x.miesiac == y.miesiac)
            {
                if (x.dzien == y.dzien)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        else
            return false;
    }
    public static bool operator !=(Data_dzien x, Data_dzien y)
    {
        return !(x == y);
    }

    public static Data_dzien operator +(Data_dzien x, int n)
    {
        Data_dzien nowy=new Data_dzien(x.rok,x.miesiac,x.dzien);
        while (n > 0)
        {
            nowy.DodajDzien();
            n -= 1;
        }
        return nowy;
    }
    public static Data_dzien operator -(Data_dzien x, int n)
    {
        Data_dzien nowy=new Data_dzien(x.rok,x.miesiac,x.dzien);
        while (n > 0)
        {
            nowy.OdejmijDzien();
            n -= 1;
        }
        return nowy;
    }
    public static Data_dzien operator ++ (Data_dzien x)
    {
        return x+1;
    }

    public static Data_dzien operator -- (Data_dzien x)
    {
        return x-1;
    }

    private bool CzyPrzestepny(int _rok) //zwraca true jeśli podany rok jest przestępny, jeśli nie to zwraca false
        /*Rok jest przestępny jeżeli jest podzielny przez 4, ale nie jest podzielny przez 100 lub jest podzielny przez 400*/
    {
        if (_rok % 4 == 0)
        {
            if (_rok % 100 == 0)
            {
                if (_rok % 400 == 0)
                    return true;
                else
                    return false;
            }
            else
                return true;
        }
        else
            return false;
    }

    private int LiczbaDniRoku() //zwraca liczbę dni roku
    {
        if (CzyPrzestepny(rok))
        {
            return 366;
        }
        else
            return 365;
    }

    public static int LiczbaDniWMiesiac(int _rok, int _miesiac)
    {
        try
        {
            return System.DateTime.DaysInMonth(_rok, _miesiac); //obsłużyć wyjątek gdy podano nieprawidłowy rok lub miesiąc
        }
        catch (ArgumentOutOfRangeException)
        {
            throw new Exception("Podano złe wartości roku i miesiąc. Zakres przekroczony."+_rok+" "+_miesiac);
        }
    }

    public int LiczbaDniWMiesiac()
    {
        return LiczbaDniWMiesiac(rok,miesiac);
    }
    
    protected void DodajDzien()
    {
        if (dzien < LiczbaDniWMiesiac(rok,miesiac))
        {
            Dzien(dzien + 1);
        }
        else if (miesiac < 12)
        {
            Miesiac(miesiac + 1);
            Dzien(1);
        }
        else
        {
            Rok(rok + 1);
            Miesiac(1);
            Dzien(1);
        }
    }

    protected void OdejmijDzien()
    {
        if (dzien > 1)
        {
            Dzien(dzien - 1);
        }
        else if (miesiac > 1)
        {
            Miesiac(miesiac - 1);
            Dzien(LiczbaDniWMiesiac(rok, miesiac));
        }
        else
        {
            Rok(rok - 1);
            Miesiac(12);
            Dzien(31);
        }
    }

    public void Rok(int _rok) //zmienia rok na podany 2012-9999 @Ale tak właściwie, to po co?
    {
        /*if (_rok > 2011 && _rok <= 9999)
        {
            this.rok = _rok;
        }
        else
            this.rok = 0;*/
        this.rok=_rok;
    }

    public void Miesiac(int _miesiac) //zmienia miesiąc na podany 1-12
    {
        if (_miesiac > 0 && _miesiac < 13)
            miesiac = _miesiac;
        else
            throw new Exception("Zła liczba opisująca miesiąc. (miesiąc to liczba z przedziału 1-12)"+_miesiac);
    }

    public void Dzien(int _dzien) //zmienia dzień na podany 1-31
        /*Styczeń - 31, Luty - 28/29, Marzec - 31, Kwiecień - 30, Maj - 31, Czerwiec - 30, Lipiec - 31, Sierpień - 31,
         *Wrzesień - 30, Październik - 31, Listopad - 30, Grudzień - 31*/
    {
        List<int> m30 = new List<int>() { 4, 6, 9, 11 };
        List<int> m31 = new List<int>() { 1, 3, 5, 7, 8, 10, 12 };

        if (_dzien > 0)
        {
            if (m30.Contains(miesiac))
            {
                if (_dzien < 31)
                    dzien = _dzien;
                else
                    dzien=30;
            }
            else if (m31.Contains(miesiac))
            {
                if (_dzien < 32)
                    dzien = _dzien;
                else
                    dzien=31;
            }
            else if (miesiac == 2)
            {
                if (CzyPrzestepny(rok)) //Jeśli rok jest przestępny to luty może mieć 29 dni
                {
                    if (_dzien < 30)
                    {
                        dzien = _dzien;
                    }
                    else
                        dzien=29;
                }
                else //Jeśli rok jest nie przestępny to luty może mieć 28 dni
                {
                    if (_dzien < 29)
                    {
                        dzien = _dzien;
                    }
                    else
                        dzien=28;
                }
            }
            else
            {
                throw new Exception("Niezainicjalizowane pole miesiąc, aby wprowadzić dzień, musisz najpierw podać miesiąc");
            }
        }
    }

    public int Rok()
    {
        return rok;
    }

    public int Miesiac()
    {
        return miesiac;
    }

    public int Dzien()
    {
        return dzien;
    }

    public DniTygodnia DzienTygodnia()
        /*W systemowej dacie dni zaczynają numerację od niedzieli*/
    {
        DateTime dt = new DateTime(rok, miesiac, dzien);
        int liczbaDnia = (int)dt.DayOfWeek;
        if (liczbaDnia == 0)
        {
            liczbaDnia = 6;
        }
        else
            liczbaDnia -= 1;

        return (DniTygodnia)liczbaDnia;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || (this.GetType() != obj.GetType()))
            return false;
        else
        {
            if (this.rok == ((Data_dzien)obj).rok && this.miesiac == ((Data_dzien)obj).miesiac && this.dzien == ((Data_dzien)obj).dzien)
            {
                return true;
            }
            else
                return false;
        }
    }

    public override int GetHashCode()
    {
        return ((366 * rok) + (31 * miesiac) + dzien) * 24 * 60;
    }

    public override string ToString()
    {
        return rok + "-" + miesiac + "-" + dzien;
    }
}
