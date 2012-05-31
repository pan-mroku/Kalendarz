using System;

[Serializable]
public class Data : Data_dzien  {
	private int godzina;
	private int minuta;

	public Data():base()
	{
		godzina=7;
		minuta=0;
	}

    public Data(Data kopia):base(kopia.rok,kopia.miesiac,kopia.dzien)
    {
        godzina = kopia.godzina;
        minuta = kopia.minuta;
    }
	
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
		if (x.Rok() > y.Rok())
		{
			return (true);
		}
		else if (x.Rok() == y.Rok())
		{
			if (x.Miesiac() > y.Miesiac())
			{
				return (true);
			}
			else if (x.Miesiac() == y.Miesiac())
			{
				if (x.Dzien() > y.Dzien())
				{
					return (true);
				} else if (x.Dzien() == y.Dzien())
				{
					if (x.Godzina() > y.Godzina())
					{
						return (true);
					}
					else if (x.Godzina() == y.Godzina())
					{
						if (x.Minuta() > y.Minuta())
						{
							return (true);
						}
					}
				}
			}

		}
		return (false);
	}
	public static bool operator<=(Data x, Data y) {
		if (x.Rok() <= y.Rok())
		{
			return (true);
		}
		else if (x.Rok() == y.Rok())
		{
			if (x.Miesiac() <= y.Miesiac())
			{
				return (true);
			}
			else if (x.Miesiac() == y.Miesiac())
			{
				if (x.Dzien() <= y.Dzien())
				{
					return (true);
				}
				else if (x.Dzien() == y.Dzien())
				{
					if (x.Godzina() <= y.Godzina())
					{
						return (true);
					}
					else if (x.Godzina() == y.Godzina())
					{
						if (x.Minuta() <= y.Minuta())
						{
							return (true);
						}
					}
				}
			}

		}
		return (false);
	}
	public static bool operator<(Data x, Data y) {
		if (x.Rok() < y.Rok())
		{
			return (true);
		}
		else if (x.Rok() == y.Rok())
		{
			if (x.Miesiac() < y.Miesiac())
			{
				return (true);
			}
			else if (x.Miesiac() == y.Miesiac())
			{
				if (x.Dzien() < y.Dzien())
				{
					return (true);
				}
				else if (x.Dzien() == y.Dzien())
				{
					if (x.Godzina() < y.Godzina())
					{
						return (true);
					}
					else if (x.Godzina() == y.Godzina())
					{
						if (x.Minuta() < y.Minuta())
						{
							return (true);
						}
					}
				}
			}

		}
		return (false);
	}
	public static bool operator>=(Data x, Data y) {
		return !(x<y);
	}
	
	public static Data operator +(Data x, int n)
    {
    	Data_dzien nowy=new Data_dzien(x.rok,x.miesiac,x.dzien);
        while (n > 0)
        {
            nowy++;
            n -= 1;
        }
        return new Data(nowy.Rok(), nowy.Miesiac(), nowy.Dzien(), x.godzina, x.minuta);
    }
    public static Data operator -(Data x, int n)
    {
    	Data_dzien nowy=new Data_dzien(x.rok,x.miesiac,x.dzien);
        while (n > 0)
        {
            nowy--;
            n -= 1;
        }
        return new Data(nowy.Rok(), nowy.Miesiac(), nowy.Dzien(), x.godzina, x.minuta);
    }
    public static Data operator ++ (Data x)
    {
    	return x+1;
    }

    public static Data operator -- (Data x)
    {
    	return x-1;
    }

	
	public static bool operator==(Data x, Data y) {
		if ((x.Minuta() == y.Minuta()) && (x.Godzina() == y.Godzina()) && (x.Dzien() == y.Dzien()) && (x.Miesiac() == y.Miesiac()) && (x.Rok() == y.Rok())) return (true);
		else return (false);
	}
	public static bool operator!=(Data x, Data y) {
		return !(x==y);
	}
	public override bool Equals(object obj) {
		if ((obj is Data) && (this == (Data)obj)) return (true);
		else return (false);
	}
	public override int GetHashCode() {
		return (base.GetHashCode() + godzina*60 + minuta);
	}
    public override string ToString()
	{
    	return base.ToString()+"-"+godzina+"-"+minuta;
    	//return string.Format(base.ToString()+", [Data Godzina={0}, Minuta={1}]", godzina, minuta);
	}

}
