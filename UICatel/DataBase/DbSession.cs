//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UICatel.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class DbSession
    {
        public long ID { get; set; }
        public Nullable<long> ID_TargetWord { get; set; }
        public Nullable<long> ID_ResultWord { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Words WordResult { get; set; }
        public virtual Words WordTarget { get; set; }
    }
}