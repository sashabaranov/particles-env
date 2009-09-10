namespace MDK
{
    /// <summary>
    /// Класс для элементарной частицы
    /// </summary>
    public class Particle
    {
        /// <summary>
        /// Координата X частицы
        /// </summary>
        public float x;

        /// <summary>
        /// Координрата Y частицы
        /// </summary>
        public float y;

        /// <summary>
        /// Внутренняя энергия частицы
        /// </summary>
        public double Energy;
        
        /// <summary>
        /// Масса частицы
        /// </summary>
        public double Mass;
        
        /// <summary>
        /// Спин частицы
        /// </summary>
        public double Spin;
        
        /// <summary>
        /// Время жизни частицы
        /// </summary>
        public double LifeTime;

        /// <summary>
        /// Электрический заряд частицы
        /// </summary>
        public double ElectricCharge;

        /// <summary>
        /// Скорость элементарной частицы
        /// </summary>
        public double Speed;

        /// <summary>
        /// Скорость по X
        /// </summary>
        public double vx;

        /// <summary>
        /// Скорость по Y
        /// </summary>
        public double vy;
        
        
        /// <summary>
        /// Импульс элементарной частицы.
        /// </summary>
        public double Impulse;       


        /// <summary>
        /// Короткое определение для массы.
        /// </summary>
        public double m
        {
            get { return this.Mass; }
            set { this.Mass = value; }
        }

        /// <summary>
        /// Короткое определение для спина.
        /// </summary>
        public double J
        {
            get { return this.Spin;  }
            set { this.Spin = value; }
        }

        /// <summary>
        /// Короткое определение для времени жизни.
        /// </summary>
        public double t
        {
            get { return this.LifeTime; }
            set { this.LifeTime = value; }
        }

        /// <summary>
        /// Короткое определение для заряда частицы.
        /// </summary>
        public double Q
        {
            get { return this.ElectricCharge;  }
            set { this.ElectricCharge = value; }
        }

        /// <summary>
        /// Краткое определение для скорости частицы.
        /// </summary>
        public double V
        {
            get { return this.Speed; }
            set { this.Speed = value; }
        }

        /// <summary>
        /// Краткое определение для импульса частицы.
        /// </summary>
        public double p
        {
            get { return this.Impulse; }
            set { this.Impulse = value; }
        }


        /// <summary>
        /// Функция для расчёта импульса частицы.
        /// </summary>
        /// <returns>Импульс частицы.</returns>
        public double CountImpulse()
        {
            this.Impulse = this.Mass * this.Speed;
            return this.Impulse;
        }


        /// <summary>
        /// Дефолтный конструктор
        /// </summary>
        public Particle() { }

        /// <summary>
        /// Консруктор с импортом энергии в объект
        /// </summary>
        /// <param name="Energy">Энергия частицы</param>
        public Particle(double Energy)
        {
            this.Energy = Energy;
        }
    }
}
