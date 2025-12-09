using SpacetimeDB;

public static partial class Module
{
    // 生命值类型：包含最大值与当前值
    [SpacetimeDB.Type]
    public partial struct Hp
    {
        public int Max;
        public int Current;

        // 创建时的规范化：保证区间 [0, Max]
        public static Hp Create(int max, int current)
        {
            if (max < 0) max = 0;
            if (current < 0) current = 0;
            if (current > max) current = max;
            return new Hp { Max = max, Current = current };
        }

        // 增加生命值（不超过 Max）
        public Hp Add(int amount)
        {
            if (amount <= 0) return this;
            var next = Current + amount;
            if (next > Max) next = Max;
            return new Hp { Max = Max, Current = next };
        }

        // 扣减生命值（不低于 0）
        public Hp Sub(int amount)
        {
            if (amount <= 0) return this;
            var next = Current - amount;
            if (next < 0) next = 0;
            return new Hp { Max = Max, Current = next };
        }

        // 直接设置当前值（夹紧到 [0, Max]）
        public Hp Set(int value)
        {
            if (value < 0) value = 0;
            if (value > Max) value = Max;
            return new Hp { Max = Max, Current = value };
        }

        // 修改最大值（必要时夹紧当前值）
        public Hp SetMax(int newMax)
        {
            if (newMax < 0) newMax = 0;
            var nextCurrent = Current;
            if (nextCurrent > newMax) nextCurrent = newMax;
            return new Hp { Max = newMax, Current = nextCurrent };
        }

        public bool IsZero() => Current <= 0;
        public bool IsFull() => Current >= Max && Max > 0;
    }
}
