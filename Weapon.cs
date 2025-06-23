using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace pamit
{
    public class Weapon
    {
        private int _minDamage;
        private int _maxDamage;

        public string Name { get; }
        public int MinDamage
        {
            get => _minDamage;
            private set => _minDamage = value;
        }
        public int MaxDamage
        {
            get => _maxDamage;
            private set => _maxDamage = value;
        }
        public float Durability { get; } = 1f;

        public Weapon(string name) : this(name, 1, 10) { }

        public Weapon(string name, int minDamage, int maxDamage)
        {
            Name = name;
            SetDamageParams(minDamage, maxDamage);
        }

        public void SetDamageParams(int minDamage, int maxDamage)
        {
            if (minDamage > maxDamage)
            {
                (_minDamage, _maxDamage) = (maxDamage, minDamage);
                Console.WriteLine($"Некорректные входные данные для оружия {Name}. Min и Max были поменяны местами.");
            }
            else if (minDamage < 1)
            {
                _minDamage = 1;
                Console.WriteLine($"Минимальный урон оружия {Name} был установлен на 1.");
            }
            else
            {
                _minDamage = minDamage;
            }

            _maxDamage = maxDamage <= 1 ? 10 : maxDamage;
        }

        public int GetDamage()
        {
            return (MinDamage + MaxDamage) / 2;
        }
    }
}

