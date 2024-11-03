using System;
using System.Collections.Generic;
using System.Linq;

namespace Menu
{
    class Dish
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> Allergens { get; set; }
        public int Calories { get; set; }
        public int EnergyValue { get; set; }
        public List<string> Variations { get; set; }

        public Dish(string name, string description, double price, List<string> ingredients, List<string> allergens, int calories, int energyValue, List<string> variations)
        {
            Name = name;
            Description = description;
            Price = price;
            Ingredients = ingredients;
            Allergens = allergens;
            Calories = calories;
            EnergyValue = energyValue;
            Variations = variations;
        }
    }

    class Program
    {
        static List<Dish> menu = new List<Dish>()
        {
            new Dish("Цезарь с курицей", "Салат с курицей, пармезаном и крутонами.", 220,
                new List<string> { "Куриное филе", "Салат Романо", "Пармезан", "Крутоны", "Соус Цезарь" },
                new List<string> { "Молоко", "Глютен" }, 350, 150, new List<string> { "Обычный", "С острыми соусами" }),
            new Dish("Паста альфредо", "Макароны в сливочном соусе с пармезаном.", 250,
                new List<string> { "Паста", "Сливки", "Пармезан", "Чеснок" },
                new List<string> { "Молоко" }, 600, 300, new List<string> { "Обычная", "С курицей", "Вегетарианская" }),
            new Dish("Куриный шницель", "Хрустящий шницель из куриного филе.", 180,
                new List<string> { "Куриное филе", "Панировка", "Специи" },
                new List<string> { "Глютен" }, 400, 200, new List<string> { "Обычный" }),
            new Dish("Шаурма", "Лаваш с мясом, овощами и соусом.", 150,
                new List<string> { "Лаваш", "Курица", "Овощи", "Соус" },
                new List<string> { "Глютен", "Молоко" }, 500, 250, new List<string> { "С острым соусом" }),
            new Dish("Суп-пюре из брокколи", "Легкий суп из брокколи с сливками.", 130,
                new List<string> { "Брокколи", "Сливки", "Лук", "Чеснок" },
                new List<string> { "Молоко" }, 250, 120, new List<string> { "Обычный" }),
            new Dish("Торт Наполеон", "Слоеный торт с кремом.", 160,
                new List<string> { "Тесто", "Крем", "Сахар" },
                new List<string> { "Глютен", "Молоко" }, 450, 230, new List<string> { "Классический" }),
            new Dish("Смузи из ягод", "Освежающий смузи с ягодами.", 120,
                new List<string> { "Ягоды", "Йогурт", "Мед" },
                new List<string> { "Молоко" }, 200, 100, new List<string> { "С бананом", "С клубникой" }),
            new Dish("Пицца Маргарита", "Классическая пицца с томатами и моцареллой.", 300,
                new List<string> { "Тесто", "Томатный соус", "Моцарелла", "Базилик" },
                new List<string> { "Глютен", "Молоко" }, 700, 350, new List<string> { "Обычная", "С острыми специями" }),
            new Dish("Коктейль Мохито", "Освежающий коктейль с мятой и лаймом.", 100,
                new List<string> { "Мята", "Лайм", "Сахар", "Газировка" },
                new List<string> { "Нет" }, 80, 40, new List<string> { "Безалкогольный", "С ромом" }),
            new Dish("Кофе латте", "Классический латте с молоком.", 150,
                new List<string> { "Эспрессо", "Молоко", "Крем" },
                new List<string> { "Молоко" }, 100, 50, new List<string> { "Обычный" }),
        };

        static void Main(string[] args)
        {
            List<Dish> filteredMenu = new List<Dish>(menu);
            while (true)
            {
                Console.WriteLine("----- Меню -----");
                PrintMenu(filteredMenu);

                Console.WriteLine("\nФильтры:");
                Console.WriteLine("1. По цене");
                Console.WriteLine("2. По продуктам");
                Console.WriteLine("3. По аллергии");
                Console.WriteLine("4. По калориям/энергетической ценности");
                Console.WriteLine("5. Сбросить фильтры");
                Console.WriteLine("6. Показать блюда до заданной цены");
                Console.WriteLine("7. По варианту");
                Console.WriteLine("8. Выход");

                int choice = GetIntInput("Введите номер фильтра: ");

                switch (choice)
                {
                    case 1:
                        filteredMenu = FilterByPrice(menu);
                        break;
                    case 2:
                        filteredMenu = FilterByIngredients(menu);
                        break;
                    case 3:
                        filteredMenu = FilterByAllergens(menu);
                        break;
                    case 4:
                        filteredMenu = FilterByCaloriesOrEnergy(menu);
                        break;
                    case 5:
                        filteredMenu = new List<Dish>(menu);
                        break;
                    case 6:
                        ShowDishesUnderPrice(menu);
                        break;
                    case 7:
                        filteredMenu = FilterByVariants(menu);
                        break;
                    case 8:
                        Console.WriteLine("До свидания!");
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод.");
                        break;
                }
            }
        }

        static List<Dish> FilterByVariants(List<Dish> dishes)
        {
            Console.WriteLine("Выберите вариант блюда");
            string inputVariant = Console.ReadLine();
            List<string> variations = inputVariant.Split(',').Select(s => s.Trim()).ToList();

            return dishes.Where(d => d.Variations.Any(i => variations.Contains(i))).ToList();
        }

        static void PrintMenu(List<Dish> dishes)
        {
            if (dishes.Count == 0)
            {
                Console.WriteLine("Блюда не найдены.");
                return;
            }

            foreach (Dish dish in dishes)
            {
                Console.WriteLine($"\n{dish.Name} ({dish.Price} руб.)");
                Console.WriteLine($"{dish.Description}");
                Console.WriteLine($"Ингредиенты: {string.Join(", ", dish.Ingredients)}");
                Console.WriteLine($"Аллергены: {string.Join(", ", dish.Allergens)}");
                Console.WriteLine($"Калории: {dish.Calories}");
                Console.WriteLine($"Энергетическая ценность: {dish.EnergyValue} ккал");
                if (dish.Variations.Count > 0)
                {
                    Console.WriteLine($"Варианты: {string.Join(", ", dish.Variations)}");
                }
            }
        }

        static List<Dish> FilterByPrice(List<Dish> dishes)
        {
            double minPrice = GetDoubleInput("Введите минимальную цену: ");
            double maxPrice = GetDoubleInput("Введите максимальную цену: ");

            return dishes.Where(d => d.Price >= minPrice && d.Price <= maxPrice).ToList();
        }

        static List<Dish> FilterByIngredients(List<Dish> dishes)
        {
            Console.WriteLine("Введите ингредиенты (через запятую):");
            string inputIngredients = Console.ReadLine();
            List<string> ingredients = inputIngredients.Split(',').Select(s => s.Trim()).ToList();

            return dishes.Where(d => d.Ingredients.Any(i => ingredients.Contains(i))).ToList();
        }

        static List<Dish> FilterByAllergens(List<Dish> dishes)
        {
            Console.WriteLine("Введите аллергены (через запятую):");
            string inputAllergens = Console.ReadLine();
            List<string> allergens = inputAllergens.Split(',').Select(s => s.Trim()).ToList();

            return dishes.Where(d => d.Allergens.Any(a => allergens.Contains(a))).ToList();
        }

        static List<Dish> FilterByCaloriesOrEnergy(List<Dish> dishes)
        {
            Console.WriteLine("Выберите фильтр:");
            Console.WriteLine("1. По калориям");
            Console.WriteLine("2. По энергетической ценности");
            int filterChoice = GetIntInput("Введите номер фильтра: ");

            if (filterChoice == 1)
            {
                int maxCalories = GetIntInput("Введите максимальное количество калорий: ");
                return dishes.Where(d => d.Calories <= maxCalories).ToList();
            }
            else if (filterChoice == 2)
            {
                int maxEnergyValue = GetIntInput("Введите максимальное значение энергетической ценности: ");
                return dishes.Where(d => d.EnergyValue <= maxEnergyValue).ToList();
            }
            else
            {
                Console.WriteLine("Некорректный выбор.");
                return new List<Dish>(dishes);
            }
        }

        static void ShowDishesUnderPrice(List<Dish> dishes)
        {
            double priceLimit = GetDoubleInput("Введите максимальную цену: ");
            var filteredDishes = dishes.Where(d => d.Price < priceLimit).ToList();

            if (filteredDishes.Count > 0)
            {
                Console.WriteLine("Блюда до заданной цены:");
                foreach (var dish in filteredDishes)
                {
                    Console.WriteLine($"{dish.Name} - {dish.Price} руб.");
                }
            }
            else
            {
                Console.WriteLine("Блюд до заданной цены не найдено.");
            }
        }

        static int GetIntInput(string message)
        {
            Console.Write(message);
            int result; 
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
            }
            return result; 
        }

        static double GetDoubleInput(string message)
        {
            Console.Write(message);
            double result; 
            while (!double.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
            }
            return result;
        }
    }
}
