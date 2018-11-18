using System;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    public enum ImpositionTypes
    {
        MoreUp,
        Cover,
        CutStack,
        [Obsolete("Layout 'HP7200 AutoCutter'. Old cutter that has been removed long time ago")]
        Hp7200,
        [Obsolete("Old LayFlat. Replaced with PLF for long time already")]
        FlatBook,
        /// <summary>
        /// This one is actually meant to be named WebFed. To be renamed in sync with database
        /// </summary>
        SingleUp,
        InlineCutter,
        FastBlock,
        [Obsolete("Discontinued in 2017")]
        PhoneCases,
        SilverHalide,
        Hp6600InlineCutter,
        /// <summary>
        /// Initial dirty implementation of two A3+ sheets combined as left/right onto B2. Now used as backup (fallback) imposition.
        /// </summary>
        HP12000_MoreUp,
        /// <summary>
        /// Obsolete?
        /// </summary>
        HP12000_InlineCutter,
        /// <summary>
        /// Photobooks: printed on HP12000, cut on Smartstacker cutter
        /// </summary>
        HP12000_SmartStacker,
        /// <summary>
        /// Cards and calendars: printed on HP12000, cut on Plano cutter
        /// </summary>
        HP12000_Plano
    }
}