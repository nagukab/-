using БиблиотекаПлощадьФигур;

namespace Тест
{
    [TestFixture]
    public class ТестКруга
    {
        [Test]
        public void КругПлощадь()
        {
            Random рандом = new();
            for (int i = 1; i < 10; i++)
            {
                double случайныйРадиус = рандом.NextDouble() + i;
                double ожидаемыйРезультат = Math.PI * Math.Pow(случайныйРадиус, 2);
                Assert.That(new Круг(случайныйРадиус).Площадь(), Is.EqualTo(ожидаемыйРезультат));
            }
        }

        [Test]
        public void КругКорректность()
        {
            Assert.Throws<ArgumentException>(() => new Круг(0));
            Assert.Throws<ArgumentException>(() => new Круг(-1));
        }
    }

    [TestFixture]
    public class ТестТреугольника
    {
        [Test]
        public void ТреугольникПлощадь1()
        {
            Assert.That(new Треугольник(3, 4, 5).Площадь, Is.EqualTo(6));
        }

        [Test]
        public void ТреугольникПлощадь2()
        {
            Assert.That(new Треугольник(5, 5, 6).Площадь, Is.EqualTo(12));
            // Странно, одна из сторон увеличивается с 6 до 8, а площадь не увеличивается. И во всех онлайн калькуляторах так, чет подозрительно.
            Assert.That(new Треугольник(5, 5, 8).Площадь, Is.EqualTo(12));
        }

        [Test]
        public void ТреугольникКорректность()
        {
            Assert.Throws<ArgumentException>(() => { new Треугольник(0, 3, 3); });
            Assert.Throws<ArgumentException>(() => { new Треугольник(-3, 3, 3); });
            Assert.Throws<ArgumentException>(() => { new Треугольник(33, 3, 3); });
        }

        [Test]
        public void ТреугольникЯвляетсяПрямоугольным()
        {
            Assert.False(new Треугольник(5, 5, 5).ЯвляетсяПрямоугольным());

            Assert.True(new Треугольник(3, 4, 5).ЯвляетсяПрямоугольным());
        }
    }
}