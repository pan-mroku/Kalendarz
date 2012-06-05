using System;

[Serializable]
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
        return (x.poczatek > y.poczatek);
    }
    public static bool operator <=(Wpis x, Wpis y)
    {
        return (x.poczatek <= y.poczatek) ;
    }
    public static bool operator <(Wpis x, Wpis y)
    {
        return(x.poczatek < y.poczatek) ;
    }
    public static bool operator >=(Wpis x, Wpis y)
    {
        return (x.poczatek >= y.poczatek) ;
    }
    public static bool operator ==(Wpis x, Wpis y)
    {
        return (x.poczatek == y.poczatek) ;
    }
    public static bool operator !=(Wpis x, Wpis y)
    {
        return (x.poczatek != y.poczatek);
        
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
    public void Poczatek(Data _poczatek)
    {
        poczatek = _poczatek;
    }
    public void Koniec(Data _koniec)
    {
        koniec = _koniec;
    }
    public void Tytul(string _tytul)
    {
        tytul = _tytul;
    }
    public Data Poczatek()
    {
        return poczatek;
    }
    public Data Koniec()
    {
        return koniec;
    }
    public string Tytul()
    {
        return tytul;
    }
    
    /*zwraca d³ugoœc trwania wpisu w minutach
     *( wiêcej ni¿ dzieñ wpis trwa³ nie bêdzie,
     * ze wzglêdu na to jak jest napisane zdarzenie
     * klikniêcia przycisku "wpisz")*/
    public int Dlugosc()
    {
        int godziny=koniec.Godzina()-poczatek.Godzina();
        int minuty=koniec.Minuta()-koniec.Minuta();
        return godziny*60+minuty;
    }
    public override string ToString()
    {
        return string.Format("[Wpis Poczatek={0}, Koniec={1}, Tytul={2}]", poczatek, koniec, tytul);
    }

}