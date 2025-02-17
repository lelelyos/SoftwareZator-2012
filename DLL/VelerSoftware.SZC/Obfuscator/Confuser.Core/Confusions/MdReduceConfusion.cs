﻿// *****************************************************************************
// 
//  © Veler Software 2012. All rights reserved.
//  The current code and the associated software are the proprietary 
//  information of Etienne Baudoux from Veler Software and are
//  supplied subject to licence terms.
// 
//  www.velersoftware.com
// *****************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Rocks;

namespace VelerSoftware.SZC.Obfuscator.Confuser.Core.Confusions
{
    public class MdReduceConfusion : StructurePhase, IConfusion
    {
        public string Name
        {
            get { return "Reduce Metadata Confusion"; }
        }
        public string Description
        {
            get
            {
                return @"This confusion reduce the metadata carried by the assembly by removing unnecessary metadata.
***If your application relys on Reflection, you should not apply this confusion***";
            }
        }
        public string ID
        {
            get { return "reduce md"; }
        }
        public bool StandardCompatible
        {
            get { return true; }
        }
        public Target Target
        {
            get { return Target.Events | Target.Properties | Target.Types; }
        }
        public Preset Preset
        {
            get { return Preset.Maximum; }
        }
        public Phase[] Phases
        {
            get { return new Phase[] { this }; }
        }

        public override Priority Priority
        {
            get { return Priority.TypeLevel; }
        }
        public override IConfusion Confusion
        {
            get { return this; }
        }
        public override int PhaseID
        {
            get { return 1; }
        }
        public override bool WholeRun
        {
            get { return false; }
        }
        public bool SupportLateAddition
        {
            get { return true; }
        }
        public Behaviour Behaviour
        {
            get { return Behaviour.AlterStructure; }
        }
        public override void Initialize(ModuleDefinition mod)
        {
            //
        }
        public override void DeInitialize()
        {
            //
        }

        public override void Process(ConfusionParameter parameter)
        {
            IMemberDefinition def = parameter.Target as IMemberDefinition;

            TypeDefinition t;
            if ((t = def as TypeDefinition) != null && !IsTypePublic(t))
            {
                if (t.IsEnum)
                {
                    int idx = 0;
                    while (t.Fields.Count != 1)
                        if (t.Fields[idx].Name != "value__")
                            t.Fields.RemoveAt(idx);
                        else
                            idx++;
                }
                else if (def is EventDefinition)
                {
                    def.DeclaringType.Events.Remove(def as EventDefinition);
                }
                else if (def is PropertyDefinition)
                {
                    def.DeclaringType.Properties.Remove(def as PropertyDefinition);
                }
            }
        }

        bool IsTypePublic(TypeDefinition type)
        {
            do
            {
                if (!type.IsPublic && !type.IsNestedFamily && !type.IsNestedFamilyAndAssembly && !type.IsNestedFamilyOrAssembly && !type.IsNestedPublic && !type.IsPublic)
                    return false;
                type = type.DeclaringType;
            } while (type != null);
            return true;
        }
    }
}
