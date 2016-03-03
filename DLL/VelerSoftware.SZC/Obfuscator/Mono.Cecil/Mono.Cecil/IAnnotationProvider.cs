// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************


namespace Mono.Cecil {

	using System.Collections;

	public interface IAnnotationProvider {

		IDictionary Annotations { get; }
	}
}
