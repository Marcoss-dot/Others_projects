using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Szyfrowanie
{
	public partial class Szyfruj : UserControl
	{
		public Szyfruj()
		{

			InitializeComponent();

		}

		public RSAParameters MyParameters { get; set; }

		private void button_Code_Click(object sender, EventArgs e)
		{
			RSACryptoServiceProvider RSA1 = new RSACryptoServiceProvider();


			string message = textBox_ToCode.Text;

			char[] dataASCII = message.ToCharArray(0, message.Length);
			int i = 0;
			byte[] data = new byte[message.Length];

			foreach (var item in dataASCII)
			{
				data[i] = Convert.ToByte((int)item);
				i++;
			}

			byte[] EncryptedASCII = RSA1.Encrypt(data, true); // szyfrowanie kodu ASCII
			i = 0;
			char[] encrypted = new char[EncryptedASCII.Length];
			foreach (var item in EncryptedASCII)
			{
				encrypted[i] = (char)item;
				//encrypted[i] = (char)(item+3);  // dodatkowe działanie + szyfr cezara
				i++;
			}
			string enMessage = string.Join("", encrypted);
			textBox_Coded.Text = enMessage;

			MyParameters = RSA1.ExportParameters(true);

			textBox_e.Text = "e = " + BitConverter.ToString(MyParameters.Exponent, 0);
			textBox_p.Text = "n = " + BitConverter.ToString(MyParameters.Modulus, 0);
		}
		private void button_ExportParameters_Click(object sender, EventArgs e)
		{
			Stream myStream;
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();

			saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
			saveFileDialog1.RestoreDirectory = true;

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				using (myStream = saveFileDialog1.OpenFile())
				using (var writer = new StreamWriter(myStream))
				{
					writer.WriteLine("d = " + BitConverter.ToString(MyParameters.D, 0));
					writer.WriteLine("d mod (p-1) = " + BitConverter.ToString(MyParameters.DP, 0));
					writer.WriteLine("d mod (q-1) = " + BitConverter.ToString(MyParameters.DQ, 0));
					writer.WriteLine("e = " + BitConverter.ToString(MyParameters.Exponent, 0));
					writer.WriteLine("#(InverseQ) (q) równa się 1 Mod p # InverseQ = " 
						+ BitConverter.ToString(MyParameters.InverseQ, 0));
					writer.WriteLine("n = " + BitConverter.ToString(MyParameters.Modulus, 0));
					writer.WriteLine("p = " + BitConverter.ToString(MyParameters.P, 0));
					writer.WriteLine("q = " + BitConverter.ToString(MyParameters.Q, 0));
				}
				myStream.Close();
			}
		}

		private void button_odszyfruj_Click(object sender, EventArgs e)
		{
			RSACryptoServiceProvider RSA2 = new RSACryptoServiceProvider();
			RSA2.ImportParameters(MyParameters); // import z wczesniej eksportowanego do własności
												 // wszystkich parametrów szyfrowania 

			string encryptedMessage = textBox_Coded.Text;

			char[] dataASCII = encryptedMessage.ToCharArray(0, encryptedMessage.Length);
			int i = 0;
			byte[] data = new byte[encryptedMessage.Length];

			foreach (var item in dataASCII)
			{
				data[i] = Convert.ToByte((int)item);
				//data[i] = Convert.ToByte((int)item)-3);
				i++;
			}

			byte[] descryptedASCII = RSA2.Decrypt(data, true);
			i = 0;
			char[] descrypted = new char[descryptedASCII.Length];
			foreach (var item in descryptedASCII)
			{
				descrypted[i] = (char)item;
				i++;
			}
			string desMessage = string.Join("", descrypted);

			textBox_messageReturned.Text = desMessage;
		}

		private void button_Zapisz_Click(object sender, EventArgs e)
		{
			Stream myStream;
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();

			saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
			saveFileDialog1.RestoreDirectory = true;

			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				using (myStream = saveFileDialog1.OpenFile())
				using (var writer = new StreamWriter(myStream))
				{
					writer.WriteLine(textBox_Coded.Text);
				}

				myStream.Close();
			}

		}

		private void button_Wczytaj_Click(object sender, EventArgs e)
		{
			// tu bedzie wczytywanie z pliku

			var fileContent = string.Empty;
			var filePath = string.Empty;

			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = "c:\\";
				openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					filePath = openFileDialog.FileName;
					var fileStream = openFileDialog.OpenFile();

					using (StreamReader reader = new StreamReader(fileStream))
					{
						fileContent = reader.ReadToEnd();
						textBox_Coded.Text = fileContent;
					}
				}
			}
		}

		private int CharToInt(char sign)
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

		private byte String2toHex(string text2)
		{
			byte onebyte;
			int x, y;
			x = CharToInt(text2[0]);
			y = CharToInt(text2[1]);
			x = 16 * x + y;
			onebyte = (byte)x;
			return onebyte;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			var fileContent = string.Empty;
			var filePath = string.Empty;

			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.InitialDirectory = "c:\\";
				openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
				openFileDialog.FilterIndex = 2;
				openFileDialog.RestoreDirectory = true;

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					//Get the path of specified file
					filePath = openFileDialog.FileName;

					//Read the contents of the file into a stream
					var fileStream = openFileDialog.OpenFile();

					using (StreamReader reader = new StreamReader(fileStream))
					{
						
						fileContent = reader.ReadLine();
						fileContent = fileContent.Remove(0, fileContent.IndexOf('=') + 2);
						string[] splitD = fileContent.Split(new Char[] { '-' });
						byte[] byteD = Retype(splitD);

						fileContent = reader.ReadLine();
						fileContent = fileContent.Remove(0, fileContent.IndexOf('=') + 2);
						string[] splitDP = fileContent.Split(new Char[] { '-' });
						byte[] byteDP = Retype(splitDP);

						fileContent = reader.ReadLine();
						fileContent = fileContent.Remove(0, fileContent.IndexOf('=') + 2);
						string[] splitDQ = fileContent.Split(new Char[] { '-' });
						byte[] byteDQ = Retype(splitDQ);

						fileContent = reader.ReadLine();
						fileContent = fileContent.Remove(0, fileContent.IndexOf('=') + 2);
						string[] splitE = fileContent.Split(new Char[] { '-' });
						byte[] byteE = Retype(splitE);

						fileContent = reader.ReadLine();
						fileContent = fileContent.Remove(0, fileContent.IndexOf('=') + 2);
						string[] splitIn = fileContent.Split(new Char[] { '-' });
						byte[] byteIn = Retype(splitIn);

						fileContent = reader.ReadLine();
						fileContent = fileContent.Remove(0, fileContent.IndexOf('=') + 2);
						string[] splitN = fileContent.Split(new Char[] { '-' });
						byte[] byteN = Retype(splitN);

						fileContent = reader.ReadLine();
						fileContent = fileContent.Remove(0, fileContent.IndexOf('=') + 2);
						string[] splitP = fileContent.Split(new Char[] { '-' });
						byte[] byteP = Retype(splitP);

						fileContent = reader.ReadLine();
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

						RSACryptoServiceProvider RSA3 = new RSACryptoServiceProvider();
						RSA3.ImportParameters(exportedParameters);
						MyParameters = RSA3.ExportParameters(true);
					}
				}
			}
		}

		public byte[] Retype(string[] arrayText2)
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


	}
}