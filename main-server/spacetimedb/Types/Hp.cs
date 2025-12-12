using SpacetimeDB;

public static partial class Module
{
    /// <summary>
    /// 生命值类型：包含最大值与当前值。
    /// </summary>
    /// <remarks>
    /// 该类型采用“返回新值”的不可变风格：所有变更方法（Add/Sub/Set/SetMax）都会返回一个新的 <see cref="Hp" />。
    /// 同时保证 <c>0 &lt;= Current &lt;= Max</c>。
    /// </remarks>
    [SpacetimeDB.Type]
    public partial struct Hp
    {
        /// <summary>
        /// 最大生命值。
        /// </summary>
        public int Max;

        /// <summary>
        /// 当前生命值。
        /// </summary>
        public int Current;

        /// <summary>
        /// 创建一个规范化后的生命值，自动将数值夹紧到合法区间 <c>[0, Max]</c>。
        /// </summary>
        /// <param name="max">最大值（小于 0 会被视为 0）。</param>
        /// <param name="current">当前值（会被夹紧到 <c>[0, max]</c>）。</param>
        /// <returns>规范化后的 <see cref="Hp" />。</returns>
        public static Hp Create(int max, int current)
        {
            if (max < 0) max = 0;
            if (current < 0) current = 0;
            if (current > max) current = max;
            return new Hp { Max = max, Current = current };
        }

        /// <summary>
        /// 增加生命值（不会超过 <see cref="Max" />）。
        /// </summary>
        /// <param name="amount">增加量（小于等于 0 将不产生变化）。</param>
        /// <returns>增加后的新 <see cref="Hp" />。</returns>
        public Hp Add(int amount)
        {
            if (amount <= 0) return this;
            var next = Current + amount;
            if (next > Max) next = Max;
            return new Hp { Max = Max, Current = next };
        }

        /// <summary>
        /// 扣减生命值（不会低于 0）。
        /// </summary>
        /// <param name="amount">扣减量（小于等于 0 将不产生变化）。</param>
        /// <returns>扣减后的新 <see cref="Hp" />。</returns>
        public Hp Sub(int amount)
        {
            if (amount <= 0) return this;
            var next = Current - amount;
            if (next < 0) next = 0;
            return new Hp { Max = Max, Current = next };
        }

        /// <summary>
        /// 设置当前生命值（会被夹紧到合法区间 <c>[0, Max]</c>）。
        /// </summary>
        /// <param name="value">要设置的当前值。</param>
        /// <returns>设置后的新 <see cref="Hp" />。</returns>
        public Hp Set(int value)
        {
            if (value < 0) value = 0;
            if (value > Max) value = Max;
            return new Hp { Max = Max, Current = value };
        }

        /// <summary>
        /// 修改最大生命值，并在必要时将 <see cref="Current" /> 夹紧到新的最大值。
        /// </summary>
        /// <param name="newMax">新的最大值（小于 0 会被视为 0）。</param>
        /// <returns>修改后的新 <see cref="Hp" />。</returns>
        public Hp SetMax(int newMax)
        {
            if (newMax < 0) newMax = 0;
            var nextCurrent = Current;
            if (nextCurrent > newMax) nextCurrent = newMax;
            return new Hp { Max = newMax, Current = nextCurrent };
        }

        /// <summary>
        /// 判断当前生命是否为 0（或小于 0，理论上不会出现）。
        /// </summary>
        /// <returns>当 <see cref="Current" /> 小于等于 0 时返回 true。</returns>
        public bool IsZero() => Current <= 0;

        /// <summary>
        /// 判断生命是否已满。
        /// </summary>
        /// <returns>当 <see cref="Max" /> 大于 0 且 <see cref="Current" /> 大于等于 <see cref="Max" /> 时返回 true。</returns>
        public bool IsFull() => Current >= Max && Max > 0;
    }
}
