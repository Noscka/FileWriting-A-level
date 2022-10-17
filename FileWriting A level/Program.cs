using System;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Runtime.Serialization;
using System.Net;

namespace FileWriting_A_level
{
	[Serializable]
	class Address
	{
		public string UserName;
		public string UserPhoneNumber;
		public string UserAddress;

		public Address(string userName, string userPhoneNumber, string userAddress)
		{
			UserName = userName;
			UserPhoneNumber = userPhoneNumber;
			UserAddress = userAddress;
		}

		public Address() { }

		public string toString()
		{
			return $"Name: {this.UserName}, Phone Number: {this.UserPhoneNumber}, Address: {this.UserAddress}\n";
		}
	}
	class AddressBook
	{
		static Address[] OPPsAddresses;
		string FileLocation;
		FileStream FileHandle;
		BinaryFormatter formatter;

		public AddressBook(string Location)
		{
			FileLocation = Location;
			FileHandle = new FileStream("Address.txt", FileMode.OpenOrCreate);
			formatter = new BinaryFormatter();

			OPPsAddresses = (Address[])formatter.Deserialize(FileHandle);
			FileHandle.Position = 0;
		}

		public void AskUser()
		{
			string UserInput;
			Console.Write("enter data in the following format without the []\n");
			Console.Write("[Name], [Phone number], [Address]: ");
			UserInput = Console.ReadLine();

			string[] SplitList = UserInput.Split(',');

			Address Basic = new Address(SplitList[0], SplitList[1], SplitList[3]);
			formatter.Serialize(FileHandle, Basic);

			FileHandle.Position = 0;
		}

		public string ReturnList()
		{
			OPPsAddresses = (Address[])formatter.Deserialize(FileHandle);
			FileHandle.Position = 0;

			string output = "";

			foreach (Address address in OPPsAddresses)
			{
				output += $"{address.ToString()}\n";
			}

			return output;
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

				Console.Write("would you like to quit(y/n) or (q) for displaying array: \n");
				switch (Console.ReadKey().KeyChar)
				{
					case 'y':
					return;
						break;

					case 'q':
						Console.Write();
						break;
				}
				if (Console.ReadKey().KeyChar == 'y')
				{
				}
				
			}
		}
	}
}
