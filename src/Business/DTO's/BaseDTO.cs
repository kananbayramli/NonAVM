using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerse.Business.DTO_s;

public class BaseDTO<TKey>
{
    public TKey Id { get; set; } = default!;
}

public class BaseDTO : BaseDTO<int> { }
