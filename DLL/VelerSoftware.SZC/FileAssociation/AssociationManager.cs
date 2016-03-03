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

namespace VelerSoftware.SZC.FileAssociation
{
    /// <summary>
    /// Provides more streamlined interface for associating a single or multiple extensions with a single program.
    /// </summary>
    internal class AssociationManager
    {
        /// <summary>
        /// Determines of the list of extensions are associated with the specified program id.
        /// </summary>
        /// <param name="progId">Program id to check against.</param>
        /// <param name="extensions">String array of extensions to check against the program id.</param>
        /// <returns>String array of extensions that were not associated with the program id.</returns>
        public string[] CheckAssociation(string progId, params string[] extensions)
        {
            List<string> notAssociated = new List<string>();

            foreach (string s in extensions)
            {
                FileAssociationInfo fai = new FileAssociationInfo(s);

                if (!fai.Exists || fai.ProgID != progId)
                    notAssociated.Add(s);
            }

            return notAssociated.ToArray();
        }

        /// <summary>
        /// Associates a single executable with a list of extensions.
        /// </summary>
        /// <param name="progId">Name of program id</param>
        /// <param name="executablePath">Path to executable to start including arguments.</param>
        /// <param name="extensions">String array of extensions to associate with program id.</param>
        /// <example>progId = "MyTextFile"
        /// executablePath = "notepad.exe %1"
        /// extensions = ".txt", ".text"</example>
        public void Associate(string progId, string executablePath, params string[] extensions)
        {
            foreach (string s in extensions)
            {
                FileAssociationInfo fai = new FileAssociationInfo(s);

                if (!fai.Exists)
                    fai.Create(progId);

                fai.ProgID = progId;
            }

            ProgramAssociationInfo pai = new ProgramAssociationInfo(progId);

            if (!pai.Exists)
                pai.Create();

            pai.AddVerb(new ProgramVerb("open", executablePath));
        }

        /// <summary>
        /// Associates an alprêt existing program id with a list of extensions.
        /// </summary>
        /// <param name="progId">The program id to associate extensions with.</param>
        /// <param name="extensions">String array of extensions to associate with program id.</param>
        public void Associate(string progId, params string[] extensions)
        {
            foreach (string s in extensions)
            {
                FileAssociationInfo fai = new FileAssociationInfo(s);

                if (!fai.Exists)
                    fai.Create(progId);

                fai.ProgID = progId;
            }
        }
    }
}