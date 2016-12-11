using SM.LIB.VM.Account.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LIB.VM.Account
{
    public class SClassPresentVM
    {
        public bool PreNursary { get; set; }
        public bool Nursary  { get; set; }
        public bool LKG  { get; set; }
        public bool KG  { get; set; }
        public bool UKG { get; set; }
        public bool ClassI { get; set; }
        public bool ClassII   { get; set; }
        public bool ClassIII  { get; set; }
        public bool ClassIV   { get; set; }
        public bool ClassV  { get; set; }
        public bool ClassVI   { get; set; }
        public bool ClassVII  { get; set; }
        public bool ClassVIII { get; set; }
        public bool ClassIX  { get; set; }
        public bool ClassX   { get; set; }
        public bool ClassXI  { get; set; }
        public bool ClassXII { get; set; }

        // for Section

        public IEnumerable<SSectionEnum> SectionPreNursary { get; set; }
        public IEnumerable<SSectionEnum> SectionNursary { get; set; }
        public IEnumerable<SSectionEnum> SectionLKG { get; set; }
        public IEnumerable<SSectionEnum> SectionKG { get; set; }
        public IEnumerable<SSectionEnum> SectionUKG { get; set; }
        public IEnumerable<SSectionEnum> SectionClassI { get; set; }
        public IEnumerable<SSectionEnum> SectionClassII { get; set; }
        public IEnumerable<SSectionEnum> SectionClassIII { get; set; }
        public IEnumerable<SSectionEnum> SectionClassIV { get; set; }
        public IEnumerable<SSectionEnum> SectionClassV { get; set; }
        public IEnumerable<SSectionEnum> SectionClassVI { get; set; }
        public IEnumerable<SSectionEnum> SectionClassVII { get; set; }
        public IEnumerable<SSectionEnum> SectionClassVIII { get; set; }
        public IEnumerable<SSectionEnum> SectionClassIX { get; set; }
        public IEnumerable<SSectionEnum> SectionClassX { get; set; }
        public IEnumerable<SSectionEnum> SectionClassXI { get; set; }
        public IEnumerable<SSectionEnum> SectionClassXII { get; set; }

    }
}
