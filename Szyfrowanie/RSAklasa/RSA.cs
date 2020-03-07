using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class RSACSPSample
{

	static void Main()
	{
	//	long p, q, e;
	//	Console.WriteLine("Podaj wartość p");
	//	p = long.Parse(Console.ReadLine());
	//	Console.WriteLine("Podaj wartość q");
	//	q = long.Parse(Console.ReadLine());
	//	Console.WriteLine("Podaj wartość e");
	//	e = long.Parse(Console.ReadLine());

	//	long n = p * q;
	//	long d = ObliczD(e, p, q);
	//	long dp = d % (p - 1);
	//	long dq = d % (q - 1);
	//	long inverseQ = (long)Math.Pow(q,(p-2)) % p;
	//	Console.WriteLine($"inverseQ = {inverseQ}");
	//	Console.WriteLine($"d = {d}");
	//	RSAParameters user_param = new RSAParameters();
	//	user_param.D = BitConverter.GetBytes(d);
	//	user_param.DP = BitConverter.GetBytes(dp);
	//	user_param.DQ = BitConverter.GetBytes(dq);
	//	user_param.Exponent = BitConverter.GetBytes(e);
	//	user_param.P = BitConverter.GetBytes(p);
	//	user_param.Q = BitConverter.GetBytes(q);
	//	user_param.Modulus = BitConverter.GetBytes(n);
	//	user_param.InverseQ = BitConverter.GetBytes(inverseQ);

		RSACryptoServiceProvider RSA1 = new RSACryptoServiceProvider();

		Console.WriteLine("Podaj treść wiadomosci do zaszyfrowania");
		string message = Console.ReadLine();
		Console.WriteLine();
		char[] dataASCII = message.ToCharArray(0, message.Length);
		int i = 0;
		byte[] data = new byte[message.Length];

		foreach (var item in dataASCII)
		{
			data[i] = Convert.ToByte((int)item);
			i++;
		}

		byte[] encryptedASCII = RSA1.Encrypt(data, true);
		i = 0;
		char[] encrypted = new char[encryptedASCII.Length];
		foreach (var item in encryptedASCII)
		{
			encrypted[i] = (char)item;
			i++;
		}
		string enMessage = string.Join("", encrypted);
		Console.WriteLine("Zaszyfrowana wiadomość: ");
		Console.WriteLine(enMessage);
		Console.WriteLine(); // szyfrowanie zakończone

		RSAParameters parameters = new RSAParameters();
		parameters = RSA1.ExportParameters(true);

		Console.WriteLine($"e = {BitConverter.ToString(parameters.Exponent, 0)}");
		Console.WriteLine($"p = {BitConverter.ToString(parameters.P, 0)}");
		Console.WriteLine($"q = {BitConverter.ToString(parameters.Q, 0)}");
		Console.WriteLine();

		Console.WriteLine("** tu sie dzieje **");
		Console.WriteLine(parameters.ToString());

		string s = "Tekst do zapisu w pliku!";
		File.WriteAllText(@"E:\Szyfrowanie.txt", s);


		RSACryptoServiceProvider RSA2 = new RSACryptoServiceProvider();

		RSA2.ImportParameters(parameters); // import parametrów szyfrowania klucza prywatnego jak i publicznego



		byte[] descryptedASCII = RSA2.Decrypt(encryptedASCII, true);
		i = 0;
		char[] descrypted = new char[descryptedASCII.Length];
		foreach (var item in descryptedASCII)
		{
			descrypted[i] = (char)item;
			i++;
		}
		string desMessage = string.Join("", descrypted);
		Console.WriteLine("Odzyskana wiadomość: ");
		Console.WriteLine(desMessage);
		Console.WriteLine("*");

		Console.ReadKey();
	}

	private static void Przepisz(string[] stringArray)
	{
		string nazwa = "ABCD10";
		byte[] tablica = System.Text.Encoding.Default.GetBytes(nazwa);

		int i = 0;
		byte[] byteArray = new byte[stringArray.Length];
		foreach (var item in tablica)
		{
			Console.WriteLine(item);
			// byteArray[i] = BitConverter.GetBytes(item);
			i++;
		}
	}


	public static long CalcueteD(long e, long p_, long q_)
	{
		long fi = (p_ - 1) * (q_ - 1);
		int a, ap, u, up, v, vp, q;
		a = (int)fi;
		ap = (int)e;
		u = 0;
		up = 1;
		v = 1;
		vp = 0;
		int x; //schowek
			   //Console.WriteLine($"*** Krok {i} ***");     // testowanie konkretnych kroków iteracyjnych
			   //Console.WriteLine($"(a,ap) = ({a},{ap})");
			   //Console.WriteLine($"(u,up,v,vp) = ({u},{up},{v},{vp})");
		do
		{
			q = a / ap;
			x = ap;
			ap = a - q * ap;
			a = x;
			x = up;
			up = u - q * up;
			u = x;
			x = vp;
			vp = v - q * vp;
			v = x;
			//i++;
			//Console.WriteLine($"*** Krok {i} ***");
			//Console.WriteLine($"(a,ap) = ({a},{ap})");
			//Console.WriteLine($"(u,up,v,vp) = ({u},{up},{v},{vp})");
			//Console.WriteLine();
		} while (ap != 0);
		return (long)u;
	}
	public static long CalcueteD(long e, long fi)
	{
		
		int a, ap, u, up, v, vp, q;
		a = (int)fi;
		ap = (int)e;
		u = 0;
		up = 1;
		v = 1;
		vp = 0;
		int x; //schowek
			   //Console.WriteLine($"*** Krok {i} ***");     // testowanie konkretnych kroków iteracyjnych
			   //Console.WriteLine($"(a,ap) = ({a},{ap})");
			   //Console.WriteLine($"(u,up,v,vp) = ({u},{up},{v},{vp})");
		do
		{
			q = a / ap;
			x = ap;
			ap = a - q * ap;
			a = x;
			x = up;
			up = u - q * up;
			u = x;
			x = vp;
			vp = v - q * vp;
			v = x;
			//i++;
			//Console.WriteLine($"*** Krok {i} ***");
			//Console.WriteLine($"(a,ap) = ({a},{ap})");
			//Console.WriteLine($"(u,up,v,vp) = ({u},{up},{v},{vp})");
			//Console.WriteLine();
		} while (ap != 0);
		return (long)u;
	}
}
