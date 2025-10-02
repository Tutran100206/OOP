using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleFruitStore.Generic
{
    public interface IPromotionRule<TContext>
    {
        bool IsMatch(TContext ctx);   // Kiểm tra điều kiện khuyến mãi
        void Apply(TContext ctx);     // Áp dụng khuyến mãi
    }
}
