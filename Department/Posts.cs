using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department
{
    class Posts
    {
        public int PostID { get; set; }
        public string Post { get; set; }

        public override string ToString()
        {
            return Post;
        }
    }
}
