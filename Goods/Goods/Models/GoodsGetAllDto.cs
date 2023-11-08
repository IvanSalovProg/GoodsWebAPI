namespace Goods.Models
{
    public class GoodsGetAllDto
    {
        public List<GoodsGetDto> Goods { get; set; }

        public List<GroupDto> Groups { get; set; }
    }
}
