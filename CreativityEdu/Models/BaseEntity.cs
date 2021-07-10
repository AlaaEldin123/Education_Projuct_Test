using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreativityEdu.Models
{
    public class BaseEntity<T>
    {
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            LastUpdated = DateTime.Now;
            IsDelete = false;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }
        public DateTime CreationDate { get; set; }

        public bool IsDelete { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
