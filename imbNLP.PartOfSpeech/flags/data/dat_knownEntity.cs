using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace imbNLP.PartOfSpeech.flags.data
{

    /// <summary>
    /// Flags for known entity that was recognized
    /// </summary>
    public enum dat_knownEntity
    {

        none,

        personalName,

        personalLastname,


        townName,

        postCode,

        companyName,


        standardCertificate
    }

}