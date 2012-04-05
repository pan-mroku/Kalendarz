using System;
public class Data : Data_dzien  {
	private int godzina;
	private int minuta;

	public Data(int _rok, int _miesiac, int _dzien, int _godzina, int _minuta):base(_rok,_miesiac,_dzien) {
		throw new System.Exception("Not implemented");
	}
	public void Godzina(int _godzina) {
		throw new System.Exception("Not implemented");
	}
	public void Minuta(int _minuta) {
		throw new System.Exception("Not implemented");
	}
	public int Godzina() {
		throw new System.Exception("Not implemented");
	}
	public int Minuta() {
		throw new System.Exception("Not implemented");
	}
	public static bool operator>(Data x, Data y) {
		throw new System.Exception("Not implemented");
	}
	public static bool operator<=(Data x, Data y) {
		throw new System.Exception("Not implemented");
	}
	public static bool operator<(Data x, Data y) {
		throw new System.Exception("Not implemented");
	}
	public static bool operator>=(Data x, Data y) {
		throw new System.Exception("Not implemented");
	}
	public static bool operator==(Data x, Data y) {
		throw new System.Exception("Not implemented");
	}
	public static bool operator!=(Data x, Data y) {
		throw new System.Exception("Not implemented");
	}
	public override bool Equals(object obj) {
		throw new System.Exception("Not implemented");
	}
	public override int GetHashCode() {
		throw new System.Exception("Not implemented");
	}

}
