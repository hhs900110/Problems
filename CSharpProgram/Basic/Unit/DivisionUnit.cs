namespace Unit
{
    public struct DivisionUnit
    {
        private ulong m_remainder;
        private ulong m_quotien;

        public DivisionUnit(ulong target, ulong division)
        {
            m_remainder = 0;
            m_quotien = 0;
            SetDivisionUnit(target, division);
        }

        public void SetDivisionUnit(ulong target, ulong division)
        {
            m_remainder = target % division;
            m_quotien = (target - m_remainder) / division;
        }

        /// <summary> 나눈 값의 나머지 </summary>
        public ulong Remainder { get { return m_remainder; } }
        /// <summary> 나눈 값의 몫 </summary>
        public ulong Quotien { get { return m_quotien; } }
    }
}