// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <author name="Daniel Grunwald"/>
//     <version>$Revision: 5583 $</version>
// </file>

using System;
using System.IO;

namespace VelerSoftware.SZC35.Highlighting
{
	static class Resources
	{
        static readonly string Prefix = "VelerSoftware.SZC35.Highlighting.Resources.";
		
		public static Stream OpenStream(string name)
		{
			Stream s = typeof(Resources).Assembly.GetManifestResourceStream(Prefix + name);
			if (s == null)
				throw new FileNotFoundException("The resource file '" + name + "' was not found.");
			return s;
		}
		
		internal static void RegisterBuiltInHighlightings(HighlightingManager.DefaultHighlightingManager hlm)
		{
            hlm.RegisterHighlighting("XmlDoc", null, "XmlDoc.xshd");
            hlm.RegisterHighlighting("Action", null, "Action-Mode.xshd");
            hlm.RegisterHighlighting("VBNET", new[] { ".vb" }, "VBNET-Mode.xshd");
			hlm.RegisterHighlighting("XML", (".xml;.xsl;.xslt;.xsd;.manifest;.config;.addin;" +
			                                 ".xshd;.wxs;.wxi;.wxl;.proj;.csproj;.vbproj;.ilproj;" +
			                                 ".booproj;.build;.xfrm;.targets;.xaml;.xpt;" +
			                                 ".xft;.map;.wsdl;.disco").Split(';'),
                                     "XML-Mode.xshd");
		}
	}
}
