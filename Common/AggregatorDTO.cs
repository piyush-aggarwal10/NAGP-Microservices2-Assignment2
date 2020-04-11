using System.Collections.Generic;

namespace Common
{
    public class AggregatorDTO
    {
        public UserDTO UserDetails { get; set; }
        public List<OrderDTO> Orders { get; set; }
    }
}
