using System;
public class Data : Data_dzien  {
	private int godzina;
	private int minuta;

	public Data(int _rok, int _miesiac, int _dzien, int _godzina, int _minuta):base(_rok,_miesiac,_dzien) {
        godzina = _godzina;
        minuta = _minuta;
	}
	public void Godzina(int _godzina) {
        godzina = _godzina;
	}
	public void Minuta(int _minuta) {
        minuta = _minuta;
	}
	public int Godzina() {
        return (godzina);
	}
	public int Minuta() {
        return (minuta);
	}
	public static bool operator>(Data x, Data y) {
        if ((x.Minuta() > y.Minuta()) && (x.Godzina() > y.Godzina()) && (x.Dzien > y.Dzien) && (x.Miesiac > y.Miesiac) && (x.Rok > y.Rok)) return (true);
        else return (false);
	}
	public static bool operator<=(Data x, Data y) {
        if ((x.Minuta() <= y.Minuta()) && (x.Godzina() <= y.Godzina()) && (x.Dzien <= y.Dzien) && (x.Miesiac <= y.Miesiac) && (x.Rok <= y.Rok)) return (true);
        else return (false);
	}
	public static bool operator<(Data x, Data y) {
        if ((x.Minuta() < y.Minuta()) && (x.Godzina() < y.Godzina()) && (x.Dzien < y.Dzien) && (x.Miesiac < y.Miesiac) && (x.Rok < y.Rok)) return (true);
        else return (false);
	}
	public static bool operator>=(Data x, Data y) {
        if ((x.Minuta() >= y.Minuta()) && (x.Godzina() >= y.Godzina()) && (x.Dzien >= y.Dzien) && (x.Miesiac >= y.Miesiac) && (x.Rok >= y.Rok)) return (true);
        else return (false);
	}
	public static bool operator==(Data x, Data y) {
        if ((x.Minuta() == y.Minuta()) && (x.Godzina() == y.Godzina()) && (x.Dzien == y.Dzien) && (x.Miesiac == y.Miesiac) && (x.Rok == y.Rok)) return (true);
        else return (false);
	}
	public static bool operator!=(Data x, Data y) {
        if ((x.Minuta() != y.Minuta()) && (x.Godzina() != y.Godzina()) && (x.Dzien != y.Dzien) && (x.Miesiac != y.Miesiac) && (x.Rok != y.Rok)) return (true);
        else return (false);
	}
	public override bool Equals(object obj) {
        if ((obj is Data) && (this == (Data)obj)) return (true);
        else return (false);
	}
	public override int GetHashCode() {
        return (base.GetHashCode() + godzina*60 + minuta);
	}

}
