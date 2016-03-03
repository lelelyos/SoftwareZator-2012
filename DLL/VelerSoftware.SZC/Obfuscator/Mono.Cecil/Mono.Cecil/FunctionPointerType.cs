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
using System.Text;
using Mono.Collections.Generic;
using MD = Mono.Cecil.Metadata;

namespace Mono.Cecil {

	public sealed class FunctionPointerType : TypeSpecification, IMethodSignature {

		readonly MethodReference function;

		public bool HasThis {
			get { return function.HasThis; }
			set { function.HasThis = value; }
		}

		public bool ExplicitThis {
			get { return function.ExplicitThis; }
			set { function.ExplicitThis = value; }
		}

		public MethodCallingConvention CallingConvention {
			get { return function.CallingConvention; }
			set { function.CallingConvention = value; }
		}

		public bool HasParameters {
			get { return function.HasParameters; }
		}

		public Collection<ParameterDefinition> Parameters {
			get { return function.Parameters; }
		}

		public TypeReference ReturnType {
			get { return function.MethodReturnType.ReturnType; }
			set { function.MethodReturnType.ReturnType = value; }
		}

		public MethodReturnType MethodReturnType {
			get { return function.MethodReturnType; }
		}

		public override string Name {
			get { return function.Name; }
			set { throw new InvalidOperationException (); }
		}

		public override string Namespace {
			get { return string.Empty; }
			set { throw new InvalidOperationException (); }
		}

		public override ModuleDefinition Module {
			get { return ReturnType.Module; }
		}

		public override IMetadataScope Scope {
			get { return function.ReturnType.Scope; }
		}

		public override bool IsFunctionPointer {
			get { return true; }
		}

		internal override bool ContainsGenericParameter {
			get { return function.ContainsGenericParameter; }
		}

		public override string FullName {
			get {
				var signature = new StringBuilder ();
				signature.Append (function.Name);
				signature.Append (" ");
				signature.Append (function.ReturnType.FullName);
				signature.Append (" *");
				this.MethodSignatureFullName (signature);
				return signature.ToString ();
			}
		}

		public FunctionPointerType ()
			: base (null)
		{
			this.function = new MethodReference ();
			this.function.Name = "method";
			this.etype = MD.ElementType.FnPtr;
		}

		public override TypeDefinition Resolve ()
		{
			return null;
		}

		public override TypeReference GetElementType ()
		{
			return this;
		}
	}
}
