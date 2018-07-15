using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	class MainClass
	{

		static void Main(string[] args)
		{

			do
			{

				int sum = 0;
				char[] array = new char[16];
				string num;

				Console.WriteLine(" enter your card number: ");
				num = Console.ReadLine();

				int[] arr = new int[16];
				int size = num.Length;
				array = num.ToCharArray();

				string text;  //доп задание ввод даты создания карты, вывод сообщения сколько дней, мес, лет она еще годна и когда акончится срок годности
				Console.WriteLine("Input the date of creation");
				text = Console.ReadLine();
				DateTime dateOfCreation = DateTime.Parse(text);
				TimeSpan t = new TimeSpan(1827, 0, 0, 0);

				DateTime dateOf = (dateOfCreation.Add(t));
				Console.WriteLine("Your card will be invalid from " + dateOf);
				TimeSpan dat = new TimeSpan();
				Console.WriteLine("Input today's date: ");
				string text1;
				text1 = Console.ReadLine();
				DateTime dateOfCreation1 = DateTime.Parse(text1);
				DateTime dateOfCreation2 = new DateTime(1, 1, 1);

				dat = dateOf.Subtract(dateOfCreation1);
				int days = (int)dat.TotalDays - 396;

				dateOfCreation2 = dateOfCreation2.AddDays(days);
				Console.WriteLine("Your card will be invalid through " + dateOfCreation2.Day + " days " + dateOfCreation2.Month + " months " + dateOfCreation2.Year + " years ");
				

				if (size == 13 || size == 15 || size == 16)
				{
					for (int i = 0; i < size; i++)
					{

						if (array[i] >= '0' && array[i] <= '9')
						{
							arr[i] = array[i] - 48;

						}
						else break;
					}
					for (int i = 1; i <= size; i += 2)
					{
						sum += ((arr[i] * 2) % 10) + (arr[i] * 2 / 10);
					}
					Console.WriteLine(sum);
					for (int i = 0; i < size; i += 2)
					{
						sum += arr[i];
					}
					Console.WriteLine(sum);
					if (sum % 10 == 0)
					{
						if (size == 15 && arr[0] == 3 && (arr[1] == 4 || arr[1] == 7))
							Console.WriteLine("This card belongs to American Express");
						else if ((size == 13 || size == 16) && arr[0] == 4)
							Console.WriteLine("This card belongs to Visa");
						else if (size == 16 && (arr[0] == 5 && (arr[1] >= 1 && arr[1] <= 5)))
							Console.WriteLine("This card belongs to MasterCard");
					}
					else Console.WriteLine("Invalid card number");
				}

				else Console.WriteLine("Invalid card number");
			} while (true);
			Console.ReadKey();
		}

	}
}