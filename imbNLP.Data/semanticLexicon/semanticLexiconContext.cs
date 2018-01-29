﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="semanticLexiconContext.cs" company="imbVeles" >
//
// Copyright (C) 2018 imbVeles
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Project: imbNLP.Data
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------

// -----------------------------------------------------------------------
// <autogenerated>
//    This code was generated from a template.
//
//    Changes to this file may cause incorrect behaviour and will be lost
//    if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------

namespace imbNLP.semanticLexicon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BrightstarDB.Client;
    using BrightstarDB.EntityFramework;

    using imbNLP.Data.semanticLexicon.core;
    using imbNLP.Data.semanticLexicon.posCase;

    public partial class semanticLexiconContext : BrightstarEntityContext {
    	
        static semanticLexiconContext() 
        {
            InitializeEntityMappingStore();
        }
        
        /// <summary>
        /// Initialize the internal cache of entity attribute information.
        /// </summary>
        /// <remarks>
        /// This method is normally invoked from the static constructor for the generated context class.
        /// It is provided as a public static method to enable the use of the cached entity attribute 
        /// information without the need to construct a context (typically in test code). 
        /// In normal application code you should never need to explicitly call this method.
        /// </remarks>
        public static void InitializeEntityMappingStore()
        {
            var provider = new ReflectionMappingProvider();
            provider.AddMappingsForType(EntityMappingStore.Instance, typeof(imbNLP.Data.semanticLexicon.core.IConcept));
            EntityMappingStore.Instance.SetImplMapping<imbNLP.Data.semanticLexicon.core.IConcept, Concept>();
            provider.AddMappingsForType(EntityMappingStore.Instance, typeof(imbNLP.Data.semanticLexicon.core.ITermInstance));
            EntityMappingStore.Instance.SetImplMapping<imbNLP.Data.semanticLexicon.core.ITermInstance, TermInstance>();
            provider.AddMappingsForType(EntityMappingStore.Instance, typeof(imbNLP.Data.semanticLexicon.core.ITermLemma));
            EntityMappingStore.Instance.SetImplMapping<imbNLP.Data.semanticLexicon.core.ITermLemma, TermLemma>();
        }
    	
        /// <summary>
        /// Initialize a new entity context using the specified BrightstarDB
        /// Data Object Store connection
        /// </summary>
        /// <param name="dataObjectStore">The connection to the BrightstarDB Data Object Store that will provide the entity objects</param>
        public semanticLexiconContext(IDataObjectStore dataObjectStore) : base(dataObjectStore)
        {
            InitializeContext();
        }
    
        /// <summary>
        /// Initialize a new entity context using the specified Brightstar connection string
        /// </summary>
        /// <param name="connectionString">The connection to be used to connect to an existing BrightstarDB store</param>
        /// <param name="enableOptimisticLocking">OPTIONAL: If set to true optmistic locking will be applied to all entity updates</param>
        /// <param name="updateGraphUri">OPTIONAL: The URI identifier of the graph to be updated with any new triples created by operations on the store. If
        /// not defined, the default graph in the store will be updated.</param>
        /// <param name="datasetGraphUris">OPTIONAL: The URI identifiers of the graphs that will be queried to retrieve entities and their properties.
        /// If not defined, all graphs in the store will be queried.</param>
        /// <param name="versionGraphUri">OPTIONAL: The URI identifier of the graph that contains version number statements for entities. 
        /// If not defined, the <paramref name="updateGraphUri"/> will be used.</param>
        public semanticLexiconContext(
            string connectionString, 
            bool? enableOptimisticLocking=null,
            string updateGraphUri = null,
            IEnumerable<string> datasetGraphUris = null,
            string versionGraphUri = null
        ) : base(connectionString, enableOptimisticLocking, updateGraphUri, datasetGraphUris, versionGraphUri)
        {
            InitializeContext();
        }
    
        /// <summary>
        /// Initialize a new entity context using the specified Brightstar
        /// connection string retrieved from the configuration.
        /// </summary>
        public semanticLexiconContext() : base()
        {
            InitializeContext();
        }
    	
        /// <summary>
        /// Initialize a new entity context using the specified Brightstar
        /// connection string retrieved from the configuration and the
        //  specified target graphs
        /// </summary>
        /// <param name="updateGraphUri">The URI identifier of the graph to be updated with any new triples created by operations on the store. If
        /// set to null, the default graph in the store will be updated.</param>
        /// <param name="datasetGraphUris">The URI identifiers of the graphs that will be queried to retrieve entities and their properties.
        /// If set to null, all graphs in the store will be queried.</param>
        /// <param name="versionGraphUri">The URI identifier of the graph that contains version number statements for entities. 
        /// If set to null, the value of <paramref name="updateGraphUri"/> will be used.</param>
        public semanticLexiconContext(
            string updateGraphUri,
            IEnumerable<string> datasetGraphUris,
            string versionGraphUri
        ) : base(updateGraphUri:updateGraphUri, datasetGraphUris:datasetGraphUris, versionGraphUri:versionGraphUri)
        {
            InitializeContext();
        }
    	
        private void InitializeContext() 
        {
            Concepts = 	new BrightstarEntitySet<imbNLP.Data.semanticLexicon.core.IConcept>(this);
            TermInstances = 	new BrightstarEntitySet<imbNLP.Data.semanticLexicon.core.ITermInstance>(this);
            TermLemmas = 	new BrightstarEntitySet<imbNLP.Data.semanticLexicon.core.ITermLemma>(this);
        }
    	
        public IEntitySet<imbNLP.Data.semanticLexicon.core.IConcept> Concepts
        {
            get; private set;
        }
    	
        public IEntitySet<imbNLP.Data.semanticLexicon.core.ITermInstance> TermInstances
        {
            get; private set;
        }
    	
        public IEntitySet<imbNLP.Data.semanticLexicon.core.ITermLemma> TermLemmas
        {
            get; private set;
        }
    	
        public IEntitySet<T> EntitySet<T>() where T : class {
            var itemType = typeof(T);
            if (typeof(T).Equals(typeof(imbNLP.Data.semanticLexicon.core.IConcept))) {
                return (IEntitySet<T>)this.Concepts;
            }
            if (typeof(T).Equals(typeof(imbNLP.Data.semanticLexicon.core.ITermInstance))) {
                return (IEntitySet<T>)this.TermInstances;
            }
            if (typeof(T).Equals(typeof(imbNLP.Data.semanticLexicon.core.ITermLemma))) {
                return (IEntitySet<T>)this.TermLemmas;
            }
            throw new InvalidOperationException(typeof(T).FullName + " is not a recognized entity interface type.");
        }
    
    } // end class semanticLexiconContext

    public partial class Concept : BrightstarEntityObject, IConcept 
    {
        public Concept(BrightstarEntityContext context, BrightstarDB.Client.IDataObject dataObject) : base(context, dataObject) { }
        public Concept(BrightstarEntityContext context) : base(context, typeof(Concept)) { }
        public Concept() : base() { }
        public System.String Id { get {return GetKey(); } set { SetKey(value); } }
        #region Implementation of imbNLP.Data.semanticLexicon.core.IConcept
    
        public System.String name
        {
            get { return GetRelatedProperty<System.String>("name"); }
            set { SetRelatedProperty("name", value); }
        }
    
        public System.String description
        {
            get { return GetRelatedProperty<System.String>("description"); }
            set { SetRelatedProperty("description", value); }
        }
        public System.Collections.Generic.ICollection<imbNLP.Data.semanticLexicon.core.ITermLemma> lemmas
        {
            get { return GetRelatedObjects<imbNLP.Data.semanticLexicon.core.ITermLemma>("lemmas"); }
            set { if (value == null) throw new ArgumentNullException("value"); SetRelatedObjects("lemmas", value); }
        }
    
        public imbNLP.Data.semanticLexicon.core.IConcept hyperConcept
        {
            get { return GetRelatedObject<imbNLP.Data.semanticLexicon.core.IConcept>("hyperConcept"); }
            set { SetRelatedObject<imbNLP.Data.semanticLexicon.core.IConcept>("hyperConcept", value); }
        }
        public System.Collections.Generic.ICollection<imbNLP.Data.semanticLexicon.core.IConcept> relatedTo
        {
            get { return GetRelatedObjects<imbNLP.Data.semanticLexicon.core.IConcept>("relatedTo"); }
            set { if (value == null) throw new ArgumentNullException("value"); SetRelatedObjects("relatedTo", value); }
        }
        public System.Collections.Generic.ICollection<imbNLP.Data.semanticLexicon.core.IConcept> relatedFrom
        {
            get { return GetRelatedObjects<imbNLP.Data.semanticLexicon.core.IConcept>("relatedFrom"); }
            set { if (value == null) throw new ArgumentNullException("value"); SetRelatedObjects("relatedFrom", value); }
        }
        public System.Collections.Generic.ICollection<imbNLP.Data.semanticLexicon.core.IConcept> hypoConcepts
        {
            get { return GetRelatedObjects<imbNLP.Data.semanticLexicon.core.IConcept>("hypoConcepts"); }
            set { if (value == null) throw new ArgumentNullException("value"); SetRelatedObjects("hypoConcepts", value); }
        }
        #endregion
    }

    public partial class TermInstance : BrightstarEntityObject, ITermInstance 
    {
        public TermInstance(BrightstarEntityContext context, BrightstarDB.Client.IDataObject dataObject) : base(context, dataObject) { }
        public TermInstance(BrightstarEntityContext context) : base(context, typeof(TermInstance)) { }
        public TermInstance() : base() { }
        public System.String Id { get {return GetKey(); } set { SetKey(value); } }
        #region Implementation of imbNLP.Data.semanticLexicon.core.ITermInstance
    
        public System.String name
        {
            get { return GetRelatedProperty<System.String>("name"); }
            set { SetRelatedProperty("name", value); }
        }
    
        public imbNLP.Data.semanticLexicon.core.ITermLemma lemma
        {
            get { return GetRelatedObject<imbNLP.Data.semanticLexicon.core.ITermLemma>("lemma"); }
            set { SetRelatedObject<imbNLP.Data.semanticLexicon.core.ITermLemma>("lemma", value); }
        }
    
        public System.String type
        {
            get { return GetRelatedProperty<System.String>("type"); }
            set { SetRelatedProperty("type", value); }
        }
    
        public System.String gramSet
        {
            get { return GetRelatedProperty<System.String>("gramSet"); }
            set { SetRelatedProperty("gramSet", value); }
        }
        #endregion
    }

    public partial class TermLemma : BrightstarEntityObject, ITermLemma 
    {
        public TermLemma(BrightstarEntityContext context, BrightstarDB.Client.IDataObject dataObject) : base(context, dataObject) { }
        public TermLemma(BrightstarEntityContext context) : base(context, typeof(TermLemma)) { }
        public TermLemma() : base() { }
        public System.String Id { get {return GetKey(); } set { SetKey(value); } }
        #region Implementation of imbNLP.Data.semanticLexicon.core.ITermLemma
    
        public System.String name
        {
            get { return GetRelatedProperty<System.String>("name"); }
            set { SetRelatedProperty("name", value); }
        }
        public System.Collections.Generic.ICollection<imbNLP.Data.semanticLexicon.core.ITermInstance> instances
        {
            get { return GetRelatedObjects<imbNLP.Data.semanticLexicon.core.ITermInstance>("instances"); }
            set { if (value == null) throw new ArgumentNullException("value"); SetRelatedObjects("instances", value); }
        }
        public System.Collections.Generic.ICollection<imbNLP.Data.semanticLexicon.core.ITermLemma> compounds
        {
            get { return GetRelatedObjects<imbNLP.Data.semanticLexicon.core.ITermLemma>("compounds"); }
            set { if (value == null) throw new ArgumentNullException("value"); SetRelatedObjects("compounds", value); }
        }
        public System.Collections.Generic.ICollection<imbNLP.Data.semanticLexicon.core.ITermLemma> relatedTo
        {
            get { return GetRelatedObjects<imbNLP.Data.semanticLexicon.core.ITermLemma>("relatedTo"); }
            set { if (value == null) throw new ArgumentNullException("value"); SetRelatedObjects("relatedTo", value); }
        }
        public System.Collections.Generic.ICollection<imbNLP.Data.semanticLexicon.core.ITermLemma> relatedFrom
        {
            get { return GetRelatedObjects<imbNLP.Data.semanticLexicon.core.ITermLemma>("relatedFrom"); }
            set { if (value == null) throw new ArgumentNullException("value"); SetRelatedObjects("relatedFrom", value); }
        }
        public System.Collections.Generic.ICollection<imbNLP.Data.semanticLexicon.core.IConcept> concepts
        {
            get { return GetRelatedObjects<imbNLP.Data.semanticLexicon.core.IConcept>("concepts"); }
            set { if (value == null) throw new ArgumentNullException("value"); SetRelatedObjects("concepts", value); }
        }
    
        public System.String type
        {
            get { return GetRelatedProperty<System.String>("type"); }
            set { SetRelatedProperty("type", value); }
        }
    
        public System.String gramSet
        {
            get { return GetRelatedProperty<System.String>("gramSet"); }
            set { SetRelatedProperty("gramSet", value); }
        }
        #endregion
    }
}