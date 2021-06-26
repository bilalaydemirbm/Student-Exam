using Exam.Core.Entity.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Exam.Core.Entity
{
    public class CoreEntity : IEntity<Guid>
    {
        //Her sayfada olacak veriler buradan alınacak. 
        //Global Unique Identifier. ID 1-2-3 diye değil hash olarak ilerliyor.
        [Key]
        public Guid ID { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
