using System.Xml.Serialization;

namespace Assignment1
{
    public class Program
    {
        static List<Car> cars = new List<Car>();

        static void Main(string[] args)
        {
            cars = GenerateCars();
            while (true)
            {
                DisplayMenu();

                string ?choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        AddCar();
                        break;
                    case "2":
                        ViewAllCars();
                        break;
                    case "3":
                        SearchByCarMake();
                        break;
                    case "4":
                        FilterByType();
                        break;
                    case "5":
                        RemoveByModel();
                        break;
                    case "6":
                        Console.WriteLine("Exitting Program");
                        return;
                    default:
                        Console.WriteLine("Invalid option!!! Try again");
                        break;
                }
            }

            static void DisplayMenu()
            {
                Console.WriteLine("\nCar Management System");
                Console.WriteLine("1. Add a car");
                Console.WriteLine("2. View all cars");
                Console.WriteLine("3. Search car by Make");
                Console.WriteLine("4. Filter car by Type");
                Console.WriteLine("5. Remove car by Model");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice (1 - 6): ");
            }

            static List<Car> GenerateCars()
            {
                List<Car> cars = new List<Car>();
                string[] makes = { "Toyota", "Tesla", "Ford", "BMW", "Honda", "Mercedes", "Nissan", "Chevrolet", "Hyundai", "Audi" };
                string[] models = { "Model S", "Corolla", "Civic", "Mustang", "X5", "A4", "Altima", "Camry", "Tucson", "Malibu" };
                Random rand = new Random();

                for (int i = 0; i < 20; i++)
                {
                    string make = makes[rand.Next(makes.Length)];
                    string model = models[rand.Next(models.Length)];
                    int year = rand.Next(2000, 2025); // Năm từ 2000 đến 2024
                    CarType type = (CarType)rand.Next(2); // 0 = Electric, 1 = Fuel

                    cars.Add(new Car(make, model, year, type));
                }

                return cars;
            }

            static void ViewAllCars()
            {
                if (cars.Count == 0)
                {
                    Console.WriteLine("No cars in the list");
                    return;

                }
                Output("List Cars: ");
                foreach (Car car in cars)
                {
                    Console.WriteLine(car);
                }
            }

            static void AddCar()
            {
                try
                {
                    string make = CheckValid.CheckNonEmptyInput("Enter Make: ");

                    string model = CheckValid.CheckNonEmptyInput("Enter Model: ");

                    Console.Write("Enter Year: ");
                    int year = CheckValid.CheckValidYear();

                    Output("Enter Type (0 for Electric, 1 for Fuel): ");
                    CarType carType = CheckValid.CheckValidType();

                    cars.Add(new Car(make, model, year, carType));
                    Output("Car added successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error adding car: {ex.Message}");
                }
                
            }

            static void SearchByCarMake()
            {
                string make = CheckValid.CheckNonEmptyInput("Enter Make to search: ");

                var result = cars.Where(carMake => carMake.Make == make).ToList();
                
                if (!result.Any())
                {
                    Console.WriteLine("No cars found!!!");
                    return;
                }
                result.ForEach(c => Console.WriteLine(result));
            }

            static void FilterByType()
            {
                Output("Enter Type to filter (Eclectric/Fuel)");
                CarType type = CheckValid.CheckValidType();
                
                var result = cars.Where(carType => carType.Type == type).ToList();
          
                foreach (Car car in result) 
                    Console.WriteLine(car);
            }

            static void RemoveByModel()
            {
                string model = CheckValid.CheckNonEmptyInput("Enter Model to Remove: ");

                var carToRemove = cars.FirstOrDefault(carModel => carModel.Model == model);

                if (carToRemove == null)
                {
                    Output("Car not Found");
                }
                else
                {
                    cars.Remove(carToRemove);
                    Output("Remove Successfull");
                }
            }

            static void Output(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
}
