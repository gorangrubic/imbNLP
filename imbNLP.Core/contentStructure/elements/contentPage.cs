// --------------------------------------------------------------------------------------------------------------------
// <copyright file="contentPage.cs" company="imbVeles" >
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
// Project: imbNLP.Core
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbNLP.Core.contentStructure.elements
{
    #region imbVELES USING

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;
    using imbACE.Core.commands.menu;
    using imbACE.Core.core;
    using imbACE.Core.operations;
    using imbACE.Services.console;
    using imbACE.Services.terminal;
    using imbNLP.Core.contentStructure.collections;
    using imbNLP.Core.contentStructure.core;
    using imbNLP.Core.contentStructure.interafaces;
    
    using imbNLP.Data.extended.domain;
    using imbNLP.Data.extended.unitex;
    using imbNLP.Data.semanticLexicon.core;
    using imbNLP.Data.semanticLexicon.explore;
    using imbNLP.Data.semanticLexicon.morphology;
    using imbNLP.Data.semanticLexicon.procedures;
    using imbNLP.Data.semanticLexicon.source;
    using imbNLP.Data.semanticLexicon.term;
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.files.folders;
    using imbSCI.Core.files.unit;
    using imbSCI.Core.reporting;
    using imbSCI.Data;
    using imbSCI.Data.collection.nested;
    using imbSCI.Data.data;
    using imbSCI.Data.enums.reporting;
    using imbSCI.Data.interfaces;
    using imbSCI.DataComplex.extensions.data.formats;
    using imbSCI.DataComplex.extensions.text;
    using imbSCI.DataComplex.special;
    // using Newtonsoft.Json;
    using imbSCI.Core.attributes;
    using imbCommonModels.structure;
    using imbACE.Network.tools;
    using imbNLP.Data.enums;
    using imbCommonModels;

    #endregion





    /// <summary>
    /// 2013c: LowLevel resurs
    /// </summary>
    [imb(imbAttributeName.xmlNodeTypeName, "p")]
    [imb(imbAttributeName.xmlNodeTypeName, "contentTitle")]
    public class contentPage : contentElementBase, IContentPage
    {

        

        public string cacheInstanceID
        {
            get
            {
                return contentUrl;
            }

        }


        public IEnumerator GetEnumerator()
        {

            if (items == null) return null;

            return items.GetEnumerator();

        }

        public int indexOf(IObjectWithChildSelector child)
        {
            if (items == null) return -1;

            return items.IndexOf(child as IContentBlock);
        }

        public int Count()
        {
            if (items == null) return 0;

            return items.Count;
        }

        /// <summary>
        /// Gets the <see cref="System.Object"/> with the specified key.
        /// </summary>
        /// <value>
        /// The <see cref="System.Object"/>.
        /// </value>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public object this[int key]
        {
            get
            {
                if (items == null) return null;

                return items[key];
            }
        }

        /// <summary>
        /// Gets the <see cref="System.Object"/> with the specified child name.
        /// </summary>
        /// <value>
        /// The <see cref="System.Object"/>.
        /// </value>
        /// <param name="childName">Name of the child.</param>
        /// <returns></returns>
        public object this[string childName]
        {
            get
            {
                foreach (IContentElement ch in items)
                {
                    if (ch.name == childName)
                    {
                        return ch;
                    }
                }
                return null;
            }
        }


        public contentPage()
        {
            items = new contentBlockCollection();
        }

      





        /// <summary>
        /// Popunjava kolekcije> paragraphs, sentences, tokens
        /// </summary>
        public virtual void recountItems()
        {
            paragraphs.Clear();
            sentences.Clear();
            tokens.Clear();

            foreach (contentBlock item in items)
            {
                paragraphs.AddRange(item.items);
                foreach (contentParagraph par in item.items)
                {
                    sentences.AddRange(par.items);
                    foreach (contentSentence sen in par.items)
                    {
                        
                        foreach (IContentToken tk in sen.items)
                        {
                            if (tk is IContentSubSentence)
                            {
                                IContentSubSentence sub = (IContentSubSentence)tk;
                                foreach (IContentToken tks in sub.items)
                                {
                                    tks.parent = sub;
                                    tokens.Add(tks);
                                }
                                
                            } else
                            {
                                
                                tk.parent = sen;
                                tokens.Add(tk);
                            }
                        }
                        sen.parent = par;
                        tokens.AddRange(sen.items);
                    }
                    par.parent = item;
                }
                item.parent = this;
            }

        }



        #region ---------- DOCUMENT / PROJECT 

        #region -----------  project  -------  [referenca prema projektu u kojem je sadrzana ova stranica]

        private IContentProject _project; // = new IContentProject();

        /// <summary>
        /// referenca prema projektu u kojem je sadrzana ova stranica
        /// </summary>
        [XmlIgnore]
        [Category("contentPage")]
        [DisplayName("project")]
        [Description("referenca prema projektu u kojem je sadrzana ova stranica")]
        // [JsonIgnore]
        public IContentProject project
        {
            get { return _project; }
            set
            {
                // Boolean chg = (_project != value);
                _project = value;
                OnPropertyChanged("project");
                // if (chg) {}
            }
        }

        #endregion

        #region -----------  document  -------  [referenca prema dokumentu u kojem je sadrzana ova stranica. Ukoliko je null onda je stranica sama za sebe]

        private IContentDocument _document; // = new IContentDocument();

        /// <summary>
        /// referenca prema dokumentu u kojem je sadrzana ova stranica. Ukoliko je null onda je stranica sama za sebe
        /// </summary>
        [XmlIgnore]
        [Category("contentPage")]
        [DisplayName("document")]
        [Description(
            "referenca prema dokumentu u kojem je sadrzana ova stranica. Ukoliko je null onda je stranica sama za sebe")
        ]
        // [JsonIgnore]
        public IContentDocument document
        {
            get { return _document; }
            set
            {
                // Boolean chg = (_document != value);
                _document = value;
                OnPropertyChanged("document");
                // if (chg) {}
            }
        }

        #endregion

        #endregion

       

        #region IContentPage Members
        //[XmlIgnore]
        //IContentCollectionBase IContentElement.items
        //{
        //    get { return _items; }
        //}

        /// <summary>
        /// #1 PrimaryFlaging krece od tokena ka stranici -- od mikro ka makro nivou
        /// </summary>
        public override void primaryFlaging(params object[] resources)
        {
            foreach (var t in headTokens) t.primaryFlaging(resources);
            foreach (var t in items) t.primaryFlaging(resources);
            
        }

        /// <summary>
        /// #2 SecondaryFlaging krece od makro ka mikro novou
        /// </summary>
        public override void secondaryFlaging(params object[] resources)
        {
            foreach (var t in headTokens) t.secondaryFlaging(resources);
            foreach (var t in items) t.secondaryFlaging(resources);

            
        }

        /// <summary>
        /// #3 Izvlacene generalne semantike stvara osnovne, opste, ne-specificne, tvrdnje na osnovu obradjenog teksta
        /// </summary>
        /// <param name="resources"></param>
        public override void generalSemanticsFlaging(params object[] resources)
        {
        }

        /// <summary>
        /// #4 Specijalna semantika stvara tvrdnje usko vezane za zadatak obrade
        /// </summary>
        /// <param name="resources"></param>
        public override void specialSematicsFlaging(params object[] resources)
        {
        }

        #endregion

       

        //private contentBlockCollection _items = new contentBlockCollection();

        /// <summary>
        /// Blokovi sadrzaja
        /// </summary>
        // [XmlIgnore]
        [Category("nlpContent")]
        [DisplayName("paragraphs")]
        [Description("Blokovi sadrzaja")]
       [imb(imbAttributeName.xmlEntityOutput)]
        public contentBlockCollection items
        {
            get {
                if (_items == null) _items = new contentBlockCollection();

                return _items as contentBlockCollection;
            }
            set
            {
                // Boolean chg = (_paragraphs != value);
                _items = value;
                OnPropertyChanged("paragraphs");
                // if (chg) {}
            }
        }

        

        #region --- paragraphs ------- Bindable property

        private contentParagraphCollection _paragraphs = new contentParagraphCollection();

        /// <summary>
        /// Bindable property
        /// </summary>
        [XmlIgnore]
        public contentParagraphCollection paragraphs
        {
            get { return _paragraphs; }
            set
            {
                _paragraphs = value;
                OnPropertyChanged("paragraphs");
            }
        }

        #endregion

        #region -----------  sentences  -------  [Sve rečenice u nlpContent-u]

        private contentSentenceCollection _sentences = new contentSentenceCollection();

        /// <summary>
        /// Sve rečenice u nlpContent-u
        /// </summary>
        [XmlIgnore]
        [Category("Misc")]
        [DisplayName("sentences")]
        [Description("Sve rečenice u nlpContent-u")]
        public contentSentenceCollection sentences
        {
            get { return _sentences; }
            set
            {
                _sentences = value;
                OnPropertyChanged("sentences");
            }
        }

        #endregion

        #region -----------  chunks  -------  [Svi chunkovi]

        private contentChunkCollection _chunks = new contentChunkCollection();

        /// <summary>
        /// Svi chunkovi
        /// </summary>
        // [XmlIgnore]
        [Category("Misc")]
        [DisplayName("chunks")]
        [Description("Svi chunkovi")]
        [imb(imbAttributeName.xmlEntityOutput)]
        public contentChunkCollection chunks
        {
            get { return _chunks; }
            set
            {
                _chunks = value;
                OnPropertyChanged("chunks");
            }
        }

        #endregion

        #region -----------  tokens  -------  [Svi tokeni pronadjeni u nlpContentu]

        private contentTokenCollection _tokens = new contentTokenCollection();

        /// <summary>
        /// Svi tokeni pronadjeni u nlpContentu
        /// </summary>
        [XmlIgnore]
        [Category("Misc")]
        [DisplayName("tokens")]
        [Description("Svi tokeni pronadjeni u nlpContentu")]
        public contentTokenCollection tokens
        {
            get { return _tokens; }
            set
            {
                _tokens = value;
                OnPropertyChanged("tokens");
            }
        }

        #endregion

        /// <summary>
        /// Preuzima opisne podatke iz node/crawledpage objekta -- poziva se iz tokenizatora, ne prenosi sam asdrza
        /// </summary>
        /// <param name="sourcePage"></param>
        public void acceptSourcePage(node sourcePage)
        {
            if (sourcePage != null)
            {
                contentUrl = sourcePage.url;
                contentTitle = sourcePage.caption.htmlContentProcess();
                
                if (!domainInfo.isNullOrEmptyString())
                {

                    domainInfo = new domainAnalysis(contentUrl);


                    foreach (string word in domainInfo.domainWords)
                    {
                        contentToken newToken = new contentToken();
                        newToken.content = word;
                        newToken.sourceContent = domainInfo.domainRootName;
                        newToken.origin = contentTokenOrigin.domain;
                        headTokens.Add(newToken);
                    }


                    List<string> words = new List<string>();
                    MatchCollection mchs = imbStringSelect._select_wordsFromDomainname.Matches(contentTitle);
                    foreach (Match mch in mchs)
                    {
                        words.Add(mch.Value.ToLower());
                    }

                    foreach (string word in words)
                    {
                        contentToken newToken = new contentToken();
                        newToken.content = word;
                        newToken.sourceContent = contentTitle;
                        newToken.origin = contentTokenOrigin.title;
                        headTokens.Add(newToken);

                    }
                }
            }
        }

        public override List<Enum> GetFlags()
        {
            List<Enum> output = new List<Enum>();
            //foreach (var fl in flags)
            //{
            //    output.Add(fl as Enum);
            //}

            //foreach (var fl in detectionFlags)
            //{
            //    output.Add(fl as Enum);
            //}
            return output;
        }



        #region -----------  headTokens  -------  [Tokeni iz naslova, imena domena itd]
        private contentTokenCollection _headTokens = new contentTokenCollection();
                                    /// <summary>
                                    /// Tokeni iz naslova, imena domena itd
                                    /// </summary>
        // [XmlIgnore]
        [Category("contentPage")]
        [DisplayName("headTokens")]
        [Description("Tokeni iz naslova, imena domena itd")]
        // [JsonProperty]
        public contentTokenCollection headTokens
        {
            get
            {
                return _headTokens;
            }
            set
            {
                // Boolean chg = (_headTokens != value);
                _headTokens = value;
                OnPropertyChanged("headTokens");
                // if (chg) {}
            }
        }
        #endregion



        #region -----------  domainInfo  -------  [Informacije o domenu]
        private domainAnalysis _domainInfo;
                                    /// <summary>
                                    /// Informacije o domenu
                                    /// </summary>
        // [XmlIgnore]
        [Category("contentPage")]
        [DisplayName("domainInfo")]
        [Description("Informacije o domenu")]
        // [JsonProperty]
        public domainAnalysis domainInfo
        {
            get
            {
                if (_domainInfo == null) _domainInfo = new domainAnalysis(contentUrl);
                return _domainInfo;
            }
            set
            {
                // Boolean chg = (_domainInfo != value);
                _domainInfo = value;
                OnPropertyChanged("domainInfo");
                // if (chg) {}
            }
        }
        #endregion


        


        #region -----------  contentTitle  -------  [Naziv sadrzaja]

        private string _contentTitle; // = new String();

        /// <summary>
        /// Naziv sadrzaja
        /// </summary>
        // [XmlIgnore]
        [Category("contentPage")]
        [DisplayName("contentTitle")]
        [Description("Naziv sadrzaja")]
        //  [imb(imbAttributeName.xmlEntityOutput)]
        // [JsonProperty]
        public string contentTitle
        {
            get { return _contentTitle; }
            set
            {
                // Boolean chg = (_contentTitle != value);
                _contentTitle = value;
                OnPropertyChanged("contentTitle");
                // if (chg) {}
            }
        }

        #endregion

        #region -----------  contentUrl  -------  [Adresa stranice]

        private string _contentUrl = ""; // = new String();

        /// <summary>
        /// Adresa stranice
        /// </summary>
        // [XmlIgnore]
        [Category("contentPage")]
        [DisplayName("contentUrl")]
        [Description("Adresa stranice")]
        [imb(imbAttributeName.xmlEntityOutput)]
        // [JsonProperty]
        public string contentUrl
        {
            get { return _contentUrl; }
            set
            {
                // Boolean chg = (_contentUrl != value);
                _contentUrl = value;
                OnPropertyChanged("contentUrl");
                // if (chg) {}
            }
        }

        IContentCollectionBase IContentElement.items
        {
            get
            {
                return items;
            }
        }

        /// <summary>
        /// Gets or sets the blocks of page
        /// </summary>
        /// <value>
        /// The blocks.
        /// </value>
        public contentBlockCollection blocks
        {
            get
            {
                return (contentBlockCollection)items;
            }

            set
            {
                items = (contentBlockCollection)value;
            }
        }



        #endregion
    }
}