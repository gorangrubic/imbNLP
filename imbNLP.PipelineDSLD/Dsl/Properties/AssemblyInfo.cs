#region Using directives

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;

#endregion

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: AssemblyTitle(@"")]
[assembly: AssemblyDescription(@"")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(@"imbVeles")]
[assembly: AssemblyProduct(@"NLPPipelineDSLD")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: System.Resources.NeutralResourcesLanguage("en")]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: AssemblyVersion(@"1.0.0.0")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: ReliabilityContract(Consistency.MayCorruptProcess, Cer.None)]

//
// Make the Dsl project internally visible to the DslPackage assembly
//
[assembly: InternalsVisibleTo(@"imbNLP.PipelineDSLD.DslPackage, PublicKey=002400000480000094000000060200000024000052534131000400000100010049AB0095910E7FAE1C90070F774A068A6116AB7132C9D0C99622013B203306FB6E33D859811DC1C16F5F5E2A89E1AD8C017B9D20EF3F5F9EF04047E72982ADF93AF43658DFFE0D6D35B1BF466714E365267DE73FBB995C4D2EB7834EB6235D22830F80DDBE3888028E3BA822E453EC141BCEC0AC57B5FA061DD7939EFF4D1CC3")]