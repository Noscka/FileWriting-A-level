using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace FileWriting_A_level
{
	class AddressBook
	{
		string FileLocation;
		FileStream FileHandle;

		public AddressBook(string Location)
		{
			FileLocation = Location;
			FileHandle = new FileStream("Address.txt", FileMode.Append);
		}

		public void AskUser()
		{
			string UserInput;
			Console.Write("enter data in the following format without the []\n");
			Console.Write("[Name], [Phone number]: ");
			UserInput = Console.ReadLine();

			byte[] bytes = Encoding.UTF8.GetBytes((UserInput + "\n"));
			FileHandle.Write(bytes, 0, bytes.Length);
		}
	}

	internal class Program
	{
		static void Main(string[] args)
		{
			AddressBook Main = new AddressBook("Address.txt");
			while (true)
			{
				Main.AskUser();

				Console.Write("would you like to quit(y/n): \n");
				if (Console.ReadKey().KeyChar == 'y')
				{
					return;
				}
			}
		}
	}
}
