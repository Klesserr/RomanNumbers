using System;


namespace MyApp // Note: actual namespace depends on the project name.
{
	internal class RomanNumbers
	{
		static void Main(string[] args)
		{
			//PARTE DE LETRA ROMANA A NUMERO ENTERO:

			string romanNumber = "XLIV";
			int roman = FromRoman(romanNumber);
			Console.WriteLine(roman);

			//PARTE DE NUMERO ENTERO A LETRAS ROMANAS:

			//int number = 2740;
			//string numberToRoman = ToRoman(number);
			//Console.WriteLine(numberToRoman);


		}

		public static int FromRoman(string romanNumeral)
		{
			int romanToNumber = 0;
			Dictionary<string, int> kvp = new Dictionary<string, int>()
			{
				["M"] = 1000,
				["CM"] = 900,
				["D"] = 500,
				["CD"] = 400,
				["C"] = 100,
				["XC"] = 90,
				["L"] = 50,
				["XL"] = 40,
				["X"] = 10,
				["IX"] = 9,
				["V"] = 5,
				["IV"] = 4,
				["I"] = 1,
			};

			if (romanNumeral.Length == 1 || romanNumeral.Length == 2)
			{
				for (int i = 0; i < romanNumeral.Length; i++)
				{
					foreach (var k in kvp)
					{
						if (k.Key == romanNumeral)
						{
							romanToNumber += k.Value;
							return romanToNumber;
						}
						else if (k.Key == romanNumeral[i].ToString())
						{
							romanToNumber += k.Value;
						}
					}
				}
				return romanToNumber;
			}

			foreach (var k in kvp)
			{
				for (int j = 0; j < romanNumeral.Length - 1; j++)
				{
					string auxRoman = romanNumeral[j].ToString();
					string nextAuxRoman = romanNumeral[j + 1].ToString();
					if (k.Key == auxRoman)
					{
						foreach (var p in kvp)
						{
							if (p.Key == nextAuxRoman)
							{
								if (k.Value >= p.Value)
								{
									romanToNumber += k.Value;
								}
								else if (k.Value < p.Value)
								{
									romanToNumber -= k.Value;
								}
							}
						}
					}
				}
			}

			string lastRoman = romanNumeral[romanNumeral.Length - 1].ToString();
			foreach (var k in kvp)
			{
				if (k.Key == lastRoman)
				{
					romanToNumber += k.Value;
					return romanToNumber;
				}
			}

			return romanToNumber;
		}

		public static string ToRoman(int n)
		{
			string auxRomanLetters = "";
			int number = 0;
			Dictionary<int, string> kvp = new Dictionary<int, string>()
			{
				[1000] = "M",
				[900] = "CM",
				[500] = "D",
				[400] = "CD",
				[100] = "C",
				[90] = "XC",
				[50] = "L",
				[40] = "XL",
				[10] = "X",
				[9] = "IX",
				[5] = "V",
				[4] = "IV",
				[1] = "I",
			};

			List<int> parts = new List<int>();
			int i = 0;
			while (n > 0)
			{
				int result = n % 10;
				int prueba = (int)Math.Pow(10, i);
				prueba *= result;
				n /= 10;
				i++;
				parts.Insert(0, prueba);
			}

			foreach (var p in parts)
			{
				number = p;
				foreach (var k in kvp)
				{
					while (number >= k.Key)
					{
						number -= k.Key;
						auxRomanLetters += k.Value;
					}
				}
			}
			return auxRomanLetters;
		}


	}
}