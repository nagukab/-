using БиблиотекаПлощадьФигур;

Console.WriteLine($"Чтоб посчитать площадь круга введите радиус, который больше 0, чтоб выйти из цикла введите НЕ число.\n");
try
{
    while (double.TryParse(Console.ReadLine(), out double радиус))
    {
        Фигура круг = new Круг(радиус);
        Console.WriteLine($"{круг}");
    }
}
catch (Exception ex) { Console.WriteLine($"Ошибка создания круга: {ex.Message}"); }

Console.WriteLine($"Чтоб посчитать площадь треугольника введите его стороны, которые больше 0, чтоб выйти из цикла введите НЕ число.\n");
try
{
    while (double.TryParse(Console.ReadLine(), out double сторона1) && double.TryParse(Console.ReadLine(), out double сторона2) && double.TryParse(Console.ReadLine(), out double сторона3))
    {
        Фигура треугольник = new Треугольник(сторона1, сторона2, сторона3);
        Console.WriteLine($"{треугольник}");
    }
}
catch (Exception ex) { Console.WriteLine($"Ошибка создания треугольника: {ex.Message}"); }

Console.WriteLine($"Конец примера");

Console.ReadLine();