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


    }
}
