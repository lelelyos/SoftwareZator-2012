// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************


#if !NET_3_5 && !NET_4_0

namespace Mono {
	//delegate void Action ();
	delegate void Action<T1, T2> (T1 arg1, T2 arg2);
	//delegate void Action<T1, T2, T3> (T1 arg1, T2 arg2, T3 arg3);
	//delegate void Action<T1, T2, T3, T4> (T1 arg1, T2 arg2, T3 arg3, T4 arg4);
}

#endif
