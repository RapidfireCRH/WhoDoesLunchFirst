using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceZork
{
    class random
    {
		UInt32 nProcGen = 0;

		public double rndDouble(double min, double max)
		{
			return ((double)rnd() / (double)(0x7FFFFFFF)) * (max - min) + min;
		}

		public int rndInt(int min, int max)
		{
			return (int)(rnd() % (max - min)) + min;
		}
		public void setnProcGen(UInt32 value)
		{
			nProcGen = value;
		}
		

		private UInt32 rnd()
		{
			nProcGen += 0xe120fc15;
			UInt64 tmp;
			tmp = (UInt64)nProcGen * 0x4a39b70d;
			UInt32 m1 = (UInt32)((tmp >> 32) ^ tmp);
			tmp = (UInt64)m1 * 0x12fad5c9;
			UInt32 m2 = (UInt32)((tmp >> 32) ^ tmp);
			return m2;
		}
	}
}
