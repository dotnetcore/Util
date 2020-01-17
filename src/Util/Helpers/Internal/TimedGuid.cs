using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Util.Helpers.Internal
{
    /// <summary>
    /// 包含时间的、类型的Guid
    /// </summary>
    class TimedGuid : IComparable<TimedGuid>, IComparable<Guid>, IComparable, IEquatable<TimedGuid>, IEquatable<Guid>, IEqualityComparer<TimedGuid>
    {
        private static Random R = new Random();
        private static int mbrSeq = int.MinValue;

        /// <summary>
        /// 计算值
        /// </summary>
        private int mbrX { get { return unchecked(mbrMultA * mbrMultB); } }
        private DateTime mbrTime = DateTime.Now;
        private byte mbrType;
        private uint mbrIndex;
        private ushort mbrMultA, mbrMultB;

        /// <summary>
        /// 接受一个255内的类型分类
        /// </summary>
        public TimedGuid(byte uType = 0)
        {
            lock (R)
            {
                mbrMultA = (ushort)(R.Next(1, ushort.MaxValue));
                mbrMultB = (ushort)(R.Next(1, ushort.MaxValue));
            }
            mbrType = uType;
            Interlocked.CompareExchange(ref mbrSeq, int.MinValue + 8, int.MaxValue - 8);
            int x = Interlocked.Increment(ref mbrSeq);
            mbrIndex = (uint)(unchecked(x - (int.MinValue + 8)));
        }

        /// <summary>
        /// 解Guid
        /// </summary>
        public Guid ToGuid()
        {
            return Guid.TryParse(ToString(), out Guid id) ? id : Guid.NewGuid();
        }

        /// <summary>
        /// 生成Guid
        /// </summary>
        public static Guid NewGuid(byte uType = 0)
        {
            return new TimedGuid(uType).ToGuid();
        }

        public override string ToString()
        {
            string y = mbrTime.Year.ToString();
            y = y.Substring(y.Length - 2);

            StringBuilder sb = new StringBuilder(y);        //  2
            sb.AppendFormat("{0:x}", mbrTime.Month);        //  1   -> 3
            sb.AppendFormat("{0:ddHHmmssff}", mbrTime);     //  10  -> 13
            sb.AppendFormat("{0:x2}", mbrType);             //  2   -> 15

            y = mbrIndex.ToString("x");
            y = y.Substring(y.Length - 1);
            sb.Append(y);                                   //  1   -> 16

            sb.AppendFormat("{0:x4}", mbrMultA);
            sb.AppendFormat("{0:x4}", mbrMultB);
            sb.AppendFormat("{0:x8}", mbrX);

            Debug.Print(sb.ToString());
            return sb.ToString();
        }

        public int CompareTo(TimedGuid other)
        {
            if (mbrTime > other.mbrTime)
            {
                return 1;
            }
            else if (mbrTime < other.mbrTime)
            {
                return -1;
            }

            if (mbrType > other.mbrType)
            {
                return 1;
            }
            else if (mbrType < other.mbrType)
            {
                return -1;
            }

            if (mbrIndex > other.mbrIndex)
            {
                return 1;
            }
            else if (mbrIndex < other.mbrIndex)
            {
                return -1;
            }

            if (mbrMultA > other.mbrMultA)
            {
                return 1;
            }
            else if (mbrMultA < other.mbrMultA)
            {
                return -1;
            }

            if (mbrMultB > other.mbrMultB)
            {
                return 1;
            }
            else if (mbrMultB < other.mbrMultB)
            {
                return -1;
            }

            return 0;
        }

        public int CompareTo(Guid other)
        {
            return ToGuid().CompareTo(other);
        }

        public int CompareTo(object obj)
        {
            if (obj is TimedGuid)
            {
                return CompareTo(obj as TimedGuid);
            }
            else if (obj is Guid)
            {
                return CompareTo(((Guid)(obj)));
            }
            else
            {
                return 1;
            }
        }

        public bool Equals(TimedGuid other)
        {
            return CompareTo(other) == 0;
        }

        public bool Equals(Guid other)
        {
            return CompareTo(other) == 0;
        }

        public bool Equals(TimedGuid x, TimedGuid y)
        {
            return x.Equals(y);
        }

        public int GetHashCode(TimedGuid obj)
        {
            return obj.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return CompareTo(obj) == 0;
        }
        public override int GetHashCode()
        {
            return mbrTime.GetHashCode() ^ mbrType.GetHashCode() ^ mbrIndex.GetHashCode() ^ mbrMultA.GetHashCode() ^ mbrMultB.GetHashCode();
        }
    }
}
