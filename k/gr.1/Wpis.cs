using System;
public class Wpis
{
    private Data poczatek;
    private Data koniec;
    private string tytul;

    public Wpis(Data _poczatek, Data _koniec, String _tytul)
    {
        this.poczatek = _poczatek;
        this.koniec = _koniec;
        this.tytul = _tytul;
    }
    public static bool operator >(Wpis x, Wpis y)
    {
        if (x.poczatek > y.poczatek)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator <=(Wpis x, Wpis y)
    {
        if (x.poczatek <= y.poczatek)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator <(Wpis x, Wpis y)
    {
        if (x.poczatek < y.poczatek)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator >=(Wpis x, Wpis y)
    {
        if (x.poczatek >= y.poczatek)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator ==(Wpis x, Wpis y)
    {
        if (x.poczatek == y.poczatek)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool operator !=(Wpis x, Wpis y)
    {
        if (x.poczatek != y.poczatek)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override bool Equals(object obj)
    {
        if (obj == null)
        {
            return false;
        }
        Wpis a = obj as Wpis;
        if ((System.Object)a == null)
        {
            return false;
        }
        return (this.tytul == a.tytul) && (this.poczatek == a.poczatek) && (this.koniec == a.koniec);
    }
    public override int GetHashCode()
    {
        return 0;
    }
    public void SetPoczatek(Data _poczatek)
    {
        this.poczatek = _poczatek;
    }
    public void SetKoniec(Data _koniec)
    {
        this.koniec = _koniec;
    }
    public void SetTytul(string _tytul)
    {
        this.tytul = _tytul;
    }
    public Data Poczatek
    {
        get
        {

            return poczatek;
        }

    }
    public Data Koniec
    {
        get
        {
            return koniec;
        }

    }
    public string Tytul
    {
        get
        {
            return this.tytul;
        }
    }



}
