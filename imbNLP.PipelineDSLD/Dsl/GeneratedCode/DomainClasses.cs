﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
namespace imbNLP.PipelineDSLD
{
	/// <summary>
	/// DomainClass ExampleModel
	/// The root in which all other elements are embedded. Appears as a diagram.
	/// </summary>
	[DslDesign::DisplayNameResource("imbNLP.PipelineDSLD.ExampleModel.DisplayName", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("imbNLP.PipelineDSLD.ExampleModel.Description", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel))]
	[global::System.CLSCompliant(true)]
	[DslModeling::DomainObjectId("60247645-52b9-450f-971b-d90482338105")]
	public partial class ExampleModel : DslModeling::ModelElement
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ExampleModel domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new global::System.Guid(0x60247645, 0x52b9, 0x450f, 0x97, 0x1b, 0xd9, 0x04, 0x82, 0x33, 0x81, 0x05);
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ExampleModel(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ExampleModel(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region Elements opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Elements.
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<ExampleElement> Elements
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<ExampleElement>, ExampleElement>(global::imbNLP.PipelineDSLD.ExampleModelHasElements.ExampleModelDomainRoleId);
			}
		}
		#endregion
		#region ElementGroupPrototype Merge methods
		/// <summary>
		/// Returns a value indicating whether the source element represented by the
		/// specified root ProtoElement can be added to this element.
		/// </summary>
		/// <param name="rootElement">
		/// The root ProtoElement representing a source element.  This can be null, 
		/// in which case the ElementGroupPrototype does not contain an ProtoElements
		/// and the code should inspect the ElementGroupPrototype context information.
		/// </param>
		/// <param name="elementGroupPrototype">The ElementGroupPrototype that contains the root ProtoElement.</param>
		/// <returns>true if the source element represented by the ProtoElement can be added to this target element.</returns>
		protected override bool CanMerge(DslModeling::ProtoElementBase rootElement, DslModeling::ElementGroupPrototype elementGroupPrototype)
		{
			if ( elementGroupPrototype == null ) throw new global::System.ArgumentNullException("elementGroupPrototype");
			
			if (rootElement != null)
			{
				DslModeling::DomainClassInfo rootElementDomainInfo = this.Partition.DomainDataDirectory.GetDomainClass(rootElement.DomainClassId);
				
				if (rootElementDomainInfo.IsDerivedFrom(global::imbNLP.PipelineDSLD.ExampleElement.DomainClassId)) 
				{
					return true;
				}
			}
			return base.CanMerge(rootElement, elementGroupPrototype);
		}
		
		/// <summary>
		/// Called by the Merge process to create a relationship between 
		/// this target element and the specified source element. 
		/// Typically, a parent-child relationship is established
		/// between the target element (the parent) and the source element 
		/// (the child), but any relationship can be established.
		/// </summary>
		/// <param name="sourceElement">The element that is to be related to this model element.</param>
		/// <param name="elementGroup">The group of source ModelElements that have been rehydrated into the target store.</param>
		/// <remarks>
		/// This method is overriden to create the relationship between the target element and the specified source element.
		/// The base method does nothing.
		/// </remarks>
		protected override void MergeRelate(DslModeling::ModelElement sourceElement, DslModeling::ElementGroup elementGroup)
		{
			// In general, sourceElement is allowed to be null, meaning that the elementGroup must be parsed for special cases.
			// However this is not supported in generated code.  Use double-deriving on this class and then override MergeRelate completely if you 
			// need to support this case.
			if ( sourceElement == null ) throw new global::System.ArgumentNullException("sourceElement");
		
				
			global::imbNLP.PipelineDSLD.ExampleElement sourceExampleElement1 = sourceElement as global::imbNLP.PipelineDSLD.ExampleElement;
			if (sourceExampleElement1 != null)
			{
				// Create link for path ExampleModelHasElements.Elements
				this.Elements.Add(sourceExampleElement1);

				return;
			}
		
			// Sdk workaround to runtime bug #879350 (DSL: can't copy and paste a MEL that has a MEX). Avoid MergeRelate on ModelElementExtension
			// during a "Paste".
			if (sourceElement is DslModeling::ExtensionElement
				&& sourceElement.Store.TransactionManager.CurrentTransaction.TopLevelTransaction.Context.ContextInfo.ContainsKey("{9DAFD42A-DC0E-4d78-8C3F-8266B2CF8B33}"))
			{
				return;
			}
		
			// Fall through to base class if this class hasn't handled the merge.
			base.MergeRelate(sourceElement, elementGroup);
		}
		
		/// <summary>
		/// Performs operation opposite to MergeRelate - i.e. disconnects a given
		/// element from the current one (removes links created by MergeRelate).
		/// </summary>
		/// <param name="sourceElement">Element to be unmerged/disconnected.</param>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
		protected override void MergeDisconnect(DslModeling::ModelElement sourceElement)
		{
			if (sourceElement == null) throw new global::System.ArgumentNullException("sourceElement");
				
			global::imbNLP.PipelineDSLD.ExampleElement sourceExampleElement1 = sourceElement as global::imbNLP.PipelineDSLD.ExampleElement;
			if (sourceExampleElement1 != null)
			{
				// Delete link for path ExampleModelHasElements.Elements
				
				foreach (DslModeling::ElementLink link in global::imbNLP.PipelineDSLD.ExampleModelHasElements.GetLinks((global::imbNLP.PipelineDSLD.ExampleModel)this, sourceExampleElement1))
				{
					// Delete the link, but without possible delete propagation to the element since it's moving to a new location.
					link.Delete(global::imbNLP.PipelineDSLD.ExampleModelHasElements.ExampleModelDomainRoleId, global::imbNLP.PipelineDSLD.ExampleModelHasElements.ElementDomainRoleId);
				}

				return;
			}
			// Fall through to base class if this class hasn't handled the unmerge.
			base.MergeDisconnect(sourceElement);
		}
		#endregion
	}
}
namespace imbNLP.PipelineDSLD
{
	/// <summary>
	/// DomainClass ExampleElement
	/// Elements embedded in the model. Appear as boxes on the diagram.
	/// </summary>
	[DslDesign::DisplayNameResource("imbNLP.PipelineDSLD.ExampleElement.DisplayName", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("imbNLP.PipelineDSLD.ExampleElement.Description", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel))]
	[global::System.CLSCompliant(true)]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("39753531-e87d-44c4-905e-b4dda764b0ee")]
	public partial class ExampleElement : DslModeling::ModelElement
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// ExampleElement domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new global::System.Guid(0x39753531, 0xe87d, 0x44c4, 0x90, 0x5e, 0xb4, 0xdd, 0xa7, 0x64, 0xb0, 0xee);
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ExampleElement(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public ExampleElement(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new global::System.Guid(0x57936d3d, 0xa26f, 0x41db, 0x91, 0x5e, 0xd1, 0xd1, 0x18, 0x9c, 0xf4, 0x45);
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = string.Empty;
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// Description for imbNLP.PipelineDSLD.ExampleElement.Name
		/// </summary>
		[DslDesign::DisplayNameResource("imbNLP.PipelineDSLD.ExampleElement/Name.DisplayName", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
		[DslDesign::DescriptionResource("imbNLP.PipelineDSLD.ExampleElement/Name.Description", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("57936d3d-a26f-41db-915e-d1d1189cf445")]
		public global::System.String Name
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return namePropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				NamePropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the ExampleElement.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<ExampleElement, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the ExampleElement.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the ExampleElement.Name domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return NameDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(ExampleElement element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(ExampleElement element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.namePropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
		#region ExampleModel opposite domain role accessor
		/// <summary>
		/// Gets or sets ExampleModel.
		/// </summary>
		public virtual ExampleModel ExampleModel
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return DslModeling::DomainRoleInfo.GetLinkedElement(this, global::imbNLP.PipelineDSLD.ExampleModelHasElements.ElementDomainRoleId) as ExampleModel;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetLinkedElement(this, global::imbNLP.PipelineDSLD.ExampleModelHasElements.ElementDomainRoleId, value);
			}
		}
		#endregion
		#region Targets opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Targets.
		/// Description for imbNLP.PipelineDSLD.ExampleRelationship.Target
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<ExampleElement> Targets
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<ExampleElement>, ExampleElement>(global::imbNLP.PipelineDSLD.ExampleElementReferencesTargets.SourceDomainRoleId);
			}
		}
		#endregion
		#region Sources opposite domain role accessor
		
		/// <summary>
		/// Gets a list of Sources.
		/// Description for imbNLP.PipelineDSLD.ExampleRelationship.Source
		/// </summary>
		public virtual DslModeling::LinkedElementCollection<ExampleElement> Sources
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return GetRoleCollection<DslModeling::LinkedElementCollection<ExampleElement>, ExampleElement>(global::imbNLP.PipelineDSLD.ExampleElementReferencesTargets.TargetDomainRoleId);
			}
		}
		#endregion
	}
}
namespace imbNLP.PipelineDSLD
{
	/// <summary>
	/// DomainClass TaskConstructor
	/// Elements embedded in the model. Appear as boxes on the diagram.
	/// </summary>
	[DslDesign::DisplayNameResource("imbNLP.PipelineDSLD.TaskConstructor.DisplayName", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("imbNLP.PipelineDSLD.TaskConstructor.Description", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel))]
	[global::System.CLSCompliant(true)]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("3c8138c3-8a67-487b-8953-5b2dd908a800")]
	public partial class TaskConstructor : DslModeling::ModelElement
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// TaskConstructor domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new global::System.Guid(0x3c8138c3, 0x8a67, 0x487b, 0x89, 0x53, 0x5b, 0x2d, 0xd9, 0x08, 0xa8, 0x00);
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public TaskConstructor(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public TaskConstructor(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new global::System.Guid(0xc89b0445, 0x82ec, 0x428e, 0x87, 0xf1, 0xeb, 0xc5, 0x7d, 0xcc, 0x4f, 0x8d);
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = string.Empty;
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// Description for imbNLP.PipelineDSLD.TaskConstructor.Name
		/// </summary>
		[DslDesign::DisplayNameResource("imbNLP.PipelineDSLD.TaskConstructor/Name.DisplayName", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
		[DslDesign::DescriptionResource("imbNLP.PipelineDSLD.TaskConstructor/Name.Description", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("c89b0445-82ec-428e-87f1-ebc57dcc4f8d")]
		public global::System.String Name
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return namePropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				NamePropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the TaskConstructor.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<TaskConstructor, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the TaskConstructor.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the TaskConstructor.Name domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return NameDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(TaskConstructor element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(TaskConstructor element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.namePropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
	}
}
namespace imbNLP.PipelineDSLD
{
	/// <summary>
	/// DomainClass TestNodeBase
	/// Elements embedded in the model. Appear as boxes on the diagram.
	/// </summary>
	[DslDesign::DisplayNameResource("imbNLP.PipelineDSLD.TestNodeBase.DisplayName", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("imbNLP.PipelineDSLD.TestNodeBase.Description", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel))]
	[global::System.CLSCompliant(true)]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("f10e850f-9aca-4334-8e73-54f92df24509")]
	public partial class TestNodeBase : DslModeling::ModelElement
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// TestNodeBase domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new global::System.Guid(0xf10e850f, 0x9aca, 0x4334, 0x8e, 0x73, 0x54, 0xf9, 0x2d, 0xf2, 0x45, 0x09);
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public TestNodeBase(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public TestNodeBase(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new global::System.Guid(0x2b9bfc1f, 0x0c97, 0x49bd, 0xa5, 0x1e, 0x52, 0x84, 0x81, 0xb0, 0x3f, 0x9c);
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = string.Empty;
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// Description for imbNLP.PipelineDSLD.TestNodeBase.Name
		/// </summary>
		[DslDesign::DisplayNameResource("imbNLP.PipelineDSLD.TestNodeBase/Name.DisplayName", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
		[DslDesign::DescriptionResource("imbNLP.PipelineDSLD.TestNodeBase/Name.Description", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("2b9bfc1f-0c97-49bd-a51e-528481b03f9c")]
		public global::System.String Name
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return namePropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				NamePropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the TestNodeBase.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<TestNodeBase, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the TestNodeBase.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the TestNodeBase.Name domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return NameDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(TestNodeBase element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(TestNodeBase element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.namePropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
	}
}
namespace imbNLP.PipelineDSLD
{
	/// <summary>
	/// DomainClass TestNodeBase1
	/// Elements embedded in the model. Appear as boxes on the diagram.
	/// </summary>
	[DslDesign::DisplayNameResource("imbNLP.PipelineDSLD.TestNodeBase1.DisplayName", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
	[DslDesign::DescriptionResource("imbNLP.PipelineDSLD.TestNodeBase1.Description", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
	[DslModeling::DomainModelOwner(typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel))]
	[global::System.CLSCompliant(true)]
	[global::System.Diagnostics.DebuggerDisplay("{GetType().Name,nq} (Name = {namePropertyStorage})")]
	[DslModeling::DomainObjectId("6cb12d8c-d13d-418b-b45a-d57708048214")]
	public partial class TestNodeBase1 : DslModeling::ModelElement
	{
		#region Constructors, domain class Id
	
		/// <summary>
		/// TestNodeBase1 domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new global::System.Guid(0x6cb12d8c, 0xd13d, 0x418b, 0xb4, 0x5a, 0xd5, 0x77, 0x08, 0x04, 0x82, 0x14);
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public TestNodeBase1(DslModeling::Store store, params DslModeling::PropertyAssignment[] propertyAssignments)
			: this(store != null ? store.DefaultPartitionForClass(DomainClassId) : null, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new element is to be created.</param>
		/// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
		public TestNodeBase1(DslModeling::Partition partition, params DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, propertyAssignments)
		{
		}
		#endregion
		#region Name domain property code
		
		/// <summary>
		/// Name domain property Id.
		/// </summary>
		public static readonly global::System.Guid NameDomainPropertyId = new global::System.Guid(0x6e1120ce, 0xf2cb, 0x490c, 0x81, 0x85, 0x53, 0xbe, 0x93, 0x82, 0x5e, 0x0c);
		
		/// <summary>
		/// Storage for Name
		/// </summary>
		private global::System.String namePropertyStorage = string.Empty;
		
		/// <summary>
		/// Gets or sets the value of Name domain property.
		/// Description for imbNLP.PipelineDSLD.TestNodeBase1.Name
		/// </summary>
		[DslDesign::DisplayNameResource("imbNLP.PipelineDSLD.TestNodeBase1/Name.DisplayName", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
		[DslDesign::DescriptionResource("imbNLP.PipelineDSLD.TestNodeBase1/Name.Description", typeof(global::imbNLP.PipelineDSLD.NLPPipelineDSLDDomainModel), "imbNLP.PipelineDSLD.GeneratedCode.DomainModelResx")]
		[global::System.ComponentModel.DefaultValue("")]
		[DslModeling::ElementName]
		[DslModeling::DomainObjectId("6e1120ce-f2cb-490c-8185-53be93825e0c")]
		public global::System.String Name
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return namePropertyStorage;
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				NamePropertyHandler.Instance.SetValue(this, value);
			}
		}
		/// <summary>
		/// Value handler for the TestNodeBase1.Name domain property.
		/// </summary>
		internal sealed partial class NamePropertyHandler : DslModeling::DomainPropertyValueHandler<TestNodeBase1, global::System.String>
		{
			private NamePropertyHandler() { }
		
			/// <summary>
			/// Gets the singleton instance of the TestNodeBase1.Name domain property value handler.
			/// </summary>
			public static readonly NamePropertyHandler Instance = new NamePropertyHandler();
		
			/// <summary>
			/// Gets the Id of the TestNodeBase1.Name domain property.
			/// </summary>
			public sealed override global::System.Guid DomainPropertyId
			{
				[global::System.Diagnostics.DebuggerStepThrough]
				get
				{
					return NameDomainPropertyId;
				}
			}
			
			/// <summary>
			/// Gets a strongly-typed value of the property on specified element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <returns>Property value.</returns>
			public override sealed global::System.String GetValue(TestNodeBase1 element)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
				return element.namePropertyStorage;
			}
		
			/// <summary>
			/// Sets property value on an element.
			/// </summary>
			/// <param name="element">Element which owns the property.</param>
			/// <param name="newValue">New property value.</param>
			public override sealed void SetValue(TestNodeBase1 element, global::System.String newValue)
			{
				if (element == null) throw new global::System.ArgumentNullException("element");
		
				global::System.String oldValue = GetValue(element);
				if (newValue != oldValue)
				{
					ValueChanging(element, oldValue, newValue);
					element.namePropertyStorage = newValue;
					ValueChanged(element, oldValue, newValue);
				}
			}
		}
		
		#endregion
	}
}
