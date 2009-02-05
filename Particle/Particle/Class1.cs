namespace Particle
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
        public float Energy;
        
        /// <summary>
        /// Масса частицы
        /// </summary>
        public float Mass;
        
        /// <summary>
        /// Спин частицы
        /// </summary>
        public float Spin;
        
        /// <summary>
        /// Время жизни частицы
        /// </summary>
        public float LifeTime;

        /// <summary>
        /// Электрический заряд частицы
        /// </summary>
        public float ElectricCharge;

        /// <summary>
        /// Скорость элементарной частицы
        /// </summary>
        public float Speed;

        /// <summary>
        /// Импульс элементарной частицы.
        /// </summary>
        public float Impulse;       


        /// <summary>
        /// Короткое определение для массы.
        /// </summary>
        public float m
        {
            get { return this.Mass; }
            set { this.Mass = value; }
        }

        /// <summary>
        /// Короткое определение для спина.
        /// </summary>
        public float J
        {
            get { return this.Spin;  }
            set { this.Spin = value; }
        }

        /// <summary>
        /// Короткое определение для времени жизни.
        /// </summary>
        public float t
        {
            get { return this.LifeTime; }
            set { this.LifeTime = value; }
        }

        /// <summary>
        /// Короткое определение для заряда частицы.
        /// </summary>
        public float Q
        {
            get { return this.ElectricCharge;  }
            set { this.ElectricCharge = value; }
        }

        /// <summary>
        /// Краткое определение для скорости частицы.
        /// </summary>
        public float V
        {
            get { return this.Speed; }
            set { this.Speed = value; }
        }

        /// <summary>
        /// Краткое определение для импульса частицы.
        /// </summary>
        public float p
        {
            get { return this.Impulse; }
            set { this.Impulse = value; }
        }


        /// <summary>
        /// Функция для расчёта импульса частицы.
        /// </summary>
        /// <returns>Импульс частицы.</returns>
        public float CountImpulse()
        {
            this.Impulse = this.Mass * this.Speed;
            return this.Impulse;
        }

    }
}
