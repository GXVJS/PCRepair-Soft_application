//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PCRepair_Soft_application.app
{
    using System;
    using System.Collections.Generic;
    
    public partial class Enterprise_Equipment
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> state_id { get; set; }
        public Nullable<System.DateTime> arrival_date { get; set; }
        public Nullable<System.DateTime> put_into_operation_date { get; set; }
        public Nullable<System.DateTime> decommissioning_date { get; set; }
    
        public virtual Equipment_States Equipment_States { get; set; }
    }
}
