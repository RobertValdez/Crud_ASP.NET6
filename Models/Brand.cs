using System;
using System.Collections.Generic;

namespace IntroASP.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Articles = new HashSet<Article>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Article> Articles { get; set; }
    }
}
