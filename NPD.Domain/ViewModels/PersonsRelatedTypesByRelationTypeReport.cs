using NPD.Domain.Entities.PersonAggreagete;
using System;
using System.Collections.Generic;
using System.Text;

namespace NPD.Domain.ViewModels
{
    public class PersonsRelatedTypesByRelationTypeReport
    {
        public string PersonalNumber { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public RelationType? Type { get; set; }
        public int? Count { get; set; }
    }
}
