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

using Mono.Collections.Generic;

namespace Mono.Cecil {

	class MemberDefinitionCollection<T> : Collection<T> where T : IMemberDefinition {

		TypeDefinition container;

		internal MemberDefinitionCollection (TypeDefinition container)
		{
			this.container = container;
		}

		internal MemberDefinitionCollection (TypeDefinition container, int capacity)
			: base (capacity)
		{
			this.container = container;
		}

		protected override void OnAdd (T item, int index)
		{
			Attach (item);
		}

		protected sealed override void OnSet (T item, int index)
		{
			Attach (item);
		}

		protected sealed override void OnInsert (T item, int index)
		{
			Attach (item);
		}

		protected sealed override void OnRemove (T item, int index)
		{
			Detach (item);
		}

		protected sealed override void OnClear ()
		{
			foreach (var definition in this)
				Detach (definition);
		}

		void Attach (T element)
		{
			if (element.DeclaringType == container)
				return;

			if (element.DeclaringType != null)
				throw new ArgumentException ("Member already attached");

			element.DeclaringType = this.container;
		}

		static void Detach (T element)
		{
			element.DeclaringType = null;
		}
	}
}
