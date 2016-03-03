// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************


using System;

namespace Mono.Cecil {

	public abstract class EventReference : MemberReference {

		TypeReference event_type;

		public TypeReference EventType {
			get { return event_type; }
			set { event_type = value; }
		}

		public override string FullName {
			get { return event_type.FullName + " " + MemberFullName (); }
		}

		protected EventReference (string name, TypeReference eventType)
			: base (name)
		{
			if (eventType == null)
				throw new ArgumentNullException ("eventType");

			event_type = eventType;
		}

		public abstract EventDefinition Resolve ();
	}
}
