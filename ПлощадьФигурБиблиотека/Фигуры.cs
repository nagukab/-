namespace БиблиотекаПлощадьФигур
{
    /// <summary>
    /// Абстрактный класс <see cref="Фигура"/>, наследники: <see cref="Треугольник"/>, <see cref="Круг"/>.
    /// </summary>
    public abstract class Фигура
    {
        /// <summary>
        /// Метод для расчета площади фигуры.
        /// </summary>
        /// <returns>Площадь фигуры.</returns>
        public abstract double Площадь();
    }

    /// <summary>
    /// <see cref="Треугольник"/> - производный класс от <see cref="Фигура"/>.
    /// </summary>
    public class Треугольник : Фигура
    {
        /// <summary>
        /// Конструктор для создания треугольника на основании трех сторон.
        /// Стороны должны быть больше нули и длина любой стороны треугольника всегда должна быть меньше суммы длин двух его других сторон.
        /// </summary>
        /// <exception cref="ArgumentException">Вызывается в случае передачи не корректных аргументов.</exception>
        public Треугольник(double сторона1, double сторона2, double сторона3)
        {
            if (сторона1 > 0 && сторона2 > 0 && сторона3 > 0)
            {
                if (сторона1 >= сторона2 + сторона3 || сторона2 >= сторона1 + сторона3 || сторона3 >= сторона1 + сторона2)
                {
                    throw new ArgumentException("Длина любой стороны треугольника всегда должна быть меньше суммы длин двух его других сторон.");
                }
                Сторона1 = сторона1; Сторона2 = сторона2; Сторона3 = сторона3;
            }
            else { throw new ArgumentException("Длинна сторон должна быть больше нуля."); }
        }
        public double Сторона1 { get; private set; }
        public double Сторона2 { get; private set; }
        public double Сторона3 { get; private set; }

        /// <inheritdoc/>
        /// <remarks>Площадь треуголника расчитывается по трем сторонам.</remarks>
        public override double Площадь()
        {
            return ПлощадьПоТремСторонам();
        }

        /// <summary>
        /// Закрытый метод для расчета площади треугольника по трем сторонам (Формула Герона).
        /// </summary>
        private double ПлощадьПоТремСторонам()
        {
            double периметр = (Сторона1 + Сторона2 + Сторона3) / 2;
            return Math.Sqrt(периметр * (периметр - Сторона1) * (периметр - Сторона2) * (периметр - Сторона3));
        }

        /// <summary>
        /// Метод для определения явзяется ли треугольник прямоугольный, на основании трех сторон.
        /// </summary>
        /// <returns>Вернет <see langword="true"/> если треугольник прямоугольний, в противном случае <see langword="false"/>.</returns>
        public bool ЯвляетсяПрямоугольным()
        { // Упрощенное сравнение без применения epsilon.
            return Math.Pow(Сторона1, 2) == Math.Pow(Сторона2, 2) + Math.Pow(Сторона3, 2) ||
                 Math.Pow(Сторона2, 2) == Math.Pow(Сторона1, 2) + Math.Pow(Сторона3, 2) ||
                 Math.Pow(Сторона3, 2) == Math.Pow(Сторона1, 2) + Math.Pow(Сторона2, 2);
        }
        public override string ToString()
        {
            return $"Треугольник с параметрами: стороны={Сторона1}, {Сторона2}, {Сторона3}, {nameof(Площадь)}={Площадь()}, {nameof(ЯвляетсяПрямоугольным)}={ЯвляетсяПрямоугольным()}";
        }
    }

    /// <summary>
    /// <see cref="Круг"/> - производный класс от <see cref="Фигура"/>.
    /// </summary>
    public class Круг : Фигура
    {
        /// <summary>
        /// Конструктор для создания круга на основании переданного <paramref name="радиус"/>.
        /// </summary>
        /// <param name="радиус">Радиус создаваемого круга, должен быть больше нуля, в противном случае вызывается <see cref="ArgumentException"/>.</param>
        /// <exception cref="ArgumentException">Вызывается в случае передачи не корректных аргументов.</exception>
        public Круг(double радиус)
        {
            if (радиус > 0)
            {
                Радиус = радиус;
            }
            else { throw new ArgumentException($"Значение {nameof(радиус)} не корректно."); }
        }
        public double Радиус { get; private set; }

        /// <inheritdoc/>
        /// <remarks>Площадь круга расчитывается по радиусу.</remarks>
        public override double Площадь()
        {
            return Math.PI * Math.Pow(Радиус, 2);
        }

        public override string ToString()
        {
            return $"Круг с параметрами: радиус={Радиус}, {nameof(Площадь)}={Площадь()}";
        }
    }
}