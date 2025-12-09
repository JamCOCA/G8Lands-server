using SpacetimeDB;

public static partial class Module
{
    [Type]
    public partial struct Stamina
    {
        public int Max;
        public int Current;

        public static Stamina Create(int max, int current)
        {
            if (max < 0) max = 0;
            if (current < 0) current = 0;
            if (current > max) current = max;
            return new Stamina { Max = max, Current = current };
        }

        public Stamina Add(int amount)
        {
            if (amount <= 0) return this;
            var next = Current + amount;
            if (next > Max) next = Max;
            return new Stamina { Max = Max, Current = next };
        }

        public Stamina Sub(int amount)
        {
            if (amount <= 0) return this;
            var next = Current - amount;
            if (next < 0) next = 0;
            return new Stamina { Max = Max, Current = next };
        }

        public Stamina Set(int value)
        {
            if (value < 0) value = 0;
            if (value > Max) value = Max;
            return new Stamina { Max = Max, Current = value };
        }

        public Stamina SetMax(int newMax)
        {
            if (newMax < 0) newMax = 0;
            var nextCurrent = Current;
            if (nextCurrent > newMax) nextCurrent = newMax;
            return new Stamina { Max = newMax, Current = nextCurrent };
        }

        public bool IsZero() => Current <= 0;
        public bool IsFull() => Current >= Max && Max > 0;
    }
}
