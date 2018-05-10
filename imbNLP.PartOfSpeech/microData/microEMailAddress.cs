using System;
using System.Linq;
using System.Collections.Generic;
using imbNLP.PartOfSpeech.flags.data;
using imbNLP.PartOfSpeech.microData.core;
using System.Text;

namespace imbNLP.PartOfSpeech.microData
{

    public class microEMailAddress : microDataBase
    {
        public String mailboxName { get; set; } = "";

        public String domainName { get; set; } = "";

        public dat_emailType type { get; set; } = dat_emailType.companyDomain;

    }

}