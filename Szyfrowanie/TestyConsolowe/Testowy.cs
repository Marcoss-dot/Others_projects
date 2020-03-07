using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace TestyConsolowe
{
	class Testowy
	{
		static void Main(string[] args)
		{

	
			byte[] bajt = new byte[2];
			bajt[0] = 162;
			bajt[1] = 177;
			Console.WriteLine(BitConverter.ToString(bajt));

			Console.WriteLine(String2toHex("A2"));
			Console.WriteLine(String2toHex("B1"));
			Console.WriteLine(String2toHex("02"));

			string fileContent = "d = AB-CD";
			fileContent = fileContent.Remove(0, fileContent.IndexOf('=') + 2);
			Console.WriteLine(fileContent);

			fileContent = "d = 2F-B4-62-95-28-40-B3-7B-AE-41-BA-96-16-7E-E9-49-C3-0C-1C-91-EE-72-6C-2F-39-C1-F0-2E-42-C6-F5-A1-D9-8A-58-81-CA-C4-BD-0F-8E-FE-B5-F0-20-63-77-B9-6D-2F-2C-AA-8F-51-13-59-85-F6-FD-0A-40-61-8F-B4-36-C9-2D-D9-D9-CD-08-BB-9B-8B-F8-A9-CC-98-C2-06-3A-FE-02-93-FC-65-86-44-00-21-AC-43-AB-47-9E-6B-DB-7B-74-88-2E-E0-76-3B-84-F6-CD-E3-CD-6D-4E-8F-B7-A5-53-97-9A-7C-67-FC-A2-0D-EA-C1-DB-2B-67-F1";
			fileContent = fileContent.Remove(0, fileContent.IndexOf('=') + 2);
			string[] splitD = fileContent.Split(new Char[] { '-' });
			byte[] byteD = Retype(splitD);

			fileContent = "d mod (p-1) = 7A-7E-71-4D-36-58-78-19-F2-A7-91-FE-65-B9-75-DF-78-3C-FB-60-FB-9F-7B-3F-D1-C0-25-14-FD-15-8A-7D-AA-0A-45-AB-86-D5-CD-2C-00-67-E8-9D-BB-11-58-9C-87-DD-58-87-5D-68-3A-EB-77-3C-9D-DF-71-75-E8-EB";
			fileContent = fileContent.Remove(0, fileContent.IndexOf('=') + 2);
			string[] splitDP = fileContent.Split(new Char[] { '-' });
			byte[] byteDP = Retype(splitDP);

			fileContent = "d mod (q-1) = 51-6B-A5-7F-EB-A2-3C-32-E8-E4-33-75-EB-2D-46-76-16-B3-9B-C7-99-3D-41-3B-24-D6-CA-EA-15-6F-4E-76-FE-40-49-EE-8F-E1-C5-80-33-46-B6-29-B0-82-09-16-76-33-87-B8-AE-D4-5F-B1-DA-DF-4D-20-1D-1B-0C-4B";
			fileContent = fileContent.Remove(0, fileContent.IndexOf('=') + 2);
			string[] splitDQ = fileContent.Split(new Char[] { '-' });
			byte[] byteDQ = Retype(splitDQ);

			fileContent = "e = 01-00-01";
			fileContent = fileContent.Remove(0, fileContent.IndexOf('=') + 2);
			string[] splitE = fileContent.Split(new Char[] { '-' });
			byte[] byteE = Retype(splitE);

			fileContent = "#(InverseQ) (q) równa się 1 Mod p# InverseQ = CF-21-EB-4E-E1-21-91-11-FC-67-6A-7F-72-8F-EC-91-FD-44-11-4B-19-CA-F8-AB-52-C9-D6-45-B9-F2-6F-F1-70-9C-54-E0-17-5E-FF-C9-AE-FE-11-B8-21-91-F5-22-19-B5-69-06-FA-E8-E2-37-8A-93-AA-85-AF-11-8C-69";
			fileContent = fileContent.Remove(0, fileContent.IndexOf('=') + 2);
			string[] splitIn = fileContent.Split(new Char[] { '-' });
			byte[] byteIn = Retype(splitIn);

			fileContent = "n = F3-90-FF-78-EA-A8-3D-D5-6F-3C-3F-56-94-00-F3-F7-A1-57-FC-21-B9-B9-87-E4-09-98-A6-41-A2-72-90-E3-80-EB-DB-8B-97-C8-A1-DE-E4-EB-EA-47-20-61-7C-F2-4B-F5-58-D3-2A-6E-F0-F9-67-A3-85-2B-95-F9-75-CA-B7-4B-30-3D-49-61-44-80-F7-B5-33-9A-4F-54-05-FA-CE-28-44-EE-A6-37-05-73-E1-A6-92-BC-FC-69-34-67-1E-8F-27-74-A1-CD-9A-2B-3C-BD-26-54-57-03-5C-83-22-FE-3A-0C-F3-0E-05-6D-A4-31-2F-E9-44-D9-C0-FD";
			fileContent = fileContent.Remove(0, fileContent.IndexOf('=') + 2);
			string[] splitN = fileContent.Split(new Char[] { '-' });
			byte[] byteN = Retype(splitN);

			fileContent = "p = F8-94-6C-0E-9D-4C-A2-13-C2-87-E3-72-6C-43-C9-B1-2C-F0-F9-B6-B3-22-E4-AF-AB-26-61-7E-89-EE-C3-74-AE-3B-B8-19-E8-C0-C0-4A-2D-43-13-EA-E1-52-CB-4F-0B-0A-8D-C9-5D-FC-7F-B7-57-D2-B2-D0-E6-9E-EC-07";
			fileContent = fileContent.Remove(0, fileContent.IndexOf('=') + 2);
			string[] splitP = fileContent.Split(new Char[] { '-' });
			byte[] byteP = Retype(splitP);

			fileContent = "q = FA-D6-43-D7-B9-44-0C-EA-0D-0E-EA-16-64-16-E2-66-91-6A-66-10-29-74-9A-79-41-79-F6-43-52-95-0D-65-C1-A1-88-F8-36-34-8E-A6-AE-43-87-3B-34-17-8E-CA-2F-F1-88-BE-CB-50-D0-99-C7-17-CA-8F-D5-63-B1-DB";
			fileContent = fileContent.Remove(0, fileContent.IndexOf('=') + 2);
			string[] splitQ = fileContent.Split(new Char[] { '-' });
			byte[] byteQ = Retype(splitQ);



			RSAParameters exportedParameters = new RSAParameters();
			exportedParameters.D = byteD;
			exportedParameters.DP = byteDP;
			exportedParameters.DQ = byteDQ;
			exportedParameters.Exponent = byteE;
			exportedParameters.InverseQ = byteIn;
			exportedParameters.Modulus = byteN;
			exportedParameters.P = byteP;
			exportedParameters.Q = byteQ;

			Console.WriteLine(BitConverter.ToString(exportedParameters.D, 0));
			Console.WriteLine(BitConverter.ToString(exportedParameters.DP, 0));
			Console.WriteLine(BitConverter.ToString(exportedParameters.DQ, 0));
			Console.WriteLine(BitConverter.ToString(exportedParameters.Exponent, 0));
			Console.WriteLine(BitConverter.ToString(exportedParameters.InverseQ, 0));
			Console.WriteLine(BitConverter.ToString(exportedParameters.Modulus, 0));
			Console.WriteLine(BitConverter.ToString(exportedParameters.P, 0));
			Console.WriteLine(BitConverter.ToString(exportedParameters.Q, 0));

			RSACryptoServiceProvider RSA3 = new RSACryptoServiceProvider();
			RSA3.ImportParameters(exportedParameters);
		}




		public static byte[] Retype(string[] arrayText2)
		{
			int i = 0;
			byte[] bytes = new byte[arrayText2.Length];
			foreach (var item in arrayText2)
			{
				bytes[i] = String2toHex(item);
				i++;
			}
			return bytes;
		}






		/*double p = 17;
	   double q = 11;
	   double n = p * q;
	   double fi = (p - 1) * (q - 1);
	   double e, d, x, i = 0;
	   double m1 = 11;
	   double m2 = 22;
	   double m3 = 53;
	   double m4 = 99;
	   int licznik = 0;
	   double mb1, mb2, mb3, mb4;
	   do
	   {
		   do
		   {
			   i++;
			   Console.WriteLine($"** krok {i} **");
			   e = (double)Euclides((int)fi);
			   Console.WriteLine($"e= {e}");
			   d = obliczD(e, fi);
			   x = (e * d) % fi;
		   } while (x != 1);




		   //double d = Math.Pow(e,-1) % fi;
		   Console.WriteLine($"e = {e}");
		   Console.WriteLine($"fi = {fi}");
		   Console.WriteLine($"d = {d}");
		   Console.WriteLine($"n = {n}");
		   Console.WriteLine($"x = {x}");
		   Console.ReadLine();
		   double c1 = RSAcode(m1, e, n);
		   double c2 = RSAcode(m2, e, n);
		   double c3 = RSAcode(m3, e, n);
		   double c4 = RSAcode(m4, e, n);

		   mb1 = RSAcodeBack(c1, d, n);
		   mb2 = RSAcodeBack(c2, d, n);
		   mb3 = RSAcodeBack(c3, d, n);
		   mb4 = RSAcodeBack(c4, d, n);

		   Console.WriteLine($"zaszyfrowane c1 = {c1}");
		   Console.WriteLine($"zaszyfrowane c2 = {c2}");
		   Console.WriteLine($"zaszyfrowane c3 = {c3}");
		   Console.WriteLine($"zaszyfrowane c4 = {c4}");

		   Console.WriteLine($"Odszyfrowane mBack1 = {mb1}");
		   Console.WriteLine($"Odszyfrowane mBack2 = {mb2}");
		   Console.WriteLine($"Odszyfrowane mBack3 = {mb3}");
		   Console.WriteLine($"Odszyfrowane mBack4 = {mb4}");
		   Console.WriteLine($" ++ Iteracja nr : {licznik} ++");
		   licznik++;
	   } while(mb1 != m1 || mb2!= m2 || mb3 != m3 || mb4 !=m4);
	   */


		//Console.WriteLine(Code(m1.ToString()));
		//Console.WriteLine(Code(m2.ToString()));
		//Console.WriteLine(Code(m3.ToString()));
		//Console.WriteLine(Code(m4.ToString()));

		//Console.WriteLine(Code(m1.ToString()));

		//string message = Console.ReadLine();
		//char[] toCode = new char[message.Length];
		//toCode = message.ToCharArray(0, message.Length);
		//int[] toCodeAsci = new int[message.Length];
		//char[] Coded = new char[message.Length];
		//int i = 0;
		//foreach (var item in toCode)
		//{
		//	toCodeAsci[i] = (int)item;
		//	i++;
		//}

		//i = 0;
		//foreach (var item in toCodeAsci)
		//{
		//	Coded[i] = (char)RSAcode(item, 5, 21);
		//	i++;
		//}
		//string codedMessage;
		//codedMessage = String.Join("", Coded);


		//Console.WriteLine(codedMessage);
		//Console.WriteLine(CodeBack(codedMessage, 5, 3, 7));
		//}

		private static int CharToInt(char sign)
		{
			int x;
			switch (sign)
			{
				case 'A':
					x = 10;
					break;
				case 'B':
					x = 11;
					break;
				case 'C':
					x = 12;
					break;
				case 'D':
					x = 13;
					break;
				case 'E':
					x = 14;
					break;
				case 'F':
					x = 15;
					break;
				default:
					x = int.Parse(sign.ToString());
					break;
			}
			return x;
		}

		private static byte String2toHex(string text2)
		{
			byte onebyte;
			int x, y;
			x = CharToInt(text2[0]);
			y = CharToInt(text2[1]);
			x = 16 * x + y;
			onebyte = (byte)x;
			return onebyte;
		}


		public static List<int> CreateList() // tworzy liste liczb pierwszych
		{
			DateTime start = DateTime.Now;
			List<int> primeList = new List<int>();
			for (int i = 1000; i < 10000; i++)
			{
				bool pierwsza = true;
				for (int n = 2; n < i; n++)
				{
					if (i % n == 0)
					{
						pierwsza = false;
						break;
					}
				}
				if (pierwsza)
				{
					primeList.Add(i);
				}
			}
			DateTime stop = DateTime.Now;
			int timeMinutes = stop.Minute - start.Minute;
			int timeSeconds = stop.Second - start.Second;
			timeSeconds += 60 * timeMinutes;
			//Console.WriteLine($"Czas oczekiwania trwał {timeMinutes} minut i {timeSeconds} sekund");

			return primeList;
		}
		public static int[] GeneratePublicKey(List<int> primeList)
		{
			Random random = new Random();
			int choose = random.Next(primeList.Count);
			int p = primeList[choose];
			primeList.Remove(p);
			choose = random.Next(primeList.Count);
			int q = primeList[choose];
			primeList.Add(p);

			int fi = (p - 1) * (q - 1);
			double e = Euclides(fi);

			int n = p * q;

			int[] publicKey = { (int)e, n };
			return publicKey;
		}
		private static int Euclides(int fi)
		{
			int e;
			Random random = new Random();
			int a, b;
			a = 0;
			b = fi;
			e = 0;
			while (a != 1) // jesli NWD nie jest 1 szukaj innego e
			{
				e = random.Next(3, fi);
				a = e;

				while (a != b) // znajduje największy wspólny dzielnik
				{
					if (a > b)
						a -= b;
					else
						b -= a;
				}
			}
			return e;
		}
		public static double obliczD(double e, double fi)
		{
			int a, ap, u, up, v, vp, q;
			a = (int)fi;
			ap = (int)e;
			u = 0;
			up = 1;
			v = 1;
			vp = 0;
			int i = 0;
			int x; //schowek
			Console.WriteLine($"*** Krok {i} ***");     // testowanie konkretnych kroków iteracyjnych
			Console.WriteLine($"(a,ap) = ({a},{ap})");
			Console.WriteLine($"(u,up,v,vp) = ({u},{up},{v},{vp})");
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
				i++;
				Console.WriteLine($"*** Krok {i} ***");
				Console.WriteLine($"(a,ap) = ({a},{ap})");
				Console.WriteLine($"(u,up,v,vp) = ({u},{up},{v},{vp})");
				Console.WriteLine();
			} while (ap != 0);
			//if (u < 0)
			//{
			//	u = -u;
			//}
			return (double)u;
		}
		public static double RSAcodeBack(double ci, double d, double n) // 
		{
			double mi = Math.Pow(ci, d) % n;
			return mi;
		}
		public static double RSAcode(double mi, double e, double n)
		{
			double ci = Math.Pow(mi, e) % n;
			return ci;
		}

		public static string Code(string message)
		{
			int[] publicKey = GeneratePublicKey(CreateList()); // publicKey = {e,n}

			char[] toCode = new char[message.Length];
			toCode = message.ToCharArray(0, message.Length);
			int[] toCodeAsci = new int[message.Length];
			char[] Coded = new char[message.Length];
			int i = 0;
			foreach (var item in toCode)
			{
				toCodeAsci[i] = (int)item;
				i++;
			}

			i = 0;
			foreach (var item in toCodeAsci)
			{
				Coded[i] = (char)RSAcode((double)item, (double)publicKey[0], (double)publicKey[1]);
				i++;
			}
			string codedMessage;
			codedMessage = String.Join("", Coded);


			return codedMessage;
		}
		public static string CodeBack(string messageCoded, int e, int p, int q)
		{
			int n = p * q;
			int fi = (p - 1) * (q - 1);
			int d = (e ^ -1) % fi;

			char[] Coded = new char[messageCoded.Length];
			Coded = messageCoded.ToCharArray(0, messageCoded.Length);
			int[] toCodeAsci = new int[messageCoded.Length];
			char[] orginalMessage = new char[messageCoded.Length];
			int i = 0;
			foreach (var item in Coded)
			{
				toCodeAsci[i] = (int)item;
				i++;
			}

			i = 0;
			foreach (var item in toCodeAsci)
			{
				orginalMessage[i] = (char)RSAcodeBack((double)item, (double)d, (double)n);
				i++;
			}
			string returnedMessage = String.Join(" ", orginalMessage);

			return returnedMessage;
		}

	}
}



