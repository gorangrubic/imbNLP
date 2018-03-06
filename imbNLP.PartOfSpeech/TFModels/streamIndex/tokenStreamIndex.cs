using imbMiningContext.MCDocumentStructure;
using imbNLP.PartOfSpeech.pipelineForPos.subject;
using imbNLP.PartOfSpeech.TFModels.webLemma.table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace imbNLP.PartOfSpeech.TFModels.streamIndex
{
    public class tokenStreamIndex
    {

        public tokenStreamIndex()
        {

        }


        public webLemmaTermTable streamTable { get; set; } 


        [XmlIgnore]
        public List<imbMCStream> streams { get; set; } = new List<imbMCStream>();


    }
}
