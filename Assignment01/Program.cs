using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment01
{

    public class Program
    {
        private static List<Appliance> appliances = new List<Appliance>();

        static void Main(string[] args)
        {
            LoadAppliances();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to Modern Appliances!");
                Console.WriteLine("How may we assist you?");
                Console.WriteLine("1 - Check out appliance");
                Console.WriteLine("2 - Find appliances by brand");
                Console.WriteLine("3 - Display appliances by type");
                Console.WriteLine("4 - Produce random appliance list");
                Console.WriteLine("5 - Save & exit");
                Console.Write("Enter option: ");

                string option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        CheckoutAppliance();
                        break;
                    case "2":
                        FindAppliancesByBrand();
                        break;
                    case "3":
                        DisplayAppliancesByType();
                        break;
                    case "4":
                        ProduceRandomApplianceList();
                        break;
                    case "5":
                        SaveAndExit();
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void LoadAppliances()
        {
            try
            {
                string[] lines = File.ReadAllLines("appliances.txt");

                foreach (string line in lines)
                {
                    string[] data = line.Split(';');
                    string itemNumber = data[0];

                    if (data[1] == "Refrigerator")
                    {
                        int numberOfDoors = int.Parse(data[2]);
                        int height = int.Parse(data[9]);
                        int width = int.Parse(data[10]);

                        appliances.Add(new Refrigrator
                        {
                            ItemNumber = itemNumber,
                            Brand = data[3],
                            Quantity = int.Parse(data[4]),
                            Wattage = int.Parse(data[5]),
                            Color = data[6],
                            Price = decimal.Parse(data[7]),
                            NumberOfDoors = numberOfDoors,
                            Height = height,
                            Width = width
                        });
                    }
                    else if (data[1] == "Vacuum")
                    {
                        int batteryVoltage = int.Parse(data[11]);

                        appliances.Add(new Vacuum
                        {
                            ItemNumber = itemNumber,
                            Brand = data[3],
                            Quantity = int.Parse(data[4]),
                            Wattage = int.Parse(data[5]),
                            Color = data[6],
                            Price = decimal.Parse(data[7]),
                            Grade = data[12],
                            BatteryVoltage = batteryVoltage
                        });
                    }
                    else if (data[1] == "Microwave")
                    {
                        decimal capacity = decimal.Parse(data[8]);
                        char roomType = char.Parse(data[11]);

                        appliances.Add(new Microwave
                        {
                            ItemNumber = itemNumber,
                            Brand = data[3],
                            Quantity = int.Parse(data[4]),
                            Wattage = int.Parse(data[5]),
                            Color = data[6],
                            Price = decimal.Parse(data[7]),
                            Capacity = capacity,
                            RoomType = roomType
                        });
                    }
                    else if (data[1] == "Dishwasher")
                    {
                        appliances.Add(new Dishwasher
                        {
                            ItemNumber = itemNumber,
                            Brand = data[3],
                            Quantity = int.Parse(data[4]),
                            Wattage = int.Parse(data[5]),
                            Color = data[6],
                            Price = decimal.Parse(data[7]),
                            Feature = data[13],
                            SoundRating = data[14]
                        });
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Appliances file not found. Please make sure the file exists.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading appliances: " + ex.Message);
            }
        }

        private static void CheckoutAppliance()
        {
            Console.Write("Enter the item number of an appliance: ");
            string itemNumber = Console.ReadLine();

            Appliance appliance = appliances.Find(a => a.ItemNumber == itemNumber);
            if (appliance != null)
            {
                Console.WriteLine($"Appliance \"{itemNumber}\" has been checked out.");
                appliances.Remove(appliance);
            }
            else
            {
                Console.WriteLine("The appliance is not available to be checked out.");
            }
        }

        private static void FindAppliancesByBrand()
        {
            Console.Write("Enter brand to search for: ");
            string brand = Console.ReadLine();

            List<Appliance> matchingAppliances = appliances.FindAll(a => a.Brand == brand);
            Console.WriteLine("Matching Appliances:");
            foreach (Appliance appliance in matchingAppliances)
            {
                Console.WriteLine(appliance.ToString());
            }
        }

        private static void DisplayAppliancesByType()
        {
            Console.WriteLine("Appliance Types");
            Console.WriteLine("1 - Refrigerators");
            Console.WriteLine("2 - Vacuums");
            Console.WriteLine("3 - Microwaves");
            Console.WriteLine("4 - Dishwashers");
            Console.Write("Enter type of appliance: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    DisplayAppliancesByType<Refrigrator>();
                    break;
                case "2":
                    DisplayAppliancesByType<Vacuum>();
                    break;
                case "3":
                    DisplayAppliancesByType<Microwave>();
                    break;
                case "4":
                    DisplayAppliancesByType<Dishwasher>();
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        private static void DisplayAppliancesByType<T>() where T : Appliance
        {
            Console.WriteLine($"Appliances of type {typeof(T).Name}:");
            List<Appliance> matchingAppliances = appliances.FindAll(a => a.GetType() == typeof(T));
            foreach (Appliance appliance in matchingAppliances)
            {
                Console.WriteLine(appliance.ToString());
            }
        }

        private static void ProduceRandomApplianceList()
        {
            // Code for generating random appliance list goes here
            Console.WriteLine("Produce Random Appliance List");
        }

        private static void SaveAndExit()
        {
            // Code for saving data and exiting goes here
            Console.WriteLine("Save and Exit");
        }
    }
}
