using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneCallStruct
{
    public struct PhoneCall
    {
        int time;
        public int Time
        {
            get => time;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Значение должно быть положительным");

                time = value;
            }

        }

        double rate;

        public double Rate
        {
            get => rate;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Значение должно быть положительным");

                rate = value;
            }
        }

        public double Cost
        {
            get => Rate * Time / 60;
        }

        public PhoneCall(int time, double rate) : this()
        {
            Time = time;
            Rate = rate;
        }

        public override string ToString() => $"Разговор: {Time} c по {Rate} руб./мин";

        public override bool Equals(object obj)
        {
            if (obj is PhoneCall phoneCall)
                return Time == phoneCall.Time && Rate == phoneCall.Rate;
            throw new ArgumentException("Объект для сравнения не является телефонным разговором");
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                const int p = 23;
                hash = hash * p + Time.GetHashCode();
                hash = hash * p + Rate.GetHashCode();

                return hash;
            }
        }

        public static PhoneCall operator +(PhoneCall x, PhoneCall y)
        {
            if (x.Rate == y.Rate)
                return new PhoneCall(x.Time + y.Time, x.Rate);

            throw new ArgumentException("У разговоров разный тариф");
        }

        public static PhoneCall operator *(PhoneCall phoneCall, double k)
        {
            if (k > 0)
                return new PhoneCall(phoneCall.Time, phoneCall.Rate * k);

            throw new ArgumentException("Число должно быть положительным");
        }
    }
}