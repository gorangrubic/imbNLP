using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace imbNLP.PartOfSpeech.flags.token
{

    /// <summary>
    /// Role of the block, containing the <see cref="imbMiningContext.MCDocumentStructure.imbMCDocumentElement"/>
    /// </summary>
    public enum cnt_blockRole
    {
        none,

        navigation,

        information,

        reserve,

        footer,

        header,


    }

}