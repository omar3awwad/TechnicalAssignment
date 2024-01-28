using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalAssignment.Api.Data.Entities
{
    public class CarMake
    {
        [Key]
        [Column("make_id")]
        public long MakeId { get; private set; }

        [Column("make_name")]
        public string MakeName { get; private set; } = null!;

        public static CarMake New(long makeId, string makeName)
        {
            return new CarMake { MakeId = makeId, MakeName = makeName };
        }
    }
}
