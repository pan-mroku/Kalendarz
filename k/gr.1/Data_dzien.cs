using System;
using System.Collections.Generic;

public enum DniTygodnia { poniedziałek = 0, wtorek, środa, czwartek, piątek, sobota, niedziela };

public class Data_dzien
{
    private int rok;
    private int miesiac;
    private int dzien;

    public Data_dzien(int _rok, int _miesiac, int _dzien)
    {
        this.rok = _rok;
        this.miesiac = _miesiac;
        this.dzien = _dzien;
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
        if (n > 366)
        {
            if (x.CzyPrzestepny(x.Rok) && x.CzyPrzestepny(x.Rok + 1))
            {
                
            }
        }
        throw new System.Exception("Not implemented");
    }

    public static Data_dzien operator -(Data_dzien x, int n)
    {
        throw new System.Exception("Not implemented");
    }

    public void ZmienRok(int _rok) //zmienia rok na podany 2011-9999
    {
        if (_rok > 2011 && _rok < 9999)
        {
            this.rok = _rok;
        }
        else
            this.rok = 0;
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

    public void ZmienMiesiac(int _miesac) //zmienia miesiąc na podany 1-12
    {
        if (_miesac > 0 && _miesac < 13)
            miesiac = _miesac;
        else
            throw new Exception("Zła liczba opisująca miesiąc. (miesiąc to liczba z przedziału 1-12)");
    }

    public void ZmienDzien(int _dzien) //zmienia dzień na podany 1-31
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
                    throw new Exception("Podany numer dnia jest zbyt wysoki, ten miesiąc ma tylko 30 dni.");
            }
            else if (m31.Contains(miesiac))
            {
                if (_dzien < 32)
                    dzien = _dzien;
                else
                    throw new Exception("Podany numer dnia jest zbyt wysoki, ten miesiąc ma tylko 31 dni.");
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
                        throw new Exception("Luty w tym w podanym roku może mieć tylko 29 dni.");
                }
                else //Jeśli rok jest nie przestępny to luty może mieć 28 dni
                {
                    if (_dzien < 29)
                    {
                        dzien = _dzien;
                    }
                    else
                        throw new Exception("Luty w tym w podanym roku może mieć tylko 28 dni.");
                }
            }
            else
            {
                throw new Exception("Niezainicjalizowane pole miesiąc, aby wprowadzić dzień, musisz najpierw podać miesiąc");
            }
        }
    }

    public int Rok
    {
        get { return rok; }
    }

    public int Miesiac
    {
        get { return miesiac; }
    }

    public int Dzien
    {
        get { return dzien; }
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

    public static int LiczbaDniWMiesiac(int _rok, int _miesiac)
    {
        return System.DateTime.DaysInMonth(_rok, _miesiac); //obsłużyć wyjątek gdy podano nieprawidłowy rok lub miesiąc
        //throw new System.Exception("Not implemented");
    }
}
