using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenageStaffDBWpfAppNetCore.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Selary { get; set; }
        public int MaxNumber { get; set; }
        public List<User> Users { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
