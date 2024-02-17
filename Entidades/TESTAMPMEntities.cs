using System.Data.Entity;

namespace Entidades
{
    public partial class TESTAMPMEntities : DbContext
    {
        public TESTAMPMEntities(string cc) : base(cc)
        {

        }
    }
}
