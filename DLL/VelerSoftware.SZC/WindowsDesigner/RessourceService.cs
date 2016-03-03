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
using System.Collections;
using System.ComponentModel.Design;
using System.IO;
using System.Resources;

namespace VelerSoftware.SZC.WindowsDesigner
{
    /// Resource service using .resx files
    public class ResourceService : IResourceService, IDisposable
    {
        //private Hashtable writers;
        //private Hashtable readers; 
        public ResXResourceWriter writer;
        public ResXResourceReader reader;
        private IDesignerHost host;
        // Track whether Dispose has been called.
        private Boolean disposed = false;

        private string path;

        public ResourceService(IDesignerHost host, string _path)
        {
            this.host = host;
            path = _path;
            if (File.Exists(path))
            {
                reader = new ResXResourceReader(path);
                writer = new ResXResourceWriter(path);
            }
            //writers = new Hashtable();
            //readers = new Hashtable();
        }

        ~ResourceService()
        {
            Dispose(false);
        }

        public void Save()
        {
            // Create a ResXResourceReader for the file items.resx.
            ResXResourceReader rsxr = new ResXResourceReader(path);
            ResXResourceWriter rsxTranslated = new ResXResourceWriter(path + "_2");
            // Create an IDictionaryEnumerator to iterate through the resources.

            IDictionaryEnumerator id = rsxr.GetEnumerator();
            // Iterate through the resources 
            foreach (DictionaryEntry d in rsxr)
            {
                rsxTranslated.AddResource(d.Key.ToString(), d.Value);
            }

            rsxTranslated.Generate();
            rsxTranslated.Close();
            rsxTranslated.Dispose();
        }

        #region Implementation of IResourceService

        public System.Resources.IResourceReader GetResourceReader(System.Globalization.CultureInfo info)
        {
            //ResXResourceReader reader = (ResXResourceReader) readers[info];
            if (reader == null)
            {
                reader = new ResXResourceReader(path);
                //readers.Add(info, reader);
            }
            return reader;
        }

        public System.Resources.IResourceWriter GetResourceWriter(System.Globalization.CultureInfo info)
        {
            //ResXResourceWriter writer = (ResXResourceWriter) writers[info];
            if (writer != null)
            {
                //writer.Generate();
                //writer.Close();
                writer.Dispose();
            }
            writer = new ResXResourceWriter(path);
            //  if (writer == null)
            //  {
            //      writer = new ResXResourceWriter(path);
            //      //writers.Add(info, writer);
            //  }
            return writer;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(Boolean disposing)
        {
            // Check to see if Dispose has already been called.
            if (!disposed)
            {
                writer.Close();
                reader.Close();
                writer.Dispose();
                writer = null;
            }
            disposed = true;
        }

        #endregion
    }
}
