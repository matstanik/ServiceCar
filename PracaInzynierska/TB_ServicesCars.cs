//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PracaInzynierska
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_ServicesCars
    {
        public int ServicesCarId { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public double Capacity { get; set; }
        public string EngineType { get; set; }
    
        public virtual TB_CarRequests TB_CarRequests { get; set; }
    }
}