using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFront.Common
{
    public class PageModel
    {
        public int page { get; set; } = 1;
        public int limit { get; set; } = 5;
        public string jhmc { get; set; }

        public int getStartNum()
        {
            return (page - 1) * limit + 1;
        }
        public int getEndNum()
        {
            return page * limit;
        }
    }
}
