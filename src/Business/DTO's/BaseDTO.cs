namespace ECommerse.Business.DTO_s;

public class BaseDTO<TKey>
{
    public TKey Id { get; set; } = default!;
}

public class BaseDTO : BaseDTO<int> { }
