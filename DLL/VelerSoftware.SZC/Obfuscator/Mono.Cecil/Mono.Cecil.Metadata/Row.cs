
// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************


using System.Collections.Generic;

namespace Mono.Cecil.Metadata {

	public class Row<T1, T2> {
		public T1 Col1;
        public T2 Col2;

		public Row (T1 col1, T2 col2)
		{
			Col1 = col1;
			Col2 = col2;
		}
	}

	public class Row<T1, T2, T3> {
        public T1 Col1;
        public T2 Col2;
        public T3 Col3;

		public Row (T1 col1, T2 col2, T3 col3)
		{
			Col1 = col1;
			Col2 = col2;
			Col3 = col3;
		}
	}

	public class Row<T1, T2, T3, T4> {
        public T1 Col1;
        public T2 Col2;
        public T3 Col3;
        public T4 Col4;

		public Row (T1 col1, T2 col2, T3 col3, T4 col4)
		{
			Col1 = col1;
			Col2 = col2;
			Col3 = col3;
			Col4 = col4;
		}
	}

	public class Row<T1, T2, T3, T4, T5> {
        public T1 Col1;
        public T2 Col2;
        public T3 Col3;
        public T4 Col4;
        public T5 Col5;

		public Row (T1 col1, T2 col2, T3 col3, T4 col4, T5 col5)
		{
			Col1 = col1;
			Col2 = col2;
			Col3 = col3;
			Col4 = col4;
			Col5 = col5;
		}
	}

	public class Row<T1, T2, T3, T4, T5, T6> {
        public T1 Col1;
        public T2 Col2;
        public T3 Col3;
        public T4 Col4;
        public T5 Col5;
        public T6 Col6;

		public Row (T1 col1, T2 col2, T3 col3, T4 col4, T5 col5, T6 col6)
		{
			Col1 = col1;
			Col2 = col2;
			Col3 = col3;
			Col4 = col4;
			Col5 = col5;
			Col6 = col6;
		}
	}

	public class Row<T1, T2, T3, T4, T5, T6, T7, T8, T9> {
        public T1 Col1;
        public T2 Col2;
        public T3 Col3;
        public T4 Col4;
        public T5 Col5;
        public T6 Col6;
        public T7 Col7;
        public T8 Col8;
        public T9 Col9;

		public Row (T1 col1, T2 col2, T3 col3, T4 col4, T5 col5, T6 col6, T7 col7, T8 col8, T9 col9)
		{
			Col1 = col1;
			Col2 = col2;
			Col3 = col3;
			Col4 = col4;
			Col5 = col5;
			Col6 = col6;
			Col7 = col7;
			Col8 = col8;
			Col9 = col9;
		}
	}
}
